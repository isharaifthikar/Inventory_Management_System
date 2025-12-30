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
    public partial class Form3 : Form
    {
        Thread th;
        int count = 0, count2=0, count3=0;
        ProductsDataClasses1DataContext db = new ProductsDataClasses1DataContext();
        public Form3()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            count = db.ProductTables.Count();
            lblTotalProducts.Text = count.ToString();

            count2 = db.SupplierTables.Count();
            lblTotalSuppliers.Text = count2.ToString();

            count3 = db.UserTables.Count();
            lblTotalUsers.Text = count3.ToString();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

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
            Application.Run(new Form4());
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
           
            DialogResult result = MessageBox.Show("Do you want to logout?", "Exit" ,MessageBoxButtons.YesNo, MessageBoxIcon.Question );
            if(result==DialogResult.Yes)
            {
                this.Close();
                th = new Thread(opennewform2);
                th.TrySetApartmentState(ApartmentState.STA);
                th.Start();
            }

            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option will be available in future updates", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option will be available in future updates", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option will be available in future updates", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option will be available in future updates", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void naviButton4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option will be available in future updates", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblTotalProducts_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
