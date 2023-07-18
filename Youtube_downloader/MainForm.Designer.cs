namespace Youtube_downloader {
    partial class MainForm {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
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
            this.playlistListView = new System.Windows.Forms.ListView();
            this.trackListPanel = new System.Windows.Forms.Panel();
            this.searchTrackTextBox = new System.Windows.Forms.TextBox();
            this.trackListView = new System.Windows.Forms.ListView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.downloadAudioButton.Location = new System.Drawing.Point(867, 0);
            this.downloadAudioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.downloadAudioButton.Name = "downloadAudioButton";
            this.downloadAudioButton.Size = new System.Drawing.Size(137, 97);
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
            this.linkInputTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.linkInputTextBox.Name = "linkInputTextBox";
            this.linkInputTextBox.Size = new System.Drawing.Size(625, 28);
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
            this.downloadPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.addPlaylistButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.enableAudioPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.enableAudioPanel.Name = "enableAudioPanel";
            this.enableAudioPanel.Size = new System.Drawing.Size(1004, 65);
            this.enableAudioPanel.TabIndex = 6;
            // 
            // player
            // 
            this.player.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.player.Enabled = true;
            this.player.Location = new System.Drawing.Point(0, 10);
            this.player.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.downloadProgressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.downloadProgressBar.Name = "downloadProgressBar";
            this.downloadProgressBar.Size = new System.Drawing.Size(1004, 10);
            this.downloadProgressBar.TabIndex = 0;
            // 
            // playlistPanel
            // 
            this.playlistPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(106)))));
            this.playlistPanel.Controls.Add(this.searchPlaylistTextBox);
            this.playlistPanel.Controls.Add(this.playlistListView);
            this.playlistPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.playlistPanel.Location = new System.Drawing.Point(0, 97);
            this.playlistPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.playlistPanel.Name = "playlistPanel";
            this.playlistPanel.Size = new System.Drawing.Size(239, 511);
            this.playlistPanel.TabIndex = 7;
            // 
            // searchPlaylistTextBox
            // 
            this.searchPlaylistTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPlaylistTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchPlaylistTextBox.Location = new System.Drawing.Point(0, 0);
            this.searchPlaylistTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchPlaylistTextBox.Multiline = true;
            this.searchPlaylistTextBox.Name = "searchPlaylistTextBox";
            this.searchPlaylistTextBox.Size = new System.Drawing.Size(239, 31);
            this.searchPlaylistTextBox.TabIndex = 1;
            // 
            // playlistListView
            // 
            this.playlistListView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.playlistListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playlistListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(106)))));
            this.playlistListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.playlistListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playlistListView.ForeColor = System.Drawing.SystemColors.Window;
            this.playlistListView.HideSelection = false;
            this.playlistListView.Location = new System.Drawing.Point(0, 38);
            this.playlistListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.playlistListView.Name = "playlistListView";
            this.playlistListView.Size = new System.Drawing.Size(239, 473);
            this.playlistListView.TabIndex = 0;
            this.playlistListView.UseCompatibleStateImageBehavior = false;
            this.playlistListView.View = System.Windows.Forms.View.List;
            this.playlistListView.DoubleClick += new System.EventHandler(this.playlistListView_DoubleClick);
            this.playlistListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.playlistListView_KeyDown);
            this.playlistListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.playlistListView_MouseDown);
            // 
            // trackListPanel
            // 
            this.trackListPanel.Controls.Add(this.searchTrackTextBox);
            this.trackListPanel.Controls.Add(this.trackListView);
            this.trackListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackListPanel.Location = new System.Drawing.Point(239, 97);
            this.trackListPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackListPanel.Name = "trackListPanel";
            this.trackListPanel.Size = new System.Drawing.Size(765, 511);
            this.trackListPanel.TabIndex = 8;
            // 
            // searchTrackTextBox
            // 
            this.searchTrackTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchTrackTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchTrackTextBox.Location = new System.Drawing.Point(0, 0);
            this.searchTrackTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchTrackTextBox.Multiline = true;
            this.searchTrackTextBox.Name = "searchTrackTextBox";
            this.searchTrackTextBox.Size = new System.Drawing.Size(765, 31);
            this.searchTrackTextBox.TabIndex = 2;
            // 
            // trackListView
            // 
            this.trackListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(87)))), ((int)(((byte)(123)))));
            this.trackListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trackListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.trackListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trackListView.ForeColor = System.Drawing.SystemColors.Window;
            this.trackListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.trackListView.HideSelection = false;
            this.trackListView.Location = new System.Drawing.Point(0, 38);
            this.trackListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackListView.MultiSelect = false;
            this.trackListView.Name = "trackListView";
            this.trackListView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackListView.Size = new System.Drawing.Size(765, 473);
            this.trackListView.TabIndex = 1;
            this.trackListView.UseCompatibleStateImageBehavior = false;
            this.trackListView.View = System.Windows.Forms.View.Details;
            this.trackListView.DoubleClick += new System.EventHandler(this.trackListView_DoubleClick);
            this.trackListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trackListView_KeyDown);
            this.trackListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackListView_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 765;
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.ListView trackListView;
        private System.Windows.Forms.ProgressBar downloadProgressBar;
        private System.Windows.Forms.ListView playlistListView;
        private AxWMPLib.AxWindowsMediaPlayer player;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox searchPlaylistTextBox;
        private System.Windows.Forms.TextBox searchTrackTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}
