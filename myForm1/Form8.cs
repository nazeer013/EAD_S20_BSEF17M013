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
    public partial class Form8 : Form
    {
        DAL.AdminDAL admin;
        public Form8()
        {
            InitializeComponent();
            admin = new DAL.AdminDAL();
            DataTable db = admin.GetAllUsers();

            dataGridView1.DataSource = db;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mainScreen = new Form1();
            mainScreen.Show();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                this.Hide();
                Form2 user = new Form2(id, 1);
                user.Show();
            }
        }
    }
}
