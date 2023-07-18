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
            this.searchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchPlaylistListBox
            // 
            this.searchPlaylistListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(106)))));
            this.searchPlaylistListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchPlaylistListBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.searchPlaylistListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchPlaylistListBox.ForeColor = System.Drawing.SystemColors.Window;
            this.searchPlaylistListBox.FormattingEnabled = true;
            this.searchPlaylistListBox.ItemHeight = 18;
            this.searchPlaylistListBox.Location = new System.Drawing.Point(0, 40);
            this.searchPlaylistListBox.Name = "searchPlaylistListBox";
            this.searchPlaylistListBox.Size = new System.Drawing.Size(289, 342);
            this.searchPlaylistListBox.TabIndex = 0;
            // 
            // playlistSearchTextBox
            // 
            this.playlistSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playlistSearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playlistSearchTextBox.Location = new System.Drawing.Point(0, 0);
            this.playlistSearchTextBox.Multiline = true;
            this.playlistSearchTextBox.Name = "playlistSearchTextBox";
            this.playlistSearchTextBox.Size = new System.Drawing.Size(227, 40);
            this.playlistSearchTextBox.TabIndex = 1;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(39)))), ((int)(((byte)(111)))));
            this.searchButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(74)))), ((int)(((byte)(0)))));
            this.searchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(141)))), ((int)(((byte)(213)))));
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchButton.ForeColor = System.Drawing.SystemColors.Window;
            this.searchButton.Location = new System.Drawing.Point(228, 0);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(61, 40);
            this.searchButton.TabIndex = 2;
            this.searchButton.UseVisualStyleBackColor = false;
            // 
            // SelectingPlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(106)))));
            this.ClientSize = new System.Drawing.Size(289, 382);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.playlistSearchTextBox);
            this.Controls.Add(this.searchPlaylistListBox);
            this.Name = "SelectingPlaylistForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox searchPlaylistListBox;
        private System.Windows.Forms.TextBox playlistSearchTextBox;
        private System.Windows.Forms.Button searchButton;
    }
}