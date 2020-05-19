namespace AuroraUIMockup.TerraformingTargets
{
    partial class TerraformingTargetsUI
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
            this.listView_TerraformTargets = new System.Windows.Forms.ListView();
            this.comboBox_ChooseTargetElement = new System.Windows.Forms.ComboBox();
            this.button_SetTarget = new System.Windows.Forms.Button();
            this.button_DeleteTarget = new System.Windows.Forms.Button();
            this.textBox_TargetAmount = new System.Windows.Forms.TextBox();
            this.button_SimulateGameTick = new System.Windows.Forms.Button();
            this.button_ToggleSentences = new System.Windows.Forms.Button();
            this.textBox_SimulateSeconds = new System.Windows.Forms.TextBox();
            this.textBox_SimulateAtmPerAnnum = new System.Windows.Forms.TextBox();
            this.TargetElement = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView_SimulateCurrentElements = new System.Windows.Forms.ListView();
            this.Gas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView_TerraformTargets
            // 
            this.listView_TerraformTargets.AccessibleDescription = "List of all set terraforming targets for this population";
            this.listView_TerraformTargets.AccessibleName = "Current terraforming targets";
            this.listView_TerraformTargets.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView_TerraformTargets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TargetElement});
            this.listView_TerraformTargets.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_TerraformTargets.Location = new System.Drawing.Point(12, 122);
            this.listView_TerraformTargets.Name = "listView_TerraformTargets";
            this.listView_TerraformTargets.Size = new System.Drawing.Size(260, 405);
            this.listView_TerraformTargets.TabIndex = 5;
            this.listView_TerraformTargets.UseCompatibleStateImageBehavior = false;
            // 
            // comboBox_ChooseTargetElement
            // 
            this.comboBox_ChooseTargetElement.AccessibleDescription = "Select an element to setup or modify a target for";
            this.comboBox_ChooseTargetElement.AccessibleName = "Terraform target element";
            this.comboBox_ChooseTargetElement.FormattingEnabled = true;
            this.comboBox_ChooseTargetElement.Location = new System.Drawing.Point(13, 65);
            this.comboBox_ChooseTargetElement.Name = "comboBox_ChooseTargetElement";
            this.comboBox_ChooseTargetElement.Size = new System.Drawing.Size(151, 21);
            this.comboBox_ChooseTargetElement.TabIndex = 1;
            // 
            // button_SetTarget
            // 
            this.button_SetTarget.AccessibleDescription = "Sets target for selected element";
            this.button_SetTarget.AccessibleName = "Set target";
            this.button_SetTarget.Location = new System.Drawing.Point(12, 93);
            this.button_SetTarget.Name = "button_SetTarget";
            this.button_SetTarget.Size = new System.Drawing.Size(112, 23);
            this.button_SetTarget.TabIndex = 3;
            this.button_SetTarget.Text = "Set";
            this.button_SetTarget.UseVisualStyleBackColor = true;
            this.button_SetTarget.Click += new System.EventHandler(this.button_SetTarget_Click);
            // 
            // button_DeleteTarget
            // 
            this.button_DeleteTarget.AccessibleDescription = "Deletes target for selected element";
            this.button_DeleteTarget.AccessibleName = "Delete target";
            this.button_DeleteTarget.Location = new System.Drawing.Point(170, 93);
            this.button_DeleteTarget.Name = "button_DeleteTarget";
            this.button_DeleteTarget.Size = new System.Drawing.Size(102, 23);
            this.button_DeleteTarget.TabIndex = 4;
            this.button_DeleteTarget.Text = "Delete";
            this.button_DeleteTarget.UseVisualStyleBackColor = true;
            this.button_DeleteTarget.Click += new System.EventHandler(this.button_DeleteTarget_Click);
            // 
            // textBox_TargetAmount
            // 
            this.textBox_TargetAmount.AccessibleDescription = "Amount to target for the selected element";
            this.textBox_TargetAmount.AccessibleName = "Target amount";
            this.textBox_TargetAmount.BackColor = System.Drawing.Color.White;
            this.textBox_TargetAmount.Location = new System.Drawing.Point(170, 65);
            this.textBox_TargetAmount.Name = "textBox_TargetAmount";
            this.textBox_TargetAmount.Size = new System.Drawing.Size(102, 20);
            this.textBox_TargetAmount.TabIndex = 2;
            // 
            // button_SimulateGameTick
            // 
            this.button_SimulateGameTick.AccessibleDescription = "Simulate game ";
            this.button_SimulateGameTick.AccessibleName = "Simulate";
            this.button_SimulateGameTick.Location = new System.Drawing.Point(566, 122);
            this.button_SimulateGameTick.Name = "button_SimulateGameTick";
            this.button_SimulateGameTick.Size = new System.Drawing.Size(145, 23);
            this.button_SimulateGameTick.TabIndex = 101;
            this.button_SimulateGameTick.Text = "Simulate";
            this.button_SimulateGameTick.UseVisualStyleBackColor = true;
            this.button_SimulateGameTick.Click += new System.EventHandler(this.button_SimulateGameTick_Click);
            // 
            // button_ToggleSentences
            // 
            this.button_ToggleSentences.Location = new System.Drawing.Point(566, 362);
            this.button_ToggleSentences.Name = "button_ToggleSentences";
            this.button_ToggleSentences.Size = new System.Drawing.Size(145, 23);
            this.button_ToggleSentences.TabIndex = 102;
            this.button_ToggleSentences.Text = "Toggle List Type";
            this.button_ToggleSentences.UseVisualStyleBackColor = true;
            this.button_ToggleSentences.Click += new System.EventHandler(this.button_ToggleSentences_Click);
            // 
            // textBox_SimulateSeconds
            // 
            this.textBox_SimulateSeconds.Location = new System.Drawing.Point(566, 65);
            this.textBox_SimulateSeconds.Name = "textBox_SimulateSeconds";
            this.textBox_SimulateSeconds.Size = new System.Drawing.Size(100, 20);
            this.textBox_SimulateSeconds.TabIndex = 103;
            this.textBox_SimulateSeconds.TextChanged += new System.EventHandler(this.textBox_SimulateSeconds_TextChanged);
            // 
            // textBox_SimulateAtmPerAnnum
            // 
            this.textBox_SimulateAtmPerAnnum.Location = new System.Drawing.Point(566, 92);
            this.textBox_SimulateAtmPerAnnum.Name = "textBox_SimulateAtmPerAnnum";
            this.textBox_SimulateAtmPerAnnum.Size = new System.Drawing.Size(100, 20);
            this.textBox_SimulateAtmPerAnnum.TabIndex = 104;
            // 
            // TargetElement
            // 
            this.TargetElement.Text = "Target Gas";
            // 
            // listView_SimulateCurrentElements
            // 
            this.listView_SimulateCurrentElements.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Gas,
            this.Amount});
            this.listView_SimulateCurrentElements.Location = new System.Drawing.Point(362, 122);
            this.listView_SimulateCurrentElements.Name = "listView_SimulateCurrentElements";
            this.listView_SimulateCurrentElements.Size = new System.Drawing.Size(142, 405);
            this.listView_SimulateCurrentElements.TabIndex = 105;
            this.listView_SimulateCurrentElements.UseCompatibleStateImageBehavior = false;
            // 
            // Gas
            // 
            this.Gas.Text = "Gas";
            // 
            // Amount
            // 
            this.Amount.Text = "Amount";
            this.Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TerraformingTargetsUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(805, 576);
            this.Controls.Add(this.listView_SimulateCurrentElements);
            this.Controls.Add(this.textBox_SimulateAtmPerAnnum);
            this.Controls.Add(this.textBox_SimulateSeconds);
            this.Controls.Add(this.button_ToggleSentences);
            this.Controls.Add(this.button_SimulateGameTick);
            this.Controls.Add(this.textBox_TargetAmount);
            this.Controls.Add(this.button_DeleteTarget);
            this.Controls.Add(this.button_SetTarget);
            this.Controls.Add(this.comboBox_ChooseTargetElement);
            this.Controls.Add(this.listView_TerraformTargets);
            this.Name = "TerraformingTargetsUI";
            this.Text = "TerraformingTargetsUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_TerraformTargets;
        private System.Windows.Forms.ComboBox comboBox_ChooseTargetElement;
        private System.Windows.Forms.Button button_SetTarget;
        private System.Windows.Forms.Button button_DeleteTarget;
        private System.Windows.Forms.TextBox textBox_TargetAmount;
        private System.Windows.Forms.Button button_SimulateGameTick;
        private System.Windows.Forms.Button button_ToggleSentences;
        private System.Windows.Forms.TextBox textBox_SimulateSeconds;
        private System.Windows.Forms.TextBox textBox_SimulateAtmPerAnnum;
        private System.Windows.Forms.ColumnHeader TargetElement;
        private System.Windows.Forms.ListView listView_SimulateCurrentElements;
        private System.Windows.Forms.ColumnHeader Gas;
        private System.Windows.Forms.ColumnHeader Amount;
    }
}