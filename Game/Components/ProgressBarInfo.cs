using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    //A progress bar with a [Value / Maximum] display feature.

    public partial class ProgressBarInfo : ProgressBar
    {
        //WINAIP constants.
        private const int WM_PAINT = 0xF;
        private const int WS_EX_COMPOSITED = 0x02000000;

        public ProgressBarInfo()
        {
            InitializeComponent();
        }

        public ProgressBarInfo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case WM_PAINT:
                    //Draw Value / Maximum centered on the progress bar.
                    using (Graphics g = Graphics.FromHwnd(this.Handle))
                    {
                        string text = string.Format("{0} / {1}", this.Value, this.Maximum);
                        //Width and height of the string in pixels.
                        SizeF textSize = g.MeasureString(text, DefaultFont);
                        //Center the string on the progress bar.
                        float x = (this.Width - textSize.Width) / 2;
                        float y = (this.Height - textSize.Height) / 2;

                        //Draw the string onto the progress bar.
                        g.DrawString(
                            text,
                            this.Parent.Font,
                            SystemBrushes.ControlText,
                            new PointF(x, y));
                    }
                    break;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                //WS_EX_COMPOSITED prevents the text over the ProgressBar
                //from flickering constantly.
                param.ExStyle |= WS_EX_COMPOSITED;
                return param;
            }
        }
    }
}
