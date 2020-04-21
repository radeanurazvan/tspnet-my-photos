namespace MyPhotos.Gui.WindowsForms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PhotosBtn = new System.Windows.Forms.Button();
            this.VideosBtn = new System.Windows.Forms.Button();
            this.AttributesBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PhotosBtn
            // 
            this.PhotosBtn.Location = new System.Drawing.Point(260, 124);
            this.PhotosBtn.Name = "PhotosBtn";
            this.PhotosBtn.Size = new System.Drawing.Size(261, 46);
            this.PhotosBtn.TabIndex = 0;
            this.PhotosBtn.Text = "Photos";
            this.PhotosBtn.UseVisualStyleBackColor = true;
            // 
            // VideosBtn
            // 
            this.VideosBtn.Location = new System.Drawing.Point(260, 187);
            this.VideosBtn.Name = "VideosBtn";
            this.VideosBtn.Size = new System.Drawing.Size(261, 46);
            this.VideosBtn.TabIndex = 1;
            this.VideosBtn.Text = "Videos";
            this.VideosBtn.UseVisualStyleBackColor = true;
            // 
            // AttributesBtn
            // 
            this.AttributesBtn.Location = new System.Drawing.Point(260, 254);
            this.AttributesBtn.Name = "AttributesBtn";
            this.AttributesBtn.Size = new System.Drawing.Size(261, 46);
            this.AttributesBtn.TabIndex = 2;
            this.AttributesBtn.Text = "Attributes";
            this.AttributesBtn.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AttributesBtn);
            this.Controls.Add(this.VideosBtn);
            this.Controls.Add(this.PhotosBtn);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PhotosBtn;
        private System.Windows.Forms.Button VideosBtn;
        private System.Windows.Forms.Button AttributesBtn;
    }
}