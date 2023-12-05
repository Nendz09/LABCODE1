﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        private int borderRadius = 0;
        private Color placeholderColor = Color.DarkGray;
        private string placeholderText = "";
        private bool isPlaceholder = false;
        private bool isPasswordChar = false;

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
            get => isPasswordChar; 
            set 
            { 
                isPasswordChar = value;
                textBox1.UseSystemPasswordChar = value; 
            }
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
            get
            {
                if (isPlaceholder) return "";
                else return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
                SetPlaceholder();
            }
        }
        [Category("UserTextbox Properties")]
        public int BorderRadius 
        { 
            get => borderRadius; 
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate();
                }
            }
        }
        [Category("UserTextbox Properties")]
        public Color PlaceholderColor 
        {
            get { return placeholderColor; }
            set
            {
                placeholderColor = value;
                if (isPlaceholder)
                    textBox1.ForeColor = value;
            }
        }
        [Category("UserTextbox Properties")]
        public string PlaceholderText 
        {
            get { return placeholderText; }
            set
            {
                placeholderText = value;
                textBox1.Text = "";
                SetPlaceholder();
            }
        }

        

        //Overridden method
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            if (borderRadius > 1) //Round txtbox
            {
                //-Fields
                var rectBorderSmooth = this.ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectBorderSmooth, -borderSize, -borderSize);
                int smoothSize = borderSize > 0 ? borderSize : 1;

                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    //-Drawing
                    this.Region = new Region(pathBorderSmooth);//Set the rounded region of UserControl
                    if (borderRadius > 15) SetTextBoxRoundedRegion();//Set the rounded region of TextBox component
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                    if (isFocused) penBorder.Color = focusColor;
                    if (underlinedStyle) //Line Style
                    {
                        //Draw border smoothing
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                        //Draw border
                        graph.SmoothingMode = SmoothingMode.None;
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else //Normal Style
                    {
                        //Draw border smoothing
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                        //Draw border
                        graph.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else
            {
                //Draw border
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    this.Region = new Region(this.ClientRectangle);
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    if (isFocused) penBorder.Color = focusColor;
                    if (underlinedStyle) //Line Style
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    else //Normal Style
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                }
                //Draw border
                //using (Pen penBorder = new Pen(borderColor, borderSize))
                //{
                //    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                //    if (!isFocused)
                //    {
                //        if (underlinedStyle) //Line Style
                //            graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                //        else //Normal Style
                //            graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                //    }
                //    else
                //    {
                //        penBorder.Color = focusColor;

                //        if (underlinedStyle) //Line Style
                //            graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                //        else //Normal Style
                //            graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                //    }

                //}
            }
        }

        private void SetTextBoxRoundedRegion()
        {
            GraphicsPath pathTxt;
            if (Multiline)
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderRadius - borderSize);
                textBox1.Region = new Region(pathTxt);
            }
            else
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderSize * 2);
                textBox1.Region = new Region(pathTxt);
            }
            pathTxt.Dispose();
        }


        //RADIUS
        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
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

        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) && placeholderText != "")
            {
                isPlaceholder = true;
                textBox1.Text = placeholderText;
                textBox1.ForeColor = placeholderColor;
                if (isPasswordChar)
                    textBox1.UseSystemPasswordChar = false;
            }
        }

        private void RemovePlaceholder()
        {
            if (isPlaceholder && placeholderText != "")
            {
                isPlaceholder = false;
                textBox1.Text = "";
                textBox1.ForeColor = this.ForeColor;
                if (isPasswordChar)
                    textBox1.UseSystemPasswordChar = true;
            }
        }

        public void Clear()
        {
            textBox1.Text = string.Empty;
        }




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
            RemovePlaceholder();
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
            SetPlaceholder();
        }
    }
}
