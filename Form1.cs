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
    public partial class Form1 : Form
    {
        Thread th;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Left = panel1.Left - 4;
            if (panel1.Left < -300)
            {
                panel1.Left = 840;
               

               
            }
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Left = 840;
           

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(opennewform);
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
           
        }
         private void opennewform()
        {
            Application.Run(new Form2());
        }
    }
}
