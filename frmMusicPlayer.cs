using System.Windows.Forms;

namespace MyWidgets
{
    public partial class frmMusicPlayer : Form
    {

        public frmMusicPlayer()
        {
            InitializeComponent();
            var spotifyAuth = new SpotifyAuthorization();
            spotifyAuth.StartAuthorization();
        }

    }
}
