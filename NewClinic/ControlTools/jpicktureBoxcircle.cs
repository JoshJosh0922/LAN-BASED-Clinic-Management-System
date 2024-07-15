using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace WindowsFormsApp1.tao
{
    public class jpicktureBoxcircle : PictureBox
    {
        public int border = 2;
        public Color colorBorder = Color.RoyalBlue;
        public Color colorBorder2 = Color.HotPink;
        public DashStyle borderstyle = DashStyle.Solid;
        public DashCap borderCap = DashCap.Flat;
        public float gradiant = 50f;


        public jpicktureBoxcircle()
        {
            this.Size = new Size(95, 95);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public int Border
        {
            get
            {
                return border;
            }

            set
            {
                border = value;
                this.Invalidate();
            }
        }

        public Color ColorBorder
        {
            get
            {
                return colorBorder;
            }

            set
            {
                colorBorder = value;
                this.Invalidate();

            }
        }

        public Color ColorBorder2
        {
            get
            {
                return colorBorder2;
            }

            set
            {
                colorBorder2 = value;
                this.Invalidate();

            }
        }

        public DashStyle Borderstyle
        {
            get
            {
                return borderstyle;
            }

            set
            {
                borderstyle = value;
                this.Invalidate();

            }
        }

        public DashCap BorderCap
        {
            get
            {
                return borderCap;
            }

            set
            {
                borderCap = value;
                this.Invalidate();

            }
        }

        public float Gradiant
        {
            get
            {
                return gradiant;
            }

            set
            {
                gradiant = value;
                this.Invalidate();

            }
        }


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Size = new Size(this.Width, this.Width);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);


            var graphic = pe.Graphics;
            var rect = Rectangle.Inflate(this.ClientRectangle, -1, -1);
            var rectborder = Rectangle.Inflate(rect, -border, -border);
            var size = border > 0 ? border * 3 : 1;

            using (var bordercolorG = new LinearGradientBrush(rectborder, colorBorder, colorBorder2, gradiant))
            using (var path = new GraphicsPath())
            using (var pen = new Pen(this.Parent.BackColor, border))
            using (var penborder = new Pen(bordercolorG, size))
            {

                graphic.SmoothingMode = SmoothingMode.AntiAlias;
                penborder.DashStyle = borderstyle;
                penborder.DashCap = borderCap;

                path.AddEllipse(rect);

                this.Region = new Region(path);


                graphic.DrawEllipse(pen, rect);
                if (border > 0)
                {
                    graphic.DrawEllipse(penborder, rectborder);
                }


            }

        }



    }
}
