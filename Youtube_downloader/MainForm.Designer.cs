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
            this.downloadAudioButton = new System.Windows.Forms.Button();
            this.linkText = new System.Windows.Forms.Label();
            this.linkInputTextBox = new System.Windows.Forms.TextBox();
            this.downloadPanel = new System.Windows.Forms.Panel();
            this.addPlaylistButton = new System.Windows.Forms.Button();
            this.enableAudioPanel = new System.Windows.Forms.Panel();
            this.playlistPanel = new System.Windows.Forms.Panel();
            this.trackListPanel = new System.Windows.Forms.Panel();
            this.trackListBox = new System.Windows.Forms.ListBox();
            this.audioProgressBar = new System.Windows.Forms.ProgressBar();
            this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.playlistListBox = new System.Windows.Forms.ListBox();
            this.downloadPanel.SuspendLayout();
            this.enableAudioPanel.SuspendLayout();
            this.playlistPanel.SuspendLayout();
            this.trackListPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // downloadAudioButton
            // 
            this.downloadAudioButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(39)))), ((int)(((byte)(111)))));
            this.downloadAudioButton.FlatAppearance.BorderSize = 0;
            this.downloadAudioButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(74)))), ((int)(((byte)(0)))));
            this.downloadAudioButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(141)))), ((int)(((byte)(213)))));
            this.downloadAudioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadAudioButton.ForeColor = System.Drawing.SystemColors.Window;
            this.downloadAudioButton.Location = new System.Drawing.Point(744, 71);
            this.downloadAudioButton.Name = "downloadAudioButton";
            this.downloadAudioButton.Size = new System.Drawing.Size(75, 23);
            this.downloadAudioButton.TabIndex = 0;
            this.downloadAudioButton.Text = "Скачать";
            this.downloadAudioButton.UseVisualStyleBackColor = false;
            this.downloadAudioButton.Click += new System.EventHandler(this.downloadAudioButton_Click);
            // 
            // linkText
            // 
            this.linkText.AutoSize = true;
            this.linkText.ForeColor = System.Drawing.SystemColors.Window;
            this.linkText.Location = new System.Drawing.Point(198, 9);
            this.linkText.Name = "linkText";
            this.linkText.Size = new System.Drawing.Size(119, 16);
            this.linkText.TabIndex = 1;
            this.linkText.Text = "Добавить ссылку";
            // 
            // linkInputTextBox
            // 
            this.linkInputTextBox.Location = new System.Drawing.Point(201, 43);
            this.linkInputTextBox.Name = "linkInputTextBox";
            this.linkInputTextBox.Size = new System.Drawing.Size(618, 22);
            this.linkInputTextBox.TabIndex = 3;
            // 
            // downloadPanel
            // 
            this.downloadPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(106)))));
            this.downloadPanel.Controls.Add(this.addPlaylistButton);
            this.downloadPanel.Controls.Add(this.linkText);
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
            this.addPlaylistButton.FlatAppearance.BorderSize = 0;
            this.addPlaylistButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(74)))), ((int)(((byte)(0)))));
            this.addPlaylistButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(141)))), ((int)(((byte)(213)))));
            this.addPlaylistButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPlaylistButton.ForeColor = System.Drawing.SystemColors.Window;
            this.addPlaylistButton.Location = new System.Drawing.Point(28, 30);
            this.addPlaylistButton.Name = "addPlaylistButton";
            this.addPlaylistButton.Size = new System.Drawing.Size(138, 48);
            this.addPlaylistButton.TabIndex = 4;
            this.addPlaylistButton.Text = "Добавить плейлист";
            this.addPlaylistButton.UseVisualStyleBackColor = false;
            // 
            // enableAudioPanel
            // 
            this.enableAudioPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(106)))));
            this.enableAudioPanel.Controls.Add(this.downloadProgressBar);
            this.enableAudioPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.enableAudioPanel.Location = new System.Drawing.Point(0, 575);
            this.enableAudioPanel.Name = "enableAudioPanel";
            this.enableAudioPanel.Size = new System.Drawing.Size(1004, 94);
            this.enableAudioPanel.TabIndex = 6;
            // 
            // playlistPanel
            // 
            this.playlistPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(106)))));
            this.playlistPanel.Controls.Add(this.playlistListBox);
            this.playlistPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.playlistPanel.Location = new System.Drawing.Point(0, 97);
            this.playlistPanel.Name = "playlistPanel";
            this.playlistPanel.Size = new System.Drawing.Size(194, 478);
            this.playlistPanel.TabIndex = 7;
            // 
            // trackListPanel
            // 
            this.trackListPanel.Controls.Add(this.trackListBox);
            this.trackListPanel.Controls.Add(this.audioProgressBar);
            this.trackListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackListPanel.Location = new System.Drawing.Point(194, 97);
            this.trackListPanel.Name = "trackListPanel";
            this.trackListPanel.Size = new System.Drawing.Size(810, 478);
            this.trackListPanel.TabIndex = 8;
            // 
            // trackListBox
            // 
            this.trackListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(87)))), ((int)(((byte)(123)))));
            this.trackListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackListBox.ForeColor = System.Drawing.SystemColors.Window;
            this.trackListBox.FormattingEnabled = true;
            this.trackListBox.ItemHeight = 16;
            this.trackListBox.Location = new System.Drawing.Point(0, 0);
            this.trackListBox.Name = "trackListBox";
            this.trackListBox.Size = new System.Drawing.Size(810, 478);
            this.trackListBox.TabIndex = 1;
            // 
            // audioProgressBar
            // 
            this.audioProgressBar.Location = new System.Drawing.Point(0, 0);
            this.audioProgressBar.Name = "audioProgressBar";
            this.audioProgressBar.Size = new System.Drawing.Size(810, 23);
            this.audioProgressBar.TabIndex = 0;
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
            // playlistListBox
            // 
            this.playlistListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(106)))));
            this.playlistListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playlistListBox.ForeColor = System.Drawing.SystemColors.Window;
            this.playlistListBox.FormattingEnabled = true;
            this.playlistListBox.ItemHeight = 16;
            this.playlistListBox.Location = new System.Drawing.Point(0, 0);
            this.playlistListBox.Name = "playlistListBox";
            this.playlistListBox.Size = new System.Drawing.Size(194, 478);
            this.playlistListBox.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(87)))), ((int)(((byte)(123)))));
            this.ClientSize = new System.Drawing.Size(1004, 669);
            this.Controls.Add(this.trackListPanel);
            this.Controls.Add(this.playlistPanel);
            this.Controls.Add(this.enableAudioPanel);
            this.Controls.Add(this.downloadPanel);
            this.Name = "MainForm";
            this.downloadPanel.ResumeLayout(false);
            this.downloadPanel.PerformLayout();
            this.enableAudioPanel.ResumeLayout(false);
            this.playlistPanel.ResumeLayout(false);
            this.trackListPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button downloadAudioButton;
        private System.Windows.Forms.Label linkText;
        private System.Windows.Forms.TextBox linkInputTextBox;
        private System.Windows.Forms.Panel downloadPanel;
        private System.Windows.Forms.Panel enableAudioPanel;
        private System.Windows.Forms.Panel playlistPanel;
        private System.Windows.Forms.Panel trackListPanel;
        private System.Windows.Forms.Button addPlaylistButton;
        private System.Windows.Forms.ProgressBar audioProgressBar;
        private System.Windows.Forms.ListBox trackListBox;
        private System.Windows.Forms.ProgressBar downloadProgressBar;
        private System.Windows.Forms.ListBox playlistListBox;
    }
}

