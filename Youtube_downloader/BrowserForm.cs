using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youtube_downloader {
    public partial class BrowserForm : Form {

        public string SelectedUrl;    
        public event EventHandler<string> SelectedUrlChanged;

        public BrowserForm() {
            InitializeComponent();
            webBrowser.Source = new Uri("https://www.youtube.com/");
        }

        private void urlTextBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                webBrowser.CoreWebView2.Navigate(urlTextBox.Text);
            }
        }

        private void backButton_Click(object sender, EventArgs e) {
            webBrowser.GoBack();
        }

        private void forwardButton_Click(object sender, EventArgs e) {
            webBrowser.GoForward();
        }

        private void downloadAudioButton_Click(object sender, EventArgs e) {
            SelectedUrl = webBrowser.Source.ToString();
            SelectedUrlChanged?.Invoke(this, SelectedUrl);
            downloadAudioButton.Enabled = false;
        }

        private void webBrowser_NavigationStarting(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e) {
            urlTextBox.Text = webBrowser.Source.ToString();
        }

        private void webBrowser_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            urlTextBox.Text = webBrowser.Source.ToString();
            downloadAudioButton.Enabled = true;
        }
    }
}
