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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 admin = new Form4();
            admin.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 newUser = new Form2(0,0);
            newUser.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Windows.Forms.Application.ExitThread();
        }
      

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 login = new Form3();
            login.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
