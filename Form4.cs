using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Threading;
namespace Acp_Project
{
    public partial class Form4 : Form
    {
        Thread th;
        ProductsDataClasses1DataContext db = new ProductsDataClasses1DataContext();
        public Form4()
        {
            InitializeComponent();

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            loadData();

            productTable.EnableHeadersVisualStyles=false;
            productTable.ColumnHeadersDefaultCellStyle.BackColor= Color.SteelBlue;
            productTable.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

        }

        void loadData()
        {
            var st = from s in db.ProductTables select s;
            productTable.DataSource = st;
        }

        void clearTextBoxes()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            dropdownCategory.Text = "";
        }

        void InsertData()
        {

            ProductTable tblProduct = new ProductTable();

      

            if (!string.IsNullOrEmpty(txtProductId.Text) || !string.IsNullOrEmpty(txtProductName.Text) || !string.IsNullOrEmpty(txtPrice.Text) || !string.IsNullOrEmpty(txtQuantity.Text) || !string.IsNullOrEmpty(dropdownCategory.Text))
            {
                if (int.TryParse(txtQuantity.Text, out _) && int.TryParse(txtPrice.Text, out _) && int.TryParse(txtProductId.Text, out _))  
                {
                    tblProduct.Id = Convert.ToInt32(txtProductId.Text);
                    tblProduct.Product_Name = txtProductName.Text;
                    tblProduct.Price = Convert.ToInt32(txtPrice.Text);
                    tblProduct.Quantity = Convert.ToInt32(txtQuantity.Text);
                    tblProduct.Category = dropdownCategory.Text;

                    db.ProductTables.InsertOnSubmit(tblProduct);
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
                if (!string.IsNullOrEmpty(txtProductId.Text) || !string.IsNullOrEmpty(txtProductName.Text) || !string.IsNullOrEmpty(txtPrice.Text) || !string.IsNullOrEmpty(txtQuantity.Text) || !string.IsNullOrEmpty(dropdownCategory.Text))
                {
                    if(txtProductId.Enabled == false)
                    {
                        ProductTable pro = db.ProductTables.FirstOrDefault(pro1 => pro1.Id.Equals(txtProductId.Text));
                        pro.Product_Name = txtProductName.Text;
                        pro.Price = Convert.ToInt32(txtPrice.Text);
                        pro.Quantity = Convert.ToInt32(txtQuantity.Text);
                        pro.Category = dropdownCategory.Text;

                        db.SubmitChanges();

                        txtProductId.Enabled = true;

                        loadData();
                        clearTextBoxes();

                        MessageBox.Show("Data Updated!");

                    }
                    else
                {
                    MessageBox.Show("update Unsuccessful!", "Attempt Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                }
                else
                {
                    MessageBox.Show("Invalid Input!");
                }
         
        }

        void DeleteData()
        {

            if (!string.IsNullOrEmpty(txtProductId.Text) || !string.IsNullOrEmpty(txtProductName.Text) || !string.IsNullOrEmpty(txtPrice.Text) || !string.IsNullOrEmpty(txtQuantity.Text) || !string.IsNullOrEmpty(dropdownCategory.Text))
            {
                if(txtProductId.Enabled == false)
                {
                    ProductTable pro = db.ProductTables.FirstOrDefault(pro1 => pro1.Id.Equals(productTable.CurrentRow.Cells[0].Value));
                    db.ProductTables.DeleteOnSubmit(pro);

                    db.SubmitChanges();

                    txtProductId.Enabled = true;

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                updateData();
            }
            catch (Exception)
            {
                MessageBox.Show("update Unsuccessful!", "Attempt Failed!" , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            
           
        }

        private void btnSave_Click(object sender, EventArgs e)
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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtProductName.Focus();
            }
        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPrice.Focus();
            }
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQuantity.Focus();
            }
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dropdownCategory.Focus();
            }
        }

        int data;
        private void productTable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
        }

        private void label14_Click(object sender, EventArgs e)
        {
            clearTextBoxes();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            //f3
            this.Close();
            th = new Thread(opennewform);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            //f3
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

        private void opennewform5()
        {
            Application.Run(new Form5());
        }

        private void opennewform()
        {
            Application.Run(new Form3());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUser_Click_1(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(opennewform7);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void productTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProductId.Text = productTable.CurrentRow.Cells[0].Value.ToString();
            txtProductId.Enabled = false;
            txtProductName.Text = productTable.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = productTable.CurrentRow.Cells[2].Value.ToString();
            txtQuantity.Text = productTable.CurrentRow.Cells[3].Value.ToString();
            dropdownCategory.Text = productTable.CurrentRow.Cells[4].Value.ToString();
        }

        private void productTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
