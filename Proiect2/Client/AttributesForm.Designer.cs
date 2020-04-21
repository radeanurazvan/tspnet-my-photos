namespace MyPhotos.Gui.WindowsForms.Forms
{
    partial class AttributesForm
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
            this.AttributeNameInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AllowMultipleValuesCheckbox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.AttributesList = new System.Windows.Forms.ListBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AttributeNameInput
            // 
            this.AttributeNameInput.Location = new System.Drawing.Point(12, 88);
            this.AttributeNameInput.Name = "AttributeNameInput";
            this.AttributeNameInput.Size = new System.Drawing.Size(373, 22);
            this.AttributeNameInput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Create attribute";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(409, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "All attributes";
            // 
            // AllowMultipleValuesCheckbox
            // 
            this.AllowMultipleValuesCheckbox.AutoSize = true;
            this.AllowMultipleValuesCheckbox.Location = new System.Drawing.Point(12, 128);
            this.AllowMultipleValuesCheckbox.Name = "AllowMultipleValuesCheckbox";
            this.AllowMultipleValuesCheckbox.Size = new System.Drawing.Size(159, 21);
            this.AllowMultipleValuesCheckbox.TabIndex = 4;
            this.AllowMultipleValuesCheckbox.Text = "Allow multiple values";
            this.AllowMultipleValuesCheckbox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Name";
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(12, 180);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(373, 36);
            this.SaveBtn.TabIndex = 6;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            // 
            // AttributesList
            // 
            this.AttributesList.FormattingEnabled = true;
            this.AttributesList.ItemHeight = 16;
            this.AttributesList.Location = new System.Drawing.Point(414, 81);
            this.AttributesList.Name = "AttributesList";
            this.AttributesList.Size = new System.Drawing.Size(359, 340);
            this.AttributesList.TabIndex = 7;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Location = new System.Drawing.Point(658, 24);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(115, 34);
            this.DeleteButton.TabIndex = 8;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // AttributesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AttributesList);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AllowMultipleValuesCheckbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AttributeNameInput);
            this.Name = "AttributesForm";
            this.Text = "AttributesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox AttributeNameInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox AllowMultipleValuesCheckbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.ListBox AttributesList;
        private System.Windows.Forms.Button DeleteButton;
    }
}