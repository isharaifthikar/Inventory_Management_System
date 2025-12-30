using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace Acp_Project
{
    public partial class Form2 : Form
    {
        Thread th;
        ProductsDataClasses1DataContext db = new ProductsDataClasses1DataContext();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void opennewform()
        {
            Application.Run(new Form3());
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            var data = db.UserTables.Where(s => s.Name == txtUserName.Text && s.Password == txtPassword.Text).FirstOrDefault(); 
         
            string password, username;
                password = txtPassword.Text;
                username = txtUserName.Text;
                if(username=="User" && password=="123" || data !=null)
                {
                    this.Close();
                    th = new Thread(opennewform);
                    th.TrySetApartmentState(ApartmentState.STA);
                    th.Start();

                }
                else
                {
                MessageBox.Show("Incorrect username or password.Please try again", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Clear();
                txtPassword.Clear();

                }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxShowPassword.Checked== false)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar= false;
            }
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Exit?", "Exit-Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }
    }
}
