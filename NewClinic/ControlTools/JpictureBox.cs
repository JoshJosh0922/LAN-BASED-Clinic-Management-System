using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApp1.tao
{
    public enum ExtendedPictureBoxSizeMode
    {
        Off = 0,
        Cover = 1,
        Fit = 2
    }

    public class JpictureBox : PictureBox
    {
        private ExtendedPictureBoxSizeMode extendedSizeMode = ExtendedPictureBoxSizeMode.Off;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(ExtendedPictureBoxSizeMode.Off)]
        [Category("Behavior")]
        public ExtendedPictureBoxSizeMode ExtendedSizeMode
        {
            get => extendedSizeMode;
            set
            {
                extendedSizeMode = value;
                Invalidate();
            }
        }

        private ContentAlignment extendedImageAlign = ContentAlignment.MiddleCenter;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(ContentAlignment.MiddleCenter)]
        [Category("Behavior")]
        public ContentAlignment ExtendedImageAlign
        {
            get => extendedImageAlign;
            set
            {
                extendedImageAlign = value;
                Invalidate();
            }
        }

        private InterpolationMode interpolationMode = InterpolationMode.Default;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(InterpolationMode.Default)]
        [Category("Behavior")]
        public InterpolationMode InterpolationMode
        {
            get => interpolationMode;
            set
            {
                if (value == InterpolationMode.Invalid)
                    return;

                interpolationMode = value;
                Invalidate();
            }
        }

        private PixelOffsetMode pixelOffsetMode = PixelOffsetMode.Default;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(PixelOffsetMode.Default)]
        [Category("Behavior")]
        public PixelOffsetMode PixelOffsetMode
        {
            get => pixelOffsetMode;
            set
            {
                if (value == PixelOffsetMode.Invalid)
                    return;

                pixelOffsetMode = value;
                Invalidate();
            }
        }

        // When changing the Padding property in the designer nothing seems to happen by default. Since our custom
        // control depends on the Padding property, we want the designer to repaint the control whenever its
        // value is changed, so we override the property and call Invalidate() in the setter to account for this.
        public new Padding Padding
        {
            get => base.Padding;
            set
            {
                base.Padding = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.InterpolationMode = InterpolationMode;
            pe.Graphics.PixelOffsetMode = PixelOffsetMode;

            if (ExtendedSizeMode == ExtendedPictureBoxSizeMode.Off || Image == null)
            {
                base.OnPaint(pe);
                return;
            }

            switch (ExtendedSizeMode)
            {
                case ExtendedPictureBoxSizeMode.Cover:
                    PaintCovered(pe);
                    return;

                case ExtendedPictureBoxSizeMode.Fit:
                    PaintFitted(pe);
                    return;
            }
        }

        private void PaintFitted(PaintEventArgs pe)
        {
            Rectangle rect = DeflateRect(ClientRectangle, Padding);

            if (rect.Height <= 0 || rect.Width <= 0) return;

            Image img = Image;
            int w, h;

            if (img.Width > rect.Width || img.Height > rect.Height)
            {
                if ((double)img.Width / img.Height > (double)rect.Width / rect.Height)
                {
                    w = rect.Width;
                    h = (int)((double)img.Height / img.Width * rect.Width);
                }
                else
                {
                    w = (int)((double)img.Width / img.Height * rect.Height);
                    h = rect.Height;
                }
            }
            else
            {
                w = img.Width;
                h = img.Height;
            }

            rect = GetAlignedContentRect(rect, w, h, ExtendedImageAlign);

            pe.Graphics.DrawImage(img, rect);
        }

        private void PaintCovered(PaintEventArgs pe)
        {
            Rectangle rect = DeflateRect(ClientRectangle, Padding);

            if (rect.Height <= 0 || rect.Width <= 0) return;

            Image img = Image;
            int w, h;

            if ((double)img.Width / img.Height > (double)rect.Width / rect.Height)
            {
                w = (int)((double)rect.Width / rect.Height * img.Height);
                h = img.Height;
            }
            else
            {
                w = img.Width;
                h = (int)((double)rect.Height / rect.Width * img.Width);
            }

            Rectangle imageRect = new Rectangle(0, 0, img.Width, img.Height);
            Rectangle portion = GetAlignedContentRect(imageRect, w, h, ExtendedImageAlign);

            pe.Graphics.DrawImage(img, rect, portion, GraphicsUnit.Pixel);
        }

        private static Rectangle GetAlignedContentRect(Rectangle containerRect, int contentW, int contentH, ContentAlignment imageAlign)
        {
            int containerW = containerRect.Width;
            int containerH = containerRect.Height;

            int x = (containerW - contentW) / 2;
            int y = (containerH - contentH) / 2;

            switch (imageAlign)
            {
                case ContentAlignment.TopLeft:
                    x = y = 0;
                    break;

                case ContentAlignment.TopCenter:
                    y = 0;
                    break;

                case ContentAlignment.TopRight:
                    x = containerW - contentW;
                    y = 0;
                    break;

                case ContentAlignment.MiddleRight:
                    x = containerW - contentW;
                    break;

                case ContentAlignment.BottomRight:
                    x = containerW - contentW;
                    y = containerH - contentH;
                    break;

                case ContentAlignment.BottomCenter:
                    y = containerH - contentH;
                    break;

                case ContentAlignment.BottomLeft:
                    x = 0;
                    y = containerH - contentH;
                    break;

                case ContentAlignment.MiddleLeft:
                    x = 0;
                    break;
            }

            return new Rectangle(containerRect.X + x, containerRect.Y + y, contentW, contentH);
        }

        public static Rectangle DeflateRect(Rectangle rect, Padding padding)
        {
            rect.X += padding.Left;
            rect.Y += padding.Top;
            rect.Width -= padding.Horizontal;
            rect.Height -= padding.Vertical;
            return rect;
        }

    }
}
