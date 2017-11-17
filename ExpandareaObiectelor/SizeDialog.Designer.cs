namespace ExpandareaObiectelor
{
    partial class SizeDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.razTextBox = new System.Windows.Forms.TextBox();
            this.heigthTextBox = new System.Windows.Forms.TextBox();
            this.heightLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width";
            // 
            // razTextBox
            // 
            this.razTextBox.Location = new System.Drawing.Point(64, 42);
            this.razTextBox.Name = "razTextBox";
            this.razTextBox.Size = new System.Drawing.Size(61, 20);
            this.razTextBox.TabIndex = 1;
            this.razTextBox.TextChanged += new System.EventHandler(this.razTextBox_TextChanged);
            // 
            // heigthTextBox
            // 
            this.heigthTextBox.Location = new System.Drawing.Point(64, 83);
            this.heigthTextBox.Name = "heigthTextBox";
            this.heigthTextBox.Size = new System.Drawing.Size(61, 20);
            this.heigthTextBox.TabIndex = 2;
            this.heigthTextBox.TextChanged += new System.EventHandler(this.razTextBox_TextChanged);
            // 
            // heightLbl
            // 
            this.heightLbl.AutoSize = true;
            this.heightLbl.Location = new System.Drawing.Point(16, 90);
            this.heightLbl.Name = "heightLbl";
            this.heightLbl.Size = new System.Drawing.Size(38, 13);
            this.heightLbl.TabIndex = 3;
            this.heightLbl.Text = "Height";
            // 
            // SizeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(173, 115);
            this.Controls.Add(this.heightLbl);
            this.Controls.Add(this.heigthTextBox);
            this.Controls.Add(this.razTextBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SizeDialog";
            this.Text = "Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox razTextBox;
        private System.Windows.Forms.TextBox heigthTextBox;
        private System.Windows.Forms.Label heightLbl;
    }
}