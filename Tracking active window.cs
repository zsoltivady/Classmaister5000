using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }
        static void Main(string[] args)
        {
            string activeWindow = GetActiveWindowTitle();
            string newWindow;
            uint time = 0;
            while (true)
            {
                newWindow = GetActiveWindowTitle();
                if(newWindow != activeWindow)
                {
                    if(time>1)
                        Console.WriteLine("[ "+ time + "s ]  " + activeWindow);
                    activeWindow = newWindow;
                    time = 0;
                } else
                {
                    time++;
                }
                Thread.Sleep(1000);
            }
        }
    }
}
