using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace GlassMoth
{
    // Desktop Windows Manager APIs
    internal class VistaApi
    {
        [DllImport("dwmapi.dll")]
        internal static extern void DwmExtendFrameIntoClientArea(System.IntPtr hWnd, ref Margins pMargins);

        [DllImport("dwmapi.dll")]
        internal static extern void DwmIsCompositionEnabled(ref bool isEnabled);

        internal struct Margins
        {
            public int Left, Right, Top, Bottom;
        }

        // consts for wndproc
        internal const int WM_NCHITTEST = 0x84;
        internal const int HTCLIENT = 1;
        internal const int HTCAPTION = 2;
    }
}
