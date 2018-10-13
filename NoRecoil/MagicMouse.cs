using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace NoRecoil
{
    class MagicMouse
    {

        public static int _ScreenWidth { get; } = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        public static int _ScreenHeight { get; } = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
        public static int _ScreenCenterX { get; } = _ScreenWidth / 2;
        public static int _ScreenCenterY { get; } = _ScreenHeight / 2;

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);
        
        public static bool bGetAsyncKeyState(System.Windows.Forms.Keys vKey)
        {
            int x = GetAsyncKeyState(vKey);
            if ((x == 1) || (x == Int16.MinValue))
                return true;
            else
                return false;
        }

        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        private const int MOUSEEVENTF_MOVE = 0x0001;

        public static void Move(int xDelta, int yDelta)
        {
            mouse_event(MOUSEEVENTF_MOVE, xDelta, yDelta, 0, 0);
        }
    }
}
