using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyWidgets
{
    /// <summary>
    /// var spotifyAuth = new SpotifyAuthorization();
    /// //Start authorization (opens browser)
    /// 
    /// spotifyAuth.StartAuthorization();
    /// 
    /// // Later, make API calls - tokens will be automatically refreshed as needed
    /// 
    /// var userProfile = await spotifyAuth.GetUserProfileAsync();
    /// var playbackState = await spotifyAuth.GetCurrentPlaybackAsync();
    /// </summary>
    internal class SpotifyAuthorization
    {
        private const string clientId = "1b26c57682ed4323acced0b75e34586e";
        private const string clientSecret = "d62e2be9232e452da877901bca012f01";
        private const string redirectUri = "http://127.0.0.1:4002/callback";

        private string accessToken;
        private string refreshToken;
        private DateTime tokenExpiryTime;
        private HttpListener httpListener;

        // Public method to start authorization process
        public void StartAuthorization()
        {
            InitializeSpotify();
        }

        // Public method to get current playback state - example of how to use tokens
        public async Task<string> GetCurrentPlaybackAsync()
        {
            if (!await EnsureValidTokenAsync())
            {
                Debug.WriteLine("No valid token available. Please authorize first.");
                return null;
            }

            return await MakeSpotifyApiCallAsync("me/player");
        }

        // Public method to get user profile - another example
        public async Task<string> GetUserProfileAsync()
        {
            if (!await EnsureValidTokenAsync())
            {
                Debug.WriteLine("No valid token available. Please authorize first.");
                return null;
            }

            return await MakeSpotifyApiCallAsync("me");
        }

        // Generic method to make Spotify API calls with automatic token refresh
        private async Task<string> MakeSpotifyApiCallAsync(string endpoint)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    var response = await client.GetAsync($"https://api.spotify.com/v1/{endpoint}");

                    // If token expired, refresh and retry once
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        Debug.WriteLine("Access token expired, refreshing and retrying...");
                        await RefreshAccessTokenAsync();

                        // Retry with new token
                        client.DefaultRequestHeaders.Authorization =
                            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                        response = await client.GetAsync($"https://api.spotify.com/v1/{endpoint}");
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        Debug.WriteLine($"API call failed: HTTP {response.StatusCode}");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error making API call: {ex.Message}");
                    return null;
                }
            }
        }

        // Improved token validation with expiry checking
        private async Task<bool> EnsureValidTokenAsync()
        {
            // Check if we have tokens at all
            if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(refreshToken))
            {
                Debug.WriteLine("No tokens available. Need to authorize first.");
                return false;
            }

            // Check if token is expired or about to expire
            if (IsTokenExpired())
            {
                Debug.WriteLine("Token expired or about to expire, refreshing...");
                await RefreshAccessTokenAsync();
            }

            return !string.IsNullOrEmpty(accessToken);
        }

        // Check if token is expired (with 1-minute buffer)
        private bool IsTokenExpired()
        {
            return DateTime.UtcNow >= tokenExpiryTime;
        }

        private void InitializeSpotify()
        {
            string state = GenerateRandomString(16);
            string scope = "user-read-private user-read-email user-read-playback-state";

            string authorizeUrl =
                "https://accounts.spotify.com/authorize?" +
                $"response_type=code&client_id={clientId}&scope={Uri.EscapeDataString(scope)}&redirect_uri={Uri.EscapeDataString(redirectUri)}&state={state}";

            StartHttpListener();
            Debug.WriteLine("Opening Spotify authorization URL.");
            Process.Start(new ProcessStartInfo(authorizeUrl) { UseShellExecute = true });
        }

        private static string GenerateRandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            char[] buffer = new char[length];
            for (int i = 0; i < length; i++)
                buffer[i] = chars[random.Next(chars.Length)];
            return new string(buffer);
        }

        private void StartHttpListener()
        {
            if (httpListener != null && httpListener.IsListening)
            {
                Debug.WriteLine("HTTP Listener already running.");
                return;
            }

            httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://127.0.0.1:4002/callback/");
            httpListener.Start();
            Debug.WriteLine("HTTP Listener started on http://127.0.0.1:4002/callback/.");
            httpListener.BeginGetContext(new AsyncCallback(ListenerCallback), httpListener);
        }

        private async void ListenerCallback(IAsyncResult result)
        {
            try
            {
                var context = httpListener.EndGetContext(result);
                var request = context.Request;
                string code = request.QueryString["code"];
                Debug.WriteLine($"Received authorization code: {code}");

                string responseString = "<html><body>Login successful! You can close this window.</body></html>";
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                context.Response.ContentLength64 = buffer.Length;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                context.Response.OutputStream.Close();

                httpListener.Stop();
                Debug.WriteLine("HTTP Listener stopped.");

                await GetTokensAsync(code);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in ListenerCallback: {ex.Message}");
            }
        }

        private async Task GetTokensAsync(string code)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var values = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("grant_type", "authorization_code"),
                        new KeyValuePair<string, string>("code", code),
                        new KeyValuePair<string, string>("redirect_uri", redirectUri),
                        new KeyValuePair<string, string>("client_id", clientId),
                        new KeyValuePair<string, string>("client_secret", clientSecret)
                    });

                    Debug.WriteLine("Requesting access and refresh tokens.");
                    var response = await client.PostAsync("https://accounts.spotify.com/api/token", values);
                    string responseString = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"Token response: {responseString}");

                    if (!response.IsSuccessStatusCode)
                    {
                        Debug.WriteLine($"Token request failed: HTTP {response.StatusCode}");
                        return;
                    }

                    var json = JObject.Parse(responseString);
                    accessToken = json["access_token"]?.ToString();
                    refreshToken = json["refresh_token"]?.ToString();

                    // Set token expiry time (default 3600 seconds, refresh 1 minute early)
                    var expiresIn = json["expires_in"]?.Value<int>() ?? 3600;
                    tokenExpiryTime = DateTime.UtcNow.AddSeconds(expiresIn - 60);

                    Debug.WriteLine($"Access Token: {accessToken?.Substring(0, Math.Min(10, accessToken?.Length ?? 0))}...");
                    Debug.WriteLine($"Refresh Token: {refreshToken?.Substring(0, Math.Min(10, refreshToken?.Length ?? 0))}...");
                    Debug.WriteLine($"Token expires at: {tokenExpiryTime}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in GetTokensAsync: {ex.Message}");
            }
        }

        private async Task RefreshAccessTokenAsync()
        {
            Debug.WriteLine("Attempting to refresh access token.");
            try
            {
                using (var client = new HttpClient())
                {
                    var values = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("grant_type", "refresh_token"),
                        new KeyValuePair<string, string>("refresh_token", refreshToken),
                        new KeyValuePair<string, string>("client_id", clientId),
                        new KeyValuePair<string, string>("client_secret", clientSecret)
                    });

                    var response = await client.PostAsync("https://accounts.spotify.com/api/token", values);
                    string responseString = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"Refresh token response: {responseString}");

                    if (response.IsSuccessStatusCode)
                    {
                        var json = JObject.Parse(responseString);
                        accessToken = json["access_token"]?.ToString();
                        // Some refresh responses don't include a new refresh token
                        refreshToken = json["refresh_token"]?.ToString() ?? refreshToken;

                        // Update token expiry time
                        var expiresIn = json["expires_in"]?.Value<int>() ?? 3600;
                        tokenExpiryTime = DateTime.UtcNow.AddSeconds(expiresIn - 60);

                        Debug.WriteLine($"New Access Token: {accessToken?.Substring(0, Math.Min(10, accessToken?.Length ?? 0))}...");
                        Debug.WriteLine($"Token expires at: {tokenExpiryTime}");
                    }
                    else
                    {
                        Debug.WriteLine($"Refresh token failed: HTTP {response.StatusCode}");
                        // If refresh fails, need to re-authorize
                        accessToken = null;
                        refreshToken = null;
                        Debug.WriteLine("Refresh token may be expired. Re-authorization required.");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in RefreshAccessTokenAsync: {ex.Message}");
            }
        }

        public void OnFormClosing()
        {
            httpListener?.Stop();
            httpListener?.Close();
        }
    }
}   