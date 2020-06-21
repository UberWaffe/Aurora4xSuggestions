namespace AuroraUIMockup.FlexibleComponentDesign
{
    partial class FlexibleComponentDesignUI
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
            this.comboBox_Empire = new System.Windows.Forms.ComboBox();
            this.comboBox_ComponentType = new System.Windows.Forms.ComboBox();
            this.comboBox_MilitaryOrCommercial = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.infoButton_MilitaryOrCommercial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_Empire
            // 
            this.comboBox_Empire.FormattingEnabled = true;
            this.comboBox_Empire.Location = new System.Drawing.Point(12, 12);
            this.comboBox_Empire.Name = "comboBox_Empire";
            this.comboBox_Empire.Size = new System.Drawing.Size(270, 21);
            this.comboBox_Empire.TabIndex = 0;
            // 
            // comboBox_ComponentType
            // 
            this.comboBox_ComponentType.FormattingEnabled = true;
            this.comboBox_ComponentType.Location = new System.Drawing.Point(12, 39);
            this.comboBox_ComponentType.Name = "comboBox_ComponentType";
            this.comboBox_ComponentType.Size = new System.Drawing.Size(270, 21);
            this.comboBox_ComponentType.TabIndex = 1;
            // 
            // comboBox_MilitaryOrCommercial
            // 
            this.comboBox_MilitaryOrCommercial.FormattingEnabled = true;
            this.comboBox_MilitaryOrCommercial.Location = new System.Drawing.Point(12, 91);
            this.comboBox_MilitaryOrCommercial.Name = "comboBox_MilitaryOrCommercial";
            this.comboBox_MilitaryOrCommercial.Size = new System.Drawing.Size(270, 21);
            this.comboBox_MilitaryOrCommercial.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(351, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(700, 20);
            this.textBox1.TabIndex = 3;
            // 
            // infoButton_MilitaryOrCommercial
            // 
            this.infoButton_MilitaryOrCommercial.Location = new System.Drawing.Point(288, 91);
            this.infoButton_MilitaryOrCommercial.Name = "infoButton_MilitaryOrCommercial";
            this.infoButton_MilitaryOrCommercial.Size = new System.Drawing.Size(45, 23);
            this.infoButton_MilitaryOrCommercial.TabIndex = 4;
            this.infoButton_MilitaryOrCommercial.Text = "Info";
            this.infoButton_MilitaryOrCommercial.UseVisualStyleBackColor = true;
            // 
            // FlexibleComponentDesignUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 655);
            this.Controls.Add(this.infoButton_MilitaryOrCommercial);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox_MilitaryOrCommercial);
            this.Controls.Add(this.comboBox_ComponentType);
            this.Controls.Add(this.comboBox_Empire);
            this.Name = "FlexibleComponentDesignUI";
            this.Text = "FlexibleComponentDesignUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Empire;
        private System.Windows.Forms.ComboBox comboBox_ComponentType;
        private System.Windows.Forms.ComboBox comboBox_MilitaryOrCommercial;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button infoButton_MilitaryOrCommercial;
    }
}