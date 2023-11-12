using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Health_Care_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtBoxName.PasswordChar = '*';
            txtBoxPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtBoxName.Text;
            string password = txtBoxPassword.Text;

            if (username == "hms" && password == "pass")
            {
                //MessageBox.Show("you have entered right username and password");

                this.Hide();
                Dashboard dashboard = new Dashboard();
                dashboard.Show();

            }
            else 
            {
                MessageBox.Show("Incorrect user id or password!");
            }
        }

        private void btnCloseProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
