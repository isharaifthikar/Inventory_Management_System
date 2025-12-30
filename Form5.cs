using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
//using static System.Net.Mime.MediaTypeNames;
using System.Threading;

namespace Acp_Project
{
    public partial class Form5 : Form
    {
        Thread th;

        ProductsDataClasses1DataContext db = new ProductsDataClasses1DataContext();
        public Form5()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //f3
            this.Close();
            th = new Thread(opennewform3);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            loadData();
            supplierTable.EnableHeadersVisualStyles = false;
            supplierTable.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            supplierTable.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        }

        void loadData()
        {
            var st = from s in db.SupplierTables select s;
            supplierTable.DataSource = st;
        }

        void clearTextBoxes()
        {
            txtSupplierId.Clear();
            txtSupplierName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
        }

        void InsertData()
        {  

            SupplierTable tblSupplier = new SupplierTable();

            if (!string.IsNullOrEmpty(txtSupplierId.Text) || !string.IsNullOrEmpty(txtSupplierName.Text) || !string.IsNullOrEmpty(txtPhone.Text) || !string.IsNullOrEmpty(txtAddress.Text) || !string.IsNullOrEmpty(txtEmail.Text))
            {
                 if(int.TryParse(txtSupplierId.Text, out _))
                 {
                    tblSupplier.Id = Convert.ToInt32(txtSupplierId.Text);
                    tblSupplier.Supplier_Name = txtSupplierName.Text;
                    tblSupplier.Phone = txtPhone.Text;
                    tblSupplier.Address = txtAddress.Text;
                    tblSupplier.Email = txtEmail.Text;

                    db.SupplierTables.InsertOnSubmit(tblSupplier);
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
                MessageBox.Show("Invalid Input!");
            }
        }

        void updateData()
        {

            if (!string.IsNullOrEmpty(txtSupplierId.Text) || !string.IsNullOrEmpty(txtSupplierName.Text) || !string.IsNullOrEmpty(txtPhone.Text) || !string.IsNullOrEmpty(txtAddress.Text) || !string.IsNullOrEmpty(txtEmail.Text))
            {
               if(txtSupplierId.Enabled == false)
               {
                    SupplierTable supp = db.SupplierTables.FirstOrDefault(supp1 => supp1.Id.Equals(txtSupplierId.Text));
                    supp.Supplier_Name = txtSupplierName.Text;
                    supp.Phone = txtPhone.Text;
                    supp.Address = txtAddress.Text;
                    supp.Email = txtEmail.Text;


                    db.SubmitChanges();
                    txtSupplierId.Enabled = true;

                    loadData();
                    clearTextBoxes();

                    MessageBox.Show("Data Updated!");

                }
               else
                {
                    MessageBox.Show("Update Unsuccessful!", "Attempt Failed!r", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Invalid Input!");
            }
        }

        void DeleteData()
        {


            if (!string.IsNullOrEmpty(txtSupplierId.Text) || !string.IsNullOrEmpty(txtSupplierName.Text) || !string.IsNullOrEmpty(txtPhone.Text) || !string.IsNullOrEmpty(txtAddress.Text) || !string.IsNullOrEmpty(txtEmail.Text))
            {
                if(txtSupplierId.Enabled == false)
                {
                    SupplierTable supp = db.SupplierTables.FirstOrDefault(supp1 => supp1.Id.Equals(supplierTable.CurrentRow.Cells[0].Value));
                    db.SupplierTables.DeleteOnSubmit(supp);

                    db.SubmitChanges();

                    txtSupplierId.Enabled = true;

                    loadData();
                    clearTextBoxes();

                    MessageBox.Show("Data Deleted!");
                }
                else
                {
                    MessageBox.Show("Deletion Unsuccessful!", "Attempt Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Invalid Input!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                InsertData();
            }
            catch (Exception)
            {
                MessageBox.Show("Insertion Unsuccessful!", "Attempt Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            

        }


        private void txtSupplierId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSupplierName.Focus();
            }
        }

        private void txtSupplierName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPhone.Focus();
            }
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAddress.Focus();
            }
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }
        }
        private void suppliertable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void label14_Click(object sender, EventArgs e)
        {
            clearTextBoxes();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                updateData();
            }
            catch (Exception)
            {
                MessageBox.Show("Update Unsuccessful!", "Attempt Failed!r", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteData();
            }
            catch (Exception)
            {
                MessageBox.Show("Deletion Unsuccessful!", "Attempt Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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

        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            //f7
            this.Close();
            th = new Thread(opennewform7);
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
            DialogResult result = MessageBox.Show("Do you want to logout?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void opennewform7()
        {
            Application.Run(new Form7());
        }

        private void opennewform3()
        {
            Application.Run(new Form3());
        }

        private void opennewform()
        {
            Application.Run(new Form4());
        }

        private void naviButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(opennewform7);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void supplierTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void supplierTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSupplierId.Text = supplierTable.CurrentRow.Cells[0].Value.ToString();
            txtSupplierId.Enabled = false;
            txtSupplierName.Text = supplierTable.CurrentRow.Cells[1].Value.ToString();
            txtPhone.Text = supplierTable.CurrentRow.Cells[2].Value.ToString();
            txtAddress.Text = supplierTable.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = supplierTable.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
