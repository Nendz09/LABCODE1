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
    [DefaultEvent("_TextChanged")]
    public partial class UserTextbox : UserControl
    {

        //Fields
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 2;
        private bool underlinedStyle = false;
        private Color focusColor;

        //private Color borderFocusColor = Color.HotPink;
        private bool isFocused = false;

        //Initialize
        public UserTextbox()
        {
            InitializeComponent();
        }

        //Events
        public event EventHandler _TextChanged;


        //Properties
        [Category("UserTextbox Properties")]
        public Color BorderColor 
        { 
            get => borderColor; //same get { return borderColor } -- 6.0+ version experssion bodied
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }
        [Category("UserTextbox Properties")]
        public Color BorderFocusColor
        {
            get => focusColor; //same get { return borderColor } -- 6.0+ version experssion bodied
            set
            {
                focusColor = value;
                this.Invalidate();
            }
        }

        [Category("UserTextbox Properties")]
        public int BorderSize 
        { 
            get => borderSize;
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }
        [Category("UserTextbox Properties")]
        public bool UnderlinedStyle 
        { 
            get => underlinedStyle;
            set
            {
                underlinedStyle = value;
                this.Invalidate();
            }
        }
        [Category("UserTextbox Properties")]
        public bool PasswordChar
        {
            get => textBox1.UseSystemPasswordChar; 
            set { textBox1.UseSystemPasswordChar = value; }
        }
        [Category("UserTextbox Properties")]
        public bool Multiline
        {
            get => textBox1.Multiline; 
            set { textBox1.Multiline = value; }
        }
        [Category("UserTextbox Properties")]
        public override Color BackColor
        {
            get => base.BackColor; 
            set
            {
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }
        [Category("UserTextbox Properties")]
        public override Color ForeColor
        {
            get => base.ForeColor; 
            set
            {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }
        [Category("UserTextbox Properties")]
        public override Font Font
        {
            get => base.Font; 
            set
            {
                base.Font = value;
                textBox1.Font = value;
                if (this.DesignMode)
                    UpdateControlHeight();
            }
        }
        [Category("UserTextbox Properties")]
        public string Texts
        {
            get => textBox1.Text;
            set { textBox1.Text = value; }
        }

        


        //Overridden method
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            //Draw border
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                if (!isFocused) 
                {
                    if (underlinedStyle) //Line Style
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    else //Normal Style
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                }
                else
                {
                    penBorder.Color = focusColor;

                    if (underlinedStyle) //Line Style
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    else //Normal Style
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                }
                
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
                UpdateControlHeight();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }


        //methods
        private void UpdateControlHeight()
        {
            if (textBox1.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtHeight);
                textBox1.Multiline = false;
                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }


        //TextBox-> TextChanged event
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)
                _TextChanged.Invoke(sender, e);
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }
        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            this.OnMouseHover(e);
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
        }
    }
}
