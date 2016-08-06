using Google.Apis.YouTube.v3;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace JSE
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void StartScreen_Load(object sender, EventArgs e)
        {
                webBrowser1.Navigate("http://jsdn.space/");
        }
    }
}
