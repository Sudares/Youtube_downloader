using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeDLSharp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Youtube_downloader
{
    public partial class MainForm : Form
    {
        YouTubeDownload youtubeDownload; 
        //private BackgroundWorker backgroundWorker = new BackgroundWorker();    для ProgressBar

        public MainForm()
        {
            InitializeComponent();
            youtubeDownload = new YouTubeDownload();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var progress = new Progress<DownloadProgress>(p => audioProgressBar.Value = (int)(p.Progress*10));
            youtubeDownload.DownloadAudio(linkInputTextBox.Text, progress);
        }
    }
}
