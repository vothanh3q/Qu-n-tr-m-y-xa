using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        static int count;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            account acc = new account("Thanh", "10061996q");
            if (cbDSUsername.Text.Trim().Equals(acc.Username1) && tbPassword.Text.Trim().Equals(acc.Password1))
            {
                MessageBox.Show("Đăng nhập thành công");
            }
            else
            {
                MessageBox.Show("Sai password hoặc username");
                count = count + 1;
                if (count >= 3)
                    MessageBox.Show(" Sai mat khau qua 3 lan ");
                btLogin.Enabled=false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cbDSIP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }
    }
    class account
    {
        private string Username;

        public string Username1
        {
            get { return Username; }
            set { Username = value; }
        }
        private string Password;

        public string Password1
        {
            get { return Password; }
            set { Password = value; }
        }

        public account(string user, string pass)
        {
            this.Username = user;
            this.Password = pass;
        }

    }

}
