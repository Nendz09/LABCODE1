using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABCODE1
{
    public partial class UserButtonMainPanel : PictureBox
    {
        private static UserButtonMainPanel currentClickedButton;
        private Image NormalImage;
        private Image HoverImage;

        public UserButtonMainPanel()
        {
            InitializeComponent();
        }
        
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

        private void UserButtonMainPanel_MouseHover(object sender, EventArgs e)
        {
            if (this != currentClickedButton)
            {
                this.Image = HoverImage;
            }
        }

        private void UserButtonMainPanel_MouseLeave(object sender, EventArgs e)
        {
            if (this != currentClickedButton)
            {
                this.Image = NormalImage;
            }
        }

        private void UserButtonMainPanel_Click(object sender, EventArgs e)
        {
            if (currentClickedButton != null && currentClickedButton != this)
            {
                currentClickedButton.normalState();
            }

            currentClickedButton = this;
            this.Image = HoverImage;
        }
        private void normalState()
        {
            this.Image = NormalImage;
        }

    }
}
