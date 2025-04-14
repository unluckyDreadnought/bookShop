using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bookShop.Properties;

namespace bookShop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] placeholders = { "Логин", "Пароль" };

        private void SetPlaceholder(TextBox txtBox, bool pass = false)
        {
            if (txtBox.Text.Trim().Length == 0)
            {
                if (pass) txtBox.UseSystemPasswordChar = false;
                txtBox.ForeColor = Color.FromArgb(110,110,110);
                int n = Convert.ToInt32(txtBox.Name[txtBox.Name.Length - 1].ToString());
                txtBox.Text = placeholders[n - 1];
            }
        }

        private void ErasePlaceholder(TextBox txtBox, bool pass = false)
        {
            if (placeholders.Contains(txtBox.Text))
            {
                txtBox.ForeColor = Color.Black;
                txtBox.Text = "";
                if (pass) txtBox.UseSystemPasswordChar = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetPlaceholder(textBox1);
            SetPlaceholder(textBox2);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar) pictureBox1.Image = Resources.Default;
            else pictureBox1.Image = Resources.Variant2;
            textBox2.UseSystemPasswordChar = !textBox2.UseSystemPasswordChar;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            bool p = ((TextBox)sender).Name == "textBox2";
            ErasePlaceholder((TextBox)sender, p);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            bool p = ((TextBox)sender).Name == "textBox2";
            SetPlaceholder((TextBox)sender, p);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "user" && textBox2.Text == "user")
            {
                MainF form = new MainF();
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
        }
    }
}
