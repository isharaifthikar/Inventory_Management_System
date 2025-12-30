using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Net.Mime.MediaTypeNames;
using System.Threading;

namespace Acp_Project
{
    public partial class Form7 : Form
    {
        Thread th;
        public Form7()
        {
            InitializeComponent();
        }

        private void txtAdminUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string password, username;
            password = txtPassword.Text;
            username = txtAdminUserName.Text;
            if (username == "Admin" && password == "123")
            {
                //f6
                this.Close();
                th = new Thread(opennewform6);
                th.TrySetApartmentState(ApartmentState.STA);
                th.Start();

            }
            else
            {
                MessageBox.Show("Incorrect username or password.Please try again", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAdminUserName.Clear();
                txtPassword.Clear();
            }
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            txtAdminUserName.Clear();
            txtPassword.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //f3
            this.Close();
            th = new Thread(opennewform3);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void opennewform3()
        {
            Application.Run(new Form3());
        }

        private void opennewform6()
        {
            Application.Run(new Form6());
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked == false)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
            }
        }
    }
}
