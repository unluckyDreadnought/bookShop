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

        private void GenerateCaptcha()
        {
            Random rand = new Random();
            string symbols = "qwertyuiopaSDFGHJKLZXCVBNM01234567890".ToLower();
            string captcha = "";
            Color[] bgs = { Color.AliceBlue, Color.AntiqueWhite, Color.Bisque };
            Color[] lcl = { Color.Cyan, Color.GreenYellow, Color.DarkGoldenrod, Color.Brown };
            Color bgcolor = bgs[rand.Next(bgs.Length)];

            while (captcha.Length < 4)
            {
                captcha += symbols[rand.Next(symbols.Length)];
            }
            int n = 0;
            while (n < 4)
            {
                Controls[$"label{n + 4}"].Text = captcha[n].ToString();
                Controls[$"label{n + 4}"].BackColor = bgcolor;
                n++;
            }
            Bitmap bmp = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(bgcolor);
                int c = 0;
                while (c < 15)
                {
                    int x = rand.Next(pictureBox3.Width);
                    int x1 = rand.Next(pictureBox3.Width);
                    int y = rand.Next(pictureBox3.Height);
                    int y1 = rand.Next(pictureBox3.Height);
                    g.DrawLine(new Pen(lcl[rand.Next(lcl.Length)]), x, y, x1, y1);
                    c++;
                }
                
            }
            pictureBox3.Image = bmp;
        }

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
            GenerateCaptcha();
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
