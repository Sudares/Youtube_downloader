namespace Youtube_downloader {
    partial class PlaylistInfoForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.playlistNameLabel = new System.Windows.Forms.Label();
            this.urlLabel = new System.Windows.Forms.Label();
            this.playlistUrlLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // playlistNameLabel
            // 
            this.playlistNameLabel.AutoSize = true;
            this.playlistNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playlistNameLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.playlistNameLabel.Location = new System.Drawing.Point(290, 21);
            this.playlistNameLabel.Name = "playlistNameLabel";
            this.playlistNameLabel.Size = new System.Drawing.Size(196, 24);
            this.playlistNameLabel.TabIndex = 0;
            this.playlistNameLabel.Text = "Название плейлиста";
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.urlLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.urlLabel.Location = new System.Drawing.Point(290, 103);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(190, 24);
            this.urlLabel.TabIndex = 1;
            this.urlLabel.Text = "Ссылка на плейлист";
            // 
            // playlistUrlLinkLabel
            // 
            this.playlistUrlLinkLabel.AutoSize = true;
            this.playlistUrlLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playlistUrlLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.playlistUrlLinkLabel.Location = new System.Drawing.Point(290, 172);
            this.playlistUrlLinkLabel.Name = "playlistUrlLinkLabel";
            this.playlistUrlLinkLabel.Size = new System.Drawing.Size(168, 24);
            this.playlistUrlLinkLabel.TabIndex = 4;
            this.playlistUrlLinkLabel.TabStop = true;
            this.playlistUrlLinkLabel.Text = "playlistUrlLinkLabel";
            // 
            // PlaylistInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(106)))));
            this.ClientSize = new System.Drawing.Size(800, 359);
            this.Controls.Add(this.playlistUrlLinkLabel);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.playlistNameLabel);
            this.Name = "PlaylistInfoForm";
            this.Text = "PlaylistInfoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label playlistNameLabel;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.LinkLabel playlistUrlLinkLabel;
    }
}