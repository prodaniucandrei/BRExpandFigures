using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpandareaObiectelor
{
    public partial class SizeDialog : Form
    {
        public int Height { get; set; }
        public int Width { get; set; }
        private string type;
        public SizeDialog(string type)
        {
            InitializeComponent();
            this.type = type;
            switch (type)
            {
                case "circle":
                    heigthTextBox.Visible = false;
                    heightLbl.Visible = false;
                    label1.Text = "Raza";
                    break;
                case "square":
                    break;
                case "triangle":
                    break;
                case "rotate":
                    heigthTextBox.Visible = false;
                    heightLbl.Visible = false;
                    label1.Text = "Unghi";
                    break;
            }
        }

        private void razTextBox_TextChanged(object sender, EventArgs e)
        {
            {
                switch (type)
                {
                    case "circle":
                        if (!string.IsNullOrEmpty(razTextBox.Text))
                        {
                            this.Height = int.Parse(razTextBox.Text);
                            this.Width = int.Parse(razTextBox.Text);
                        }
                        break;
                    case "square":
                        if (!string.IsNullOrEmpty(razTextBox.Text) && !string.IsNullOrEmpty(this.heigthTextBox.Text))
                        {
                            this.Height = int.Parse(heigthTextBox.Text);
                            this.Width = int.Parse(razTextBox.Text);
                        }
                        break;
                    case "triangle":
                        break;
                    case "rotate":
                        if (!string.IsNullOrEmpty(razTextBox.Text))
                        {
                            this.Height = int.Parse(razTextBox.Text);
                            this.Width = int.Parse(razTextBox.Text);
                        }
                        break;
                }
            }
        }
    }
}




