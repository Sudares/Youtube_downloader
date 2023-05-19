namespace Youtube_downloader
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.downloadAudioButton = new System.Windows.Forms.Button();
            this.linkInputTextBox = new System.Windows.Forms.TextBox();
            this.downloadPanel = new System.Windows.Forms.Panel();
            this.addPlaylistButton = new System.Windows.Forms.Button();
            this.enableAudioPanel = new System.Windows.Forms.Panel();
            this.player = new AxWMPLib.AxWindowsMediaPlayer();
            this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.playlistPanel = new System.Windows.Forms.Panel();
            this.searchPlaylistTextBox = new System.Windows.Forms.TextBox();
            this.playlistListBox = new System.Windows.Forms.ListBox();
            this.trackListPanel = new System.Windows.Forms.Panel();
            this.searchTrackTextBox = new System.Windows.Forms.TextBox();
            this.trackListBox = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.downloadPanel.SuspendLayout();
            this.enableAudioPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.playlistPanel.SuspendLayout();
            this.trackListPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // downloadAudioButton
            // 
            this.downloadAudioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadAudioButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(39)))), ((int)(((byte)(111)))));
            this.downloadAudioButton.FlatAppearance.BorderSize = 0;
            this.downloadAudioButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(74)))), ((int)(((byte)(0)))));
            this.downloadAudioButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(141)))), ((int)(((byte)(213)))));
            this.downloadAudioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadAudioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.downloadAudioButton.ForeColor = System.Drawing.SystemColors.Window;
            this.downloadAudioButton.Location = new System.Drawing.Point(877, 33);
            this.downloadAudioButton.Name = "downloadAudioButton";
            this.downloadAudioButton.Size = new System.Drawing.Size(115, 28);
            this.downloadAudioButton.TabIndex = 0;
            this.downloadAudioButton.Text = "Скачать";
            this.downloadAudioButton.UseVisualStyleBackColor = false;
            this.downloadAudioButton.Click += new System.EventHandler(this.downloadAudioButton_Click);
            // 
            // linkInputTextBox
            // 
            this.linkInputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkInputTextBox.Location = new System.Drawing.Point(239, 33);
            this.linkInputTextBox.Name = "linkInputTextBox";
            this.linkInputTextBox.Size = new System.Drawing.Size(621, 28);
            this.linkInputTextBox.TabIndex = 3;
            // 
            // downloadPanel
            // 
            this.downloadPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(106)))));
            this.downloadPanel.Controls.Add(this.addPlaylistButton);
            this.downloadPanel.Controls.Add(this.linkInputTextBox);
            this.downloadPanel.Controls.Add(this.downloadAudioButton);
            this.downloadPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.downloadPanel.Location = new System.Drawing.Point(0, 0);
            this.downloadPanel.Name = "downloadPanel";
            this.downloadPanel.Size = new System.Drawing.Size(1004, 97);
            this.downloadPanel.TabIndex = 5;
            // 
            // addPlaylistButton
            // 
            this.addPlaylistButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(39)))), ((int)(((byte)(111)))));
            this.addPlaylistButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.addPlaylistButton.FlatAppearance.BorderSize = 0;
            this.addPlaylistButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(74)))), ((int)(((byte)(0)))));
            this.addPlaylistButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(141)))), ((int)(((byte)(213)))));
            this.addPlaylistButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPlaylistButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addPlaylistButton.ForeColor = System.Drawing.SystemColors.Window;
            this.addPlaylistButton.Location = new System.Drawing.Point(0, 0);
            this.addPlaylistButton.Name = "addPlaylistButton";
            this.addPlaylistButton.Size = new System.Drawing.Size(239, 97);
            this.addPlaylistButton.TabIndex = 4;
            this.addPlaylistButton.Text = "Добавить плейлист";
            this.addPlaylistButton.UseVisualStyleBackColor = false;
            this.addPlaylistButton.Click += new System.EventHandler(this.addPlaylistButton_Click);
            // 
            // enableAudioPanel
            // 
            this.enableAudioPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(106)))));
            this.enableAudioPanel.Controls.Add(this.player);
            this.enableAudioPanel.Controls.Add(this.downloadProgressBar);
            this.enableAudioPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.enableAudioPanel.Location = new System.Drawing.Point(0, 608);
            this.enableAudioPanel.Name = "enableAudioPanel";
            this.enableAudioPanel.Size = new System.Drawing.Size(1004, 65);
            this.enableAudioPanel.TabIndex = 6;
            // 
            // player
            // 
            this.player.Dock = System.Windows.Forms.DockStyle.Top;
            this.player.Enabled = true;
            this.player.Location = new System.Drawing.Point(0, 10);
            this.player.Name = "player";
            this.player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("player.OcxState")));
            this.player.Size = new System.Drawing.Size(1004, 46);
            this.player.TabIndex = 1;
            // 
            // downloadProgressBar
            // 
            this.downloadProgressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(87)))), ((int)(((byte)(123)))));
            this.downloadProgressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.downloadProgressBar.Location = new System.Drawing.Point(0, 0);
            this.downloadProgressBar.Name = "downloadProgressBar";
            this.downloadProgressBar.Size = new System.Drawing.Size(1004, 10);
            this.downloadProgressBar.TabIndex = 0;
            // 
            // playlistPanel
            // 
            this.playlistPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(106)))));
            this.playlistPanel.Controls.Add(this.searchPlaylistTextBox);
            this.playlistPanel.Controls.Add(this.playlistListBox);
            this.playlistPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.playlistPanel.Location = new System.Drawing.Point(0, 97);
            this.playlistPanel.Name = "playlistPanel";
            this.playlistPanel.Size = new System.Drawing.Size(239, 511);
            this.playlistPanel.TabIndex = 7;
            // 
            // searchPlaylistTextBox
            // 
            this.searchPlaylistTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPlaylistTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchPlaylistTextBox.Location = new System.Drawing.Point(0, 0);
            this.searchPlaylistTextBox.Multiline = true;
            this.searchPlaylistTextBox.Name = "searchPlaylistTextBox";
            this.searchPlaylistTextBox.Size = new System.Drawing.Size(239, 31);
            this.searchPlaylistTextBox.TabIndex = 1;
            // 
            // playlistListBox
            // 
            this.playlistListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(106)))));
            this.playlistListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.playlistListBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.playlistListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playlistListBox.ForeColor = System.Drawing.SystemColors.Window;
            this.playlistListBox.FormattingEnabled = true;
            this.playlistListBox.ItemHeight = 20;
            this.playlistListBox.Location = new System.Drawing.Point(0, 31);
            this.playlistListBox.Name = "playlistListBox";
            this.playlistListBox.Size = new System.Drawing.Size(239, 480);
            this.playlistListBox.TabIndex = 0;
            this.playlistListBox.DoubleClick += new System.EventHandler(this.playlistListBox_DoubleClick);
            this.playlistListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.playlistListBox_KeyDown);
            this.playlistListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.playlistListBox_MouseDown);
            // 
            // trackListPanel
            // 
            this.trackListPanel.Controls.Add(this.searchTrackTextBox);
            this.trackListPanel.Controls.Add(this.trackListBox);
            this.trackListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackListPanel.Location = new System.Drawing.Point(239, 97);
            this.trackListPanel.Name = "trackListPanel";
            this.trackListPanel.Size = new System.Drawing.Size(765, 511);
            this.trackListPanel.TabIndex = 8;
            // 
            // searchTrackTextBox
            // 
            this.searchTrackTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchTrackTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchTrackTextBox.Location = new System.Drawing.Point(0, 0);
            this.searchTrackTextBox.Multiline = true;
            this.searchTrackTextBox.Name = "searchTrackTextBox";
            this.searchTrackTextBox.Size = new System.Drawing.Size(765, 31);
            this.searchTrackTextBox.TabIndex = 2;
            // 
            // trackListBox
            // 
            this.trackListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(87)))), ((int)(((byte)(123)))));
            this.trackListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trackListBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trackListBox.ForeColor = System.Drawing.SystemColors.Window;
            this.trackListBox.FormattingEnabled = true;
            this.trackListBox.ItemHeight = 20;
            this.trackListBox.Location = new System.Drawing.Point(0, 31);
            this.trackListBox.Name = "trackListBox";
            this.trackListBox.Size = new System.Drawing.Size(765, 480);
            this.trackListBox.TabIndex = 1;
            this.trackListBox.DoubleClick += new System.EventHandler(this.trackListBox_DoubleClick);
            this.trackListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trackListBox_KeyDown);
            this.trackListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackListBox_MouseDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(87)))), ((int)(((byte)(123)))));
            this.ClientSize = new System.Drawing.Size(1004, 673);
            this.Controls.Add(this.trackListPanel);
            this.Controls.Add(this.playlistPanel);
            this.Controls.Add(this.enableAudioPanel);
            this.Controls.Add(this.downloadPanel);
            this.Name = "MainForm";
            this.downloadPanel.ResumeLayout(false);
            this.downloadPanel.PerformLayout();
            this.enableAudioPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.playlistPanel.ResumeLayout(false);
            this.playlistPanel.PerformLayout();
            this.trackListPanel.ResumeLayout(false);
            this.trackListPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button downloadAudioButton;
        private System.Windows.Forms.TextBox linkInputTextBox;
        private System.Windows.Forms.Panel downloadPanel;
        private System.Windows.Forms.Panel enableAudioPanel;
        private System.Windows.Forms.Panel playlistPanel;
        private System.Windows.Forms.Panel trackListPanel;
        private System.Windows.Forms.Button addPlaylistButton;
        private System.Windows.Forms.ListBox trackListBox;
        private System.Windows.Forms.ProgressBar downloadProgressBar;
        private System.Windows.Forms.ListBox playlistListBox;
        private AxWMPLib.AxWindowsMediaPlayer player;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox searchPlaylistTextBox;
        private System.Windows.Forms.TextBox searchTrackTextBox;
    }
}

