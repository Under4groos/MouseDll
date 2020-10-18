using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MouseDll
{
    public class Mouse
    {
        #region MouseEventFlags
        [Flags]
        public enum MouseEventFlags : uint
        {
            MOUSEEVENTF_ABSOLUTE    = 0x8000,
            MOUSEEVENTF_LEFTDOWN    = 0x0002,
            MOUSEEVENTF_LEFTUP      = 0x0004,
            MOUSEEVENTF_MIDDLEDOWN  = 0x0020,
            MOUSEEVENTF_MIDDLEUP    = 0x0040,
            MOUSEEVENTF_MOVE        = 0x0001,
            MOUSEEVENTF_RIGHTDOWN   = 0x0008,
            MOUSEEVENTF_RIGHTUP     = 0x0010,
            MOUSEEVENTF_WHEEL       = 0x0800,
            MOUSEEVENTF_XDOWN       = 0x0080,
            MOUSEEVENTF_XUP         = 0x0100,
            MOUSEEVENTF_HWHEEL      = 0x01000,
            XBUTTON1                = 0x0001,
            XBUTTON2                = 0x0002,
        }
        #endregion

        #region DllImport
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy,
                      int dwData, int dwExtraInfo);
        /// <summary>
        /// Устанока позиции курсора 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point lpPoint);
        #endregion

        /// <summary>
        /// Позиция курсора 
        /// </summary>
        /// <returns></returns>
        public static Point GetCursorPosition()
        {
            Point lpPoint;
            GetCursorPos(out lpPoint);
            return lpPoint;
        }
        /// <summary>
        /// Клик левой кнопкой мыши 
        /// </summary>
        public static void LeftClick()
        {
            mouse_event((int)(MouseEventFlags.MOUSEEVENTF_LEFTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.MOUSEEVENTF_LEFTUP), 0, 0, 0, 0);
        }
        /// <summary>
        /// Клик правой кнопкой мыши 
        /// </summary>
        public static void RightClick()
        {
            mouse_event((int)(MouseEventFlags.MOUSEEVENTF_RIGHTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.MOUSEEVENTF_RIGHTUP), 0, 0, 0, 0);
        }
        /// <summary>
        /// Клик колесиком мыши кнопкой мыши 
        /// </summary>
        public static void MiddleClick()
        {
            mouse_event((int)(MouseEventFlags.MOUSEEVENTF_MIDDLEDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.MOUSEEVENTF_MIDDLEUP), 0, 0, 0, 0);
        }
        /// <summary>
        /// Выводит цвет пикселя
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        public static Color GetColorPixel()
        {
            
            Bitmap Bitmap_ = new Bitmap(1, 1);
            Rectangle Rectangle_ = new Rectangle(GetCursorPosition().X, GetCursorPosition().Y, 1, 1);
            Graphics g = Graphics.FromImage(Bitmap_);
            g.CopyFromScreen(Rectangle_.Location, Point.Empty, Rectangle_.Size);
            return Bitmap_.GetPixel(0, 0);
        }
        
    }
}
