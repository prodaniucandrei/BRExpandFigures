namespace ExpandareaObiectelor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.freeDrawBtn = new System.Windows.Forms.ToolStripButton();
            this.squareBtn = new System.Windows.Forms.ToolStripButton();
            this.triangleBtn = new System.Windows.Forms.ToolStripButton();
            this.circleBtn = new System.Windows.Forms.ToolStripButton();
            this.dragBtn = new System.Windows.Forms.ToolStripButton();
            this.expandBtn = new System.Windows.Forms.ToolStripButton();
            this.menu.SuspendLayout();
            this.panel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(991, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expandToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // expandToolStripMenuItem
            // 
            this.expandToolStripMenuItem.Name = "expandToolStripMenuItem";
            this.expandToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.expandToolStripMenuItem.Text = "Expand";
            this.expandToolStripMenuItem.Click += new System.EventHandler(this.expandToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.toolStrip1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 24);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(991, 480);
            this.panel.TabIndex = 1;
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            this.panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.freeDrawBtn,
            this.squareBtn,
            this.triangleBtn,
            this.circleBtn,
            this.dragBtn,
            this.expandBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(991, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // freeDrawBtn
            // 
            this.freeDrawBtn.Image = ((System.Drawing.Image)(resources.GetObject("freeDrawBtn.Image")));
            this.freeDrawBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.freeDrawBtn.Name = "freeDrawBtn";
            this.freeDrawBtn.Size = new System.Drawing.Size(78, 22);
            this.freeDrawBtn.Text = "Free draw";
            this.freeDrawBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.freeDrawBtn.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // squareBtn
            // 
            this.squareBtn.Image = ((System.Drawing.Image)(resources.GetObject("squareBtn.Image")));
            this.squareBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.squareBtn.Name = "squareBtn";
            this.squareBtn.Size = new System.Drawing.Size(79, 22);
            this.squareBtn.Text = "Rectangle";
            this.squareBtn.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // triangleBtn
            // 
            this.triangleBtn.Image = ((System.Drawing.Image)(resources.GetObject("triangleBtn.Image")));
            this.triangleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.triangleBtn.Name = "triangleBtn";
            this.triangleBtn.Size = new System.Drawing.Size(69, 22);
            this.triangleBtn.Text = "Triangle";
            this.triangleBtn.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // circleBtn
            // 
            this.circleBtn.Image = ((System.Drawing.Image)(resources.GetObject("circleBtn.Image")));
            this.circleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.circleBtn.Name = "circleBtn";
            this.circleBtn.Size = new System.Drawing.Size(57, 22);
            this.circleBtn.Text = "Circle";
            this.circleBtn.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // dragBtn
            // 
            this.dragBtn.Image = ((System.Drawing.Image)(resources.GetObject("dragBtn.Image")));
            this.dragBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dragBtn.Name = "dragBtn";
            this.dragBtn.Size = new System.Drawing.Size(52, 22);
            this.dragBtn.Text = "Drag";
            this.dragBtn.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // expandBtn
            // 
            this.expandBtn.Image = ((System.Drawing.Image)(resources.GetObject("expandBtn.Image")));
            this.expandBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.expandBtn.Name = "expandBtn";
            this.expandBtn.Size = new System.Drawing.Size(67, 22);
            this.expandBtn.Text = "Concav";
            this.expandBtn.Click += new System.EventHandler(this.expandBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 504);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolStripMenuItem expandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton freeDrawBtn;
        private System.Windows.Forms.ToolStripButton squareBtn;
        private System.Windows.Forms.ToolStripButton triangleBtn;
        private System.Windows.Forms.ToolStripButton circleBtn;
        private System.Windows.Forms.ToolStripButton expandBtn;
        private System.Windows.Forms.ToolStripButton dragBtn;
    }
}


