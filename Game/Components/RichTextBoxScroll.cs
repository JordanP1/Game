using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    //A custom RichTextBox, which allows back scrolling while
    //text is being appended.
    //Also disables focus input.

    public partial class RichTextBoxScroll : RichTextBox
    {
        //WINAPI constants.
        private const int SB_LINEUP = 0x0;
        private const int SB_LINEDOWN = 0x1;
        private const int SB_TOP = 0x6;
        private const int SB_BOTTOM = 0x7;
        private const int WM_SETFOCUS = 0x7;
        private const int WM_VSCROLL = 0x115;

        public RichTextBoxScroll()
        {
            InitializeComponent();
        }

        public RichTextBoxScroll(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region PInvoke
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(
            IntPtr hWnd,
            UInt32 Msg,
            IntPtr wParam,
            IntPtr lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetScrollInfo(
            IntPtr hwnd,
            SBOrientation fnBar,
            ref SCROLLINFO lpsi);

        [Serializable, StructLayout(LayoutKind.Sequential)]
        struct SCROLLINFO
        {
            public uint cbSize;
            public ScrollInfoMask fMask;
            public int nMin;
            public int nMax;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }

        enum ScrollInfoMask : uint
        {
            SIF_RANGE = 0x1,
            SIF_PAGE = 0x2,
            SIF_POS = 0x4,
            SIF_DISABLENOSCROLL = 0x8,
            SIF_TRACKPOS = 0x10,
            SIF_ALL = (SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS),
        }

        enum SBOrientation : int
        {
            SB_HORZ = 0x0,
            SB_VERT = 0x1,
            SB_CTL = 0x2,
            SB_BOTH = 0x3
        }
        #endregion

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                //Prevent RichTextBoxScroll from gaining focus.
                //This prevents scrolling errors.
                case WM_SETFOCUS:
                    return;
            }

            base.WndProc(ref m);
        }

        //Information about the scroll bar.
        private SCROLLINFO GetScrollInfo(SBOrientation orientation, ScrollInfoMask mask)
        {
            SCROLLINFO si = new SCROLLINFO();
            si.cbSize = (uint)Marshal.SizeOf<SCROLLINFO>(si);
            si.fMask = mask;
            GetScrollInfo(this.Handle, orientation, ref si);
            return si;
        }

        //Scroll to the very bottom.
        public void ScrollToBottom()
        {
            SendMessage(this.Handle, WM_VSCROLL, (IntPtr)SB_BOTTOM, IntPtr.Zero);
        }

        //Scroll to the very top.
        public void ScrollToTop()
        {
            SendMessage(this.Handle, WM_VSCROLL, (IntPtr)SB_TOP, IntPtr.Zero);
        }

        //Scrolls down one line.
        public void ScrollLineDown()
        {
            SendMessage(this.Handle, WM_VSCROLL, (IntPtr)SB_LINEDOWN, IntPtr.Zero);
        }

        //Scrolls up one line.
        public void ScrollLineUp()
        {
            SendMessage(this.Handle, WM_VSCROLL, (IntPtr)SB_LINEUP, IntPtr.Zero);
        }

        //Add additional functionality to AppendText.
        public new void AppendText(string text)
        {
            //Check to see if the scrollbar is at the bottom before appending.
            SCROLLINFO si = this.GetScrollInfo(SBOrientation.SB_VERT,
                ScrollInfoMask.SIF_RANGE | ScrollInfoMask.SIF_TRACKPOS);
            bool atBottom = si.nTrackPos >= si.nMax - 128 ? true : false;

            base.AppendText(text);

            //Scroll to the bottom if the scrollbar was at the bottom before
            //appending new text.
            if (atBottom)
            {
                this.ScrollToBottom();
            }
        }
    }
}
