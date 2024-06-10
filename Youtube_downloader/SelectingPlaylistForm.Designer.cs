namespace Youtube_downloader {
    partial class SelectingPlaylistForm {
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
            this.searchPlaylistListBox = new System.Windows.Forms.ListBox();
            this.playlistSearchTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // searchPlaylistListBox
            // 
            this.searchPlaylistListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchPlaylistListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(106)))));
            this.searchPlaylistListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchPlaylistListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchPlaylistListBox.ForeColor = System.Drawing.SystemColors.Window;
            this.searchPlaylistListBox.FormattingEnabled = true;
            this.searchPlaylistListBox.ItemHeight = 18;
            this.searchPlaylistListBox.Location = new System.Drawing.Point(0, 40);
            this.searchPlaylistListBox.Name = "searchPlaylistListBox";
            this.searchPlaylistListBox.Size = new System.Drawing.Size(375, 342);
            this.searchPlaylistListBox.TabIndex = 0;
            this.searchPlaylistListBox.Click += new System.EventHandler(this.searchPlaylistListBox_Click);
            // 
            // playlistSearchTextBox
            // 
            this.playlistSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playlistSearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playlistSearchTextBox.Location = new System.Drawing.Point(0, 0);
            this.playlistSearchTextBox.Multiline = true;
            this.playlistSearchTextBox.Name = "playlistSearchTextBox";
            this.playlistSearchTextBox.Size = new System.Drawing.Size(375, 40);
            this.playlistSearchTextBox.TabIndex = 1;
            this.playlistSearchTextBox.TextChanged += new System.EventHandler(this.playlistSearchTextBox_TextChanged);
            // 
            // SelectingPlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(106)))));
            this.ClientSize = new System.Drawing.Size(375, 398);
            this.Controls.Add(this.playlistSearchTextBox);
            this.Controls.Add(this.searchPlaylistListBox);
            this.Name = "SelectingPlaylistForm";
            this.Text = "Переместить в...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox searchPlaylistListBox;
        private System.Windows.Forms.TextBox playlistSearchTextBox;
    }
}