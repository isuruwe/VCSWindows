using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
namespace slafconf
{
    class tabcls
    {



        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public void Main(string url)
        {
            try { 
            //Process[] procs = Process.GetProcessesByName("chrome");

            //if (procs.Length == 0)
            //{
            //    //Console.WriteLine("Google Chrome is not currently open");
            //    //return;
            //}

            //List<string> titles = new List<string>();

            //IntPtr hWnd = IntPtr.Zero;
            //int id = 0;
            //int numTabs = procs.Length;

            //foreach (Process p in procs)
            //{
            //    if (p.MainWindowTitle.Length > 0)
            //    {
            //        hWnd = p.MainWindowHandle;
            //        id = p.Id;
            //        break;
            //    }
            //}

            //bool isMinimized = IsIconic(hWnd);

            //if (isMinimized)
            //{
            //    ShowWindow(hWnd, 9); // restore
            //    Thread.Sleep(100);
            //}

            //SetForegroundWindow(hWnd);
            //SendKeys.SendWait("^1"); // change focus to first tab
            //Thread.Sleep(100);

            //int next = 1;
            //string title;

            //while (next <= numTabs)
            //{
            //    try
            //    {
            //        title = Process.GetProcessById(id).MainWindowTitle.Replace(" - Google Chrome", "");
            //      //  if (title.ToLower().Contains("slaf")|| title.ToLower().Contains("135.22.67.66"))
            //      //  {
            //            SendKeys.SendWait("^{w}"); // close tab.
            //            Thread.Sleep(100);
            //     //   }
            //        next++;
            //        SendKeys.SendWait("^{TAB}"); // change focus to next tab
            //        Thread.Sleep(100);
            //    }
            //    catch (Exception ex)
            //        {
            //            next++;
            //            // Chrome internal process, doesn't have tab.

            //        }
            //}

            //if (isMinimized)
            //{
            //    ShowWindow(hWnd, 6); // minimize again
            //    Thread.Sleep(100);
            //}

            //hWnd = Process.GetCurrentProcess().MainWindowHandle;
            //SetForegroundWindow(hWnd);
            //Thread.Sleep(100);

                //Console.WriteLine("Closed youtube tabs");

                // Console.ReadKey();
                // System.Diagnostics.Process.Start(@"chrome.exe", url+"–ignore-certificate-errors");
                foreach (var process1 in Process.GetProcessesByName("chrome"))
                {
                    process1.Kill();
                }

                Process process = new Process();
            process.StartInfo.FileName = @"chrome.exe";
            process.StartInfo.Arguments = url + " --ignore-certificate-errors";
            process.Start();

        }
                catch (Exception ex)
                {
                    // Chrome internal process, doesn't have tab.

                }

}

    }
}

