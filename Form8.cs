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
    public partial class Form8 : Form
    {
        Thread th;
        ProductsDataClasses1DataContext db = new ProductsDataClasses1DataContext();
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            loadData();

            stockProductTable.EnableHeadersVisualStyles = false;
            stockProductTable.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            stockProductTable.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            //stockProductTable.ReadOnly = true;
        }

        void loadData()
        {
            var st = from s in db.ProductTables select s;
            stockProductTable.DataSource = st;
        }

        private void stockProductTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProductTable proData = new ProductTable();  //
            int searchId;
            if (int.TryParse(txtSearch.Text, out searchId))
            {
                var result = db.ProductTables.Where(p => p.Id==searchId || p.Product_Name.Contains(txtSearch.Text) || p.Category.Contains(txtSearch.Text));
                stockProductTable.DataSource = result.ToList();
            }
            else
            {
                var result = db.ProductTables.Where(p => p.Product_Name.Contains(txtSearch.Text) || p.Category.Contains(txtSearch.Text));
                stockProductTable.DataSource = result.ToList();
            }
            

        }

        private void label14_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            var st = from s in db.ProductTables select s;
            stockProductTable.DataSource = st;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //f3
            this.Close();
            th = new Thread(opennewform3);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
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

        private void opennewform3()
        {
            Application.Run(new Form3());
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

        private void btnUser_Click_1(object sender, EventArgs e)
        {
            //f7
            this.Close();
            th = new Thread(opennewform7);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start(); 
        }
    }
}
