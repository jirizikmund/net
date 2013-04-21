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
    /// Tlačítko s průhledným barevným přechodem.
    /// </summary>
    public partial class ColorButton : Button
    {
        private Color m_colorLeft = SystemColors.Control;
        private Color m_colorRight = Color.Lime;
        private int m_colorLeftTransparency = 50;
        private int m_colorRightTransparency = 50;

        /// <summary>
        /// Barva v levé části
        /// </summary>
        public Color ColorLeft
        {
            get { return m_colorLeft; }
            set { m_colorLeft = value; Invalidate(); }
        }

        /// <summary>
        /// Barva v pravé části
        /// </summary>
        public Color ColorRight
        {
            get { return m_colorRight; }
            set { m_colorRight = value; Invalidate(); }
        }

        /// <summary>
        /// Průhlednost barvy v levé části
        /// </summary>
        public int ColorLeftTransparency
        {
            get { return m_colorLeftTransparency; }
            set { m_colorLeftTransparency = value; Invalidate(); }
        }

        /// <summary>
        /// Průhlednost barvy v pravé části
        /// </summary>
        public int ColorRightTransparency
        {
            get { return m_colorRightTransparency; }
            set { m_colorRightTransparency = value; Invalidate(); }
        }

        /// <summary>
        /// Kontruktor tlačítka
        /// </summary>
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