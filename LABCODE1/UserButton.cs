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
    public partial class UserButton : PictureBox
    {
        //private static UserButton currentClickedButton;
        private Image NormalImage;
        private Image HoverImage;

        public UserButton()
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

        

        private void UserButton_MouseHover(object sender, EventArgs e)
        {
            this.Image = HoverImage;
            //if (this != currentClickedButton)
            //{
            //    this.Image = HoverImage;
            //}
        }

        private void UserButton_MouseLeave(object sender, EventArgs e)
        {
            this.Image = NormalImage;
            //if (this != currentClickedButton)
            //{
            //    this.Image = NormalImage;
            //}
        }

        //private void normalState()
        //{
        //    this.Image = NormalImage;
        //}

        //private void UserButton_Click_1(object sender, EventArgs e)
        //{
        //    if (currentClickedButton != null && currentClickedButton != this)
        //    {
        //        currentClickedButton.normalState();
        //    }

        //    currentClickedButton = this;
        //    this.Image = HoverImage;
        //}
    }

    //public partial class UserButton : PictureBox
    //{
    //    private Image NormalImage;
    //    private Image HoverImage;
    //    private bool isClicked = false;

    //    public UserButton()
    //    {
    //        InitializeComponent();
    //        InitializeEvents();
    //    }



    //    //private Image ClickedImage;
    //    ////private Image ClickedImage;

    //    //private bool isClicked = false;

    //    public Image ImageNormal {
    //        get { return NormalImage; }
    //        set { NormalImage = value; }
    //    }

    //    public Image ImageHover {
    //        get { return HoverImage; }
    //        set { HoverImage = value; }
    //    }


    //    private void InitializeEvents()
    //    {
    //        MouseHover += UserButton_MouseHover;
    //        MouseLeave += UserButton_MouseLeave;
    //        Click += UserButton_Click;
    //    }

    //    //public Image ImageClicked
    //    //{
    //    //    get { return ClickedImage; }
    //    //    set { ClickedImage = value; }
    //    //}







    //    private void UserButton_MouseHover(object sender, EventArgs e)
    //    {
    //        //this.Image = HoverImage;

    //        if (!isClicked)
    //        {
    //            this.Image = HoverImage;
    //        }
    //    }

    //    private void UserButton_MouseLeave(object sender, EventArgs e)
    //    {
    //        //this.Image = NormalImage;

    //        if (!isClicked)
    //        {
    //            this.Image = NormalImage;
    //        }
    //    }

    //    private void UserButton_Click(object sender, EventArgs e)
    //    {
    //        isClicked = !isClicked;
    //        if (isClicked)
    //        {
    //            this.Image = HoverImage; // Set the normal image when clicked
    //        }
    //        else
    //        {
    //            this.Image = NormalImage; // Set the hover image when unclicked
    //        }
    //    }






    //    private void ResetToNormalState()
    //    {
    //        this.Image = NormalImage;
    //    }

    //    //private void UserButton_Click(object sender, EventArgs e)
    //    //{
    //    //    this.Image = NormalImage;
    //    //}










    //}
}
