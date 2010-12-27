using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace Xenix
{
    public class Input
    {
        [DllImport("user32", EntryPoint = "PostMessageA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int PostMessage(IntPtr hWnd, uint Msg, int lParam, int wParam);

        [DllImport("user32.dll")]
        public static extern ushort GetAsyncKeyState(int vKey);

        public static void ClickXY(IntPtr handle, ushort x, ushort y)
        {
            Thread.Sleep(new Random().Next(Form1.Instance.nextletterMin, Form1.Instance.nextletterMax));

            x = (ushort)new Random().Next(x - 5, x + 5);
            y = (ushort)new Random().Next(y - 5, y + 5);
            uint loc = (uint)((y << 0x10) | x);

            PostMessage(handle, 0x201, 0, (int)loc);
            PostMessage(handle, 0x202, 0, (int)loc);
            x = 0; y = 0;
        }

        public static void TypeLetter(IntPtr handle, int letter)
        {
            Thread.Sleep(new Random().Next(Form1.Instance.nextletterMin, Form1.Instance.nextletterMax));
            PostMessage(handle, 0x100, letter, 0);
            PostMessage(handle, 0x101, letter, 0);
        }

        /// <summary>
        /// Decrease the private working set size
        /// </summary>
        /// <param name="proc">Process handle</param>
        /// <param name="min">set to -1</param>
        /// <param name="max">set to -1</param>
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);
    }
}
