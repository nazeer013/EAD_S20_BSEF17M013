using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace myForm1
{
    public partial class Form4 : Form
    {
        
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 main = new Form1();
            main.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = loginField.Text;
            string pass = passwordField.Text;

            DAL.AdminDAL adminData = new DAL.AdminDAL();
            bool ans = adminData.CheckAdminLogin(login, pass);
            if (ans)
            {
                MessageBox.Show("Admin Logged In");
                this.Hide();
                Form8 adminHome = new Form8();
                adminHome.Show();
            }
            else
            {
                MessageBox.Show("Invalid Login or empty fields");
            }
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
