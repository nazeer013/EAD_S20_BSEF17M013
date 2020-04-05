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
    public partial class Form2 : Form
    {
        private int userId, adminId;
        private DAL.UserDAL user;
        private UserDTO userData;
        public Form2(int id,int admin)
        {
            userId = id;
            adminId = admin;
            InitializeComponent();
            user = new DAL.UserDAL();
            userData = user.getUser(userId);
            if (adminId == 0)
            {
                if (userData.UserID != -1)
                {
                    textBox1.Text = userData.Name;
                    textBox7.Text = userData.Login;
                    textBox6.Text = userData.Password;

                    String applicationBasePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                    String filePath = applicationBasePath + @"\images\" + userData.ImageName;
                    pictureBox1.Image = Image.FromFile(filePath);
                }
            }
            else
            {
                if (userData.UserID != -1)
                {
                    textBox1.Text = userData.Name;
                    textBox7.Text = userData.Login;
                    textBox6.Text = userData.Password;
                    textBox5.Text = userData.Email;
                    char gender = userData.Gender;
                    if (gender == '1')
                    {
                        comboBox1.Text = "Male";
                    }
                    else if (gender == '2')
                    {
                        comboBox1.Text = "Female";
                    }
                    else
                    {
                        comboBox1.Text = "Others";
                    }
                    address.Text = userData.Address;
                    numericUpDown1.Value = userData.Age;
                    textBox2.Text = userData.NIC;
                    dateTimePicker1.Value = userData.DOB.Date;
                    checkBox1.Checked = Convert.ToBoolean(userData.IsCricket);
                    checkBox3.Checked = Convert.ToBoolean(userData.Hockey);
                    checkBox2.Checked = Convert.ToBoolean(userData.Chess);

                    String applicationBasePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                    String filePath = applicationBasePath + @"\images\" + userData.ImageName;
                    pictureBox1.Image = Image.FromFile(filePath);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var result = openFileDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                var filePath = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(filePath);
            }
            

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string applicationBasePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            System.IO.Directory.CreateDirectory(applicationBasePath + @"\images\");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string login = textBox7.Text;
            string password = textBox6.Text;
            string email = textBox5.Text;
            string homeAddress = address.Text.Trim();

            string nic = textBox2.Text.Trim();
            DateTime dob = dateTimePicker1.Value;
            string isCricket = (checkBox1.Checked == true ? "1" : "0");
            string isHockey = (checkBox3.Checked == true ? "1" : "0");
            string isChess = (checkBox2.Checked == true ? "1" : "0");
            string gen = comboBox1.Text;
            char gender = ' ';
            if (gen == "Male")
            {
                gender = '1';
            }
            else if (gen == "Female")
            {
                gender = '2';
            }
            else
            {
                gender = '3';
            }
            int age = Convert.ToInt32(numericUpDown1.Value);
            string uniqueName = "";

            if (pictureBox1 != null)
            {
                string applicationBasePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                string pathToSaveImage = applicationBasePath + @"\images\";

                uniqueName = Guid.NewGuid().ToString() + ".jpg";
                string imgPath = pathToSaveImage + uniqueName;
                pictureBox1.Image.Save(imgPath);
            }

            DAL.UserDAL user = new DAL.UserDAL();
            UserDTO data = new UserDTO();
            data.Name = name;
            data.Login = login;
            data.Password = password;
            data.Email = email;
            data.Gender = gender;
            data.Address = homeAddress;
            data.Age = age;
            data.NIC = nic;
            data.DOB = dob;
            data.IsCricket = isCricket;
            data.Hockey = isHockey;
            data.Chess = isChess;
            data.ImageName = uniqueName;
            data.CreatedOn = DateTime.Now;

            if (userId > 0)
            {
                int result = user.updateUser(userId, data);
                if (result == 0)
                {
                    MessageBox.Show("No result Found");
                }
                else
                {
                    if (adminId == 0)
                    {
                        MessageBox.Show("User Updated Successfully");
                        this.Hide();
                        Form7 home = new Form7(userId);
                        home.Show();
                    }
                    else
                    {
                        MessageBox.Show("User Updated Successfully");
                        this.Hide();
                        Form8 adminHome = new Form8();
                        adminHome.Show();
                    }
                }

            }
            else
            {
                userId = user.insertNewUser(data);
                if (userId == -1)
                {
                    MessageBox.Show("Empty or invalid fields");
                }
                else if (userId == -2)
                {
                    MessageBox.Show("User with same login or email already exists");
                }
                else if (userId > 0)
                {
                    MessageBox.Show("User successfully added");
                    this.Hide();
                    Form7 home = new Form7(userId);
                    home.Show();
                }
                else
                {
                    MessageBox.Show("Error in inserting the data");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mainScreen = new Form1();
            mainScreen.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void address_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
