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
    
    public partial class Form6 : Form
    {
        Thread th;

        ProductsDataClasses1DataContext db = new ProductsDataClasses1DataContext();
        public Form6()
        {
            InitializeComponent();
        }

        

        private void Form6_Load(object sender, EventArgs e)
        {
            loadData();
            userTable.EnableHeadersVisualStyles = false;
            userTable.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            userTable.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        }

        void loadData()
        {
            var st = from s in db.UserTables select s;
            userTable.DataSource = st;
        }

        void clearTextBoxes()
        {
            txtUserId.Clear();
            txtName.Clear();
            txtPassword.Clear();
            txtReenter.Clear();
            txtEmail. Clear();
        }

        void InsertData()
        {

            UserTable tblUser = new UserTable();    

            if (!string.IsNullOrEmpty(txtUserId.Text) || !string.IsNullOrEmpty(txtName.Text) || !string.IsNullOrEmpty(txtPassword.Text) || !string.IsNullOrEmpty(txtReenter.Text) || !string.IsNullOrEmpty(txtEmail.Text))
            {
                if(txtPassword.Text == txtReenter.Text)
                {
                    if (int.TryParse(txtUserId.Text, out _))
                    {
                        tblUser.Id = Convert.ToInt32(txtUserId.Text);
                        tblUser.Name = txtName.Text;
                        tblUser.Password = txtPassword.Text;    // using object assign table cell value to particular text box
                        tblUser.Email = txtEmail.Text;

                        db.UserTables.InsertOnSubmit(tblUser);
                        db.SubmitChanges();

                        loadData();
                        clearTextBoxes();

                        MessageBox.Show("Data Inserted!");
                    }
                    else
                    {
                        MessageBox.Show("Invalid Input!");
                    }
                        

                }
                else
                {
                    MessageBox.Show("Password doesn't match.Please re-enter the Password again");
                    txtPassword.Clear();
                    txtReenter.Clear();


                }
                
            }
            else
            {
                MessageBox.Show("Invalid Input!");
            }
        }

        void updateData()
        {

            if (!string.IsNullOrEmpty(txtUserId.Text) || !string.IsNullOrEmpty(txtName.Text) || !string.IsNullOrEmpty(txtPassword.Text) || !string.IsNullOrEmpty(txtReenter.Text) || !string.IsNullOrEmpty(txtEmail.Text))
            {
               if (txtUserId.Enabled == false)
               {
                    UserTable user = db.UserTables.FirstOrDefault(user1 => user1.Id.Equals(txtUserId.Text));
                    user.Name = txtName.Text;
                    user.Password = txtPassword.Text;
                    user.Email = txtEmail.Text;

                    db.SubmitChanges();
                    txtUserId.Enabled = true;

                    loadData();
                    clearTextBoxes();

                    MessageBox.Show("Data Updated!");

                }
               else
                {
                    MessageBox.Show("Update Unsuccessful!", "Attempt Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Invalid Input!");
            }
        }

        void DeletData()
        {

            UserTable tblUser = new UserTable();

            if (!string.IsNullOrEmpty(txtUserId.Text) || !string.IsNullOrEmpty(Lable2.Text) || !string.IsNullOrEmpty(Lable3.Text) || !string.IsNullOrEmpty(Lable.Text) || !string.IsNullOrEmpty(txtEmail.Text))
            {
                if (txtUserId.Enabled == false)
                {
                    UserTable user = db.UserTables.FirstOrDefault(user1 => user1.Id.Equals(userTable.CurrentRow.Cells[0].Value));
                    db.UserTables.DeleteOnSubmit(user);

                    db.SubmitChanges();
                    txtUserId.Enabled = true;

                    loadData();
                    clearTextBoxes();

                    MessageBox.Show("Data Deleted!");
                }
                else
                {
                    MessageBox.Show(" Deletion Unsuccessful!", "Attempt Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Invalid Input!");
            }
        }



        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                InsertData();
            }
            catch (Exception )
            {
                MessageBox.Show("Insertion Unsuccessful!", "Attempt Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void txtUserId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtName.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtReenter.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            clearTextBoxes();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                updateData();
            }
            catch (Exception )
            {
                MessageBox.Show("Update Unsuccessful!", "Attempt Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void userTable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeletData();
            }
            catch (Exception)
            {
                MessageBox.Show(" Deletion Unsuccessful!", "Attempt Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //f3
            this.Close();
            th = new Thread(opennewform3);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void checkBoxShowPassword1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword1.Checked == false)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void checkBoxShowPassword2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword2.Checked == false)
            {
                txtReenter.UseSystemPasswordChar = true;
            }
            else
            {
                txtReenter.UseSystemPasswordChar = false;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            //f3
            this.Close();
            th = new Thread(opennewform3);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            //f4
            this.Close();
            th = new Thread(opennewform);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            //f5
            this.Close();
            th = new Thread(opennewform5);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            //f8
            this.Close();
            th = new Thread(opennewform8);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //f2
            DialogResult result = MessageBox.Show("Do you want to logout?", "Exit-Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                th = new Thread(opennewform2);
                th.TrySetApartmentState(ApartmentState.STA);
                th.Start();
            }
        }

        private void opennewform2()
        {
            Application.Run(new Form2());
        }

        private void opennewform8()
        {
            Application.Run(new Form8());
        }

        private void opennewform3()
        {
            Application.Run(new Form3());
        }

        private void opennewform5()
        {
            Application.Run(new Form5());
        }

        private void opennewform()
        {
            Application.Run(new Form4());
        }
        private void opennewform7()
        {
            Application.Run(new Form7());
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            
        }

        private void userTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void userTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUserId.Text = userTable.CurrentRow.Cells[0].Value.ToString();
            txtUserId.Enabled = false;
            txtName.Text = userTable.CurrentRow.Cells[1].Value.ToString();
            txtPassword.Text = userTable.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = userTable.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
