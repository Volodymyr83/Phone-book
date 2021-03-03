using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone
{
    public partial class Password : Form
    {
        public Password()
        {
            InitializeComponent();
        }



        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "1111")
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Невірний пароль!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Focus();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            if(textBox1.UseSystemPasswordChar == true)
            {
                textBox1.UseSystemPasswordChar = false;
                buttonHide.BackgroundImage = Telephone.Properties.Resources.OpenEye3;
            }
            else
            {
                textBox1.UseSystemPasswordChar = true;
                buttonHide.BackgroundImage = Telephone.Properties.Resources.CloseEye3;
                
            }
            textBox1.Focus();
        }

        private void Password_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
