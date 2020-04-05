using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myForm1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DAL.UserDAL user = new DAL.UserDAL();
            UserDTO data = new UserDTO();

            data.Login = textBox1.Text;
            data.Password = textBox2.Text;

            int userId = user.checkUserLogin(data);
            if (userId == -1)
            {
                MessageBox.Show("Empty Fields");
            }
            else if (userId == 0)
            {
                MessageBox.Show("Invalid Username or password");
            }
            else
            {
                this.Hide();
                Form7 home = new Form7(userId);
                home.Show();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mainScreen = new Form1();
            mainScreen.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 enterResetCode = new Form5();
            enterResetCode.Show();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
