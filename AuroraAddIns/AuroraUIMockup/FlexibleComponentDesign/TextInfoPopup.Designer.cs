namespace AuroraUIMockup.FlexibleComponentDesign
{
    partial class TextInfoPopup
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
            this.text_TechDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // text_TechDescription
            // 
            this.text_TechDescription.AccessibleDescription = "Shows the description of the technology";
            this.text_TechDescription.AccessibleName = "Tech Description";
            this.text_TechDescription.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.text_TechDescription.Location = new System.Drawing.Point(13, 13);
            this.text_TechDescription.Multiline = true;
            this.text_TechDescription.Name = "text_TechDescription";
            this.text_TechDescription.ReadOnly = true;
            this.text_TechDescription.Size = new System.Drawing.Size(532, 392);
            this.text_TechDescription.TabIndex = 0;
            // 
            // TextInfoPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 417);
            this.Controls.Add(this.text_TechDescription);
            this.Name = "TextInfoPopup";
            this.Text = "TechInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text_TechDescription;
    }
}