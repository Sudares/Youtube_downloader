namespace Youtube_downloader {
    partial class TrackInfoForm {
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
            this.trackNameLabel = new System.Windows.Forms.Label();
            this.authorLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackUrlLinkLabel = new System.Windows.Forms.LinkLabel();
            this.authorUrlLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // trackNameLabel
            // 
            this.trackNameLabel.AutoSize = true;
            this.trackNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trackNameLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.trackNameLabel.Location = new System.Drawing.Point(290, 21);
            this.trackNameLabel.Name = "trackNameLabel";
            this.trackNameLabel.Size = new System.Drawing.Size(156, 24);
            this.trackNameLabel.TabIndex = 1;
            this.trackNameLabel.Text = "Название песни";
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authorLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.authorLabel.Location = new System.Drawing.Point(290, 89);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(66, 24);
            this.authorLabel.TabIndex = 2;
            this.authorLabel.Text = "Автор";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(290, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ссылка на песню";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(290, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ссылка на автора";
            // 
            // trackUrlLinkLabel
            // 
            this.trackUrlLinkLabel.AutoSize = true;
            this.trackUrlLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trackUrlLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.trackUrlLinkLabel.Location = new System.Drawing.Point(290, 185);
            this.trackUrlLinkLabel.Name = "trackUrlLinkLabel";
            this.trackUrlLinkLabel.Size = new System.Drawing.Size(152, 24);
            this.trackUrlLinkLabel.TabIndex = 5;
            this.trackUrlLinkLabel.TabStop = true;
            this.trackUrlLinkLabel.Text = "trackUrlLinkLabel";
            // 
            // authorUrlLinkLabel
            // 
            this.authorUrlLinkLabel.AutoSize = true;
            this.authorUrlLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authorUrlLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.authorUrlLinkLabel.Location = new System.Drawing.Point(290, 280);
            this.authorUrlLinkLabel.Name = "authorUrlLinkLabel";
            this.authorUrlLinkLabel.Size = new System.Drawing.Size(166, 24);
            this.authorUrlLinkLabel.TabIndex = 6;
            this.authorUrlLinkLabel.TabStop = true;
            this.authorUrlLinkLabel.Text = "authorUrlLinkLabel";
            // 
            // TrackInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(106)))));
            this.ClientSize = new System.Drawing.Size(800, 359);
            this.Controls.Add(this.authorUrlLinkLabel);
            this.Controls.Add(this.trackUrlLinkLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.trackNameLabel);
            this.Name = "TrackInfoForm";
            this.Text = "TrackInfoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label trackNameLabel;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel trackUrlLinkLabel;
        private System.Windows.Forms.LinkLabel authorUrlLinkLabel;
    }
}