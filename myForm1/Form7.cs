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
    public partial class Form7 : Form
    {
        private int userID;
        private DAL.UserDAL user;
        private UserDTO userData;
        public Form7(int id)
        {
            InitializeComponent();
            userID = id;
            user = new DAL.UserDAL();
            userData = user.getUser(userID);
            if (userData.UserID != -1)
            {
                label2.Text = userData.Name;
                String applicationBasePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

                String filePath = applicationBasePath + @"\images\" + userData.ImageName;
                pictureBox1.Image = Image.FromFile(filePath);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 home = new Form1();
            home.Show();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            String applicationBasePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            System.IO.Directory.CreateDirectory(applicationBasePath + @"\images\");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 user = new Form2(userID, 0);
            user.Show();
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
