using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zikmundj.CustomComponents
{
    /// <summary>
    /// Button with transparent color transition.
    /// </summary>

    public partial class ColorButton : Button
    {
        private Color m_colorLeft = SystemColors.Control;
        private Color m_colorRight = Color.Lime;
        private int m_colorLeftTransparency = 50;
        private int m_colorRightTransparency = 50;

        public Color ColorLeft
        {
            get { return m_colorLeft; }
            set { m_colorLeft = value; Invalidate(); }
        }

        public Color ColorRight
        {
            get { return m_colorRight; }
            set { m_colorRight = value; Invalidate(); }
        }

        public int ColorLeftTransparency
        {
            get { return m_colorLeftTransparency; }
            set { m_colorLeftTransparency = value; Invalidate(); }
        }

        public int ColorRightTransparency
        {
            get { return m_colorRightTransparency; }
            set { m_colorRightTransparency = value; Invalidate(); }
        }


        public ColorButton()
        {
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Color c1 = Color.FromArgb
                (m_colorLeftTransparency, m_colorLeft);
            Color c2 = Color.FromArgb
                (m_colorRightTransparency, m_colorRight);
            Brush b = new System.Drawing.Drawing2D.LinearGradientBrush
                (ClientRectangle, c1, c2, 10);
            pe.Graphics.FillRectangle(b, ClientRectangle);
            b.Dispose();
        }
    }
}