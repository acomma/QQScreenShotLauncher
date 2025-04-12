using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NTLauncher
{
    public class HotKey
    {
        public const int WM_HOTKEY = 0x0312;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }

    [Flags]
    public enum KeyModifiers
    {
        None = 0x00,
        Alt = 0x01,
        Ctrl = 0x02,
        Shift = 0x04,
        Windows = 0x08,
        NoRepeat = 0x4000,
    }
}
