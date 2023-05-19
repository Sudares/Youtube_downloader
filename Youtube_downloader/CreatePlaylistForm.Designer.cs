namespace Youtube_downloader {
    partial class CreatePlaylistForm {
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
            this.createNewPlaylistButton = new System.Windows.Forms.Button();
            this.playlistNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // playlistNameLabel
            // 
            this.playlistNameLabel.AutoSize = true;
            this.playlistNameLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.playlistNameLabel.Location = new System.Drawing.Point(40, 96);
            this.playlistNameLabel.Name = "playlistNameLabel";
            this.playlistNameLabel.Size = new System.Drawing.Size(146, 16);
            this.playlistNameLabel.TabIndex = 0;
            this.playlistNameLabel.Text = "Название плейлиста";
            // 
            // createNewPlaylistButton
            // 
            this.createNewPlaylistButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(39)))), ((int)(((byte)(111)))));
            this.createNewPlaylistButton.ForeColor = System.Drawing.SystemColors.Window;
            this.createNewPlaylistButton.Location = new System.Drawing.Point(567, 200);
            this.createNewPlaylistButton.Name = "createNewPlaylistButton";
            this.createNewPlaylistButton.Size = new System.Drawing.Size(207, 50);
            this.createNewPlaylistButton.TabIndex = 1;
            this.createNewPlaylistButton.Text = "Добавить";
            this.createNewPlaylistButton.UseVisualStyleBackColor = false;
            this.createNewPlaylistButton.Click += new System.EventHandler(this.createNewPlaylistButton_Click);
            // 
            // playlistNameTextBox
            // 
            this.playlistNameTextBox.Location = new System.Drawing.Point(220, 93);
            this.playlistNameTextBox.Name = "playlistNameTextBox";
            this.playlistNameTextBox.Size = new System.Drawing.Size(504, 22);
            this.playlistNameTextBox.TabIndex = 2;
            // 
            // CreatePlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(106)))));
            this.ClientSize = new System.Drawing.Size(800, 276);
            this.Controls.Add(this.playlistNameTextBox);
            this.Controls.Add(this.createNewPlaylistButton);
            this.Controls.Add(this.playlistNameLabel);
            this.Name = "CreatePlaylistForm";
            this.Text = "CreatePlaylistForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label playlistNameLabel;
        private System.Windows.Forms.Button createNewPlaylistButton;
        private System.Windows.Forms.TextBox playlistNameTextBox;
    }
}