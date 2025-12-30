using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Acp_Project
{
    public partial class NaviButton : PictureBox
    {
        public NaviButton()
        {
            InitializeComponent();
        }

        private void NaviButton_Load(object sender, EventArgs e)
        {

        }

        private Image NormalImage;
        private Image HoverImage;

        public Image ImageNormal
        {
            get { return NormalImage; }
            set { NormalImage = value; }

        }

        public Image ImageHover
        {
            get { return HoverImage; }
            set { HoverImage = value; }
        }

        private void NaviButton_MouseHover(object sender, EventArgs e)
        {
            this.Image=HoverImage;
        }

        private void NaviButton_MouseLeave(object sender, EventArgs e)
        {
            this.Image=NormalImage;
        }

        private void NaviButton_MouseHover_1(object sender, EventArgs e)
        {
            this.Image = HoverImage;
        }

        private void NaviButton_MouseLeave_1(object sender, EventArgs e)
        {
            this.Image = NormalImage;
        }
    }
}
