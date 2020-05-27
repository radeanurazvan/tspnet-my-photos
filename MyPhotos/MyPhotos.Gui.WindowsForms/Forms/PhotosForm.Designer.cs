namespace MyPhotos.Gui.WindowsForms.Forms
{
    partial class PhotosForm
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
            this.PhotosList = new System.Windows.Forms.ListBox();
            this.AllPhotosLabel = new System.Windows.Forms.Label();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.AddAttributeBtn = new System.Windows.Forms.Button();
            this.ChangeTitleBtn = new System.Windows.Forms.Button();
            this.AddPhotoBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PhotosList
            // 
            this.PhotosList.FormattingEnabled = true;
            this.PhotosList.ItemHeight = 16;
            this.PhotosList.Location = new System.Drawing.Point(12, 74);
            this.PhotosList.Name = "PhotosList";
            this.PhotosList.Size = new System.Drawing.Size(776, 356);
            this.PhotosList.TabIndex = 1;
            // 
            // AllPhotosLabel
            // 
            this.AllPhotosLabel.AutoSize = true;
            this.AllPhotosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllPhotosLabel.Location = new System.Drawing.Point(12, 25);
            this.AllPhotosLabel.Name = "AllPhotosLabel";
            this.AllPhotosLabel.Size = new System.Drawing.Size(151, 32);
            this.AllPhotosLabel.TabIndex = 2;
            this.AllPhotosLabel.Text = "All photos";
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Enabled = false;
            this.DeleteBtn.Location = new System.Drawing.Point(674, 30);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(114, 32);
            this.DeleteBtn.TabIndex = 3;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            // 
            // FileDialog
            // 
            this.FileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif;" +
    " *.png";
            // 
            // AddAttributeBtn
            // 
            this.AddAttributeBtn.Enabled = false;
            this.AddAttributeBtn.Location = new System.Drawing.Point(536, 30);
            this.AddAttributeBtn.Name = "AddAttributeBtn";
            this.AddAttributeBtn.Size = new System.Drawing.Size(114, 32);
            this.AddAttributeBtn.TabIndex = 4;
            this.AddAttributeBtn.Text = "Add attribute";
            this.AddAttributeBtn.UseVisualStyleBackColor = true;
            // 
            // ChangeTitleBtn
            // 
            this.ChangeTitleBtn.Enabled = false;
            this.ChangeTitleBtn.Location = new System.Drawing.Point(404, 30);
            this.ChangeTitleBtn.Name = "ChangeTitleBtn";
            this.ChangeTitleBtn.Size = new System.Drawing.Size(114, 32);
            this.ChangeTitleBtn.TabIndex = 4;
            this.ChangeTitleBtn.Text = "Change title";
            this.ChangeTitleBtn.UseVisualStyleBackColor = true;
            // 
            // AddPhotoBtn
            // 
            this.AddPhotoBtn.Location = new System.Drawing.Point(271, 30);
            this.AddPhotoBtn.Name = "AddPhotoBtn";
            this.AddPhotoBtn.Size = new System.Drawing.Size(114, 32);
            this.AddPhotoBtn.TabIndex = 4;
            this.AddPhotoBtn.Text = "Add photo";
            this.AddPhotoBtn.UseVisualStyleBackColor = true;
            // 
            // PhotosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddPhotoBtn);
            this.Controls.Add(this.ChangeTitleBtn);
            this.Controls.Add(this.AddAttributeBtn);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.AllPhotosLabel);
            this.Controls.Add(this.PhotosList);
            this.Name = "PhotosForm";
            this.Text = "PhotosForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox PhotosList;
        private System.Windows.Forms.Label AllPhotosLabel;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.OpenFileDialog FileDialog;
        private System.Windows.Forms.Button AddAttributeBtn;
        private System.Windows.Forms.Button ChangeTitleBtn;
        private System.Windows.Forms.Button AddPhotoBtn;
    }
}