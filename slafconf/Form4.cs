using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;

namespace slafconf
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

        }
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
        string url = System.Configuration.ConfigurationManager.AppSettings["url"];
        BALParticipants oBALParticipants = new BALParticipants();
        public System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\Windows\Media\Ring01.wav");
        public Form2 embeddedForm2;
        public string chl2;
        public string nwusr;
        public bool isclos = false;
        private void button1_Click(object sender, EventArgs e)
        {
           
        }



        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private void button2_Click_1(object sender, EventArgs e)
        {
            string un = System.Configuration.ConfigurationManager.AppSettings["username"];
            if (String.IsNullOrEmpty(un))
            {
                un = nwusr;
            }
            isclos = false;
            oBALParticipants.deleteParticipantData(un, "3", null);

            this.player.Stop();
            this.Close();
        }
        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string un = System.Configuration.ConfigurationManager.AppSettings["username"];
            if (String.IsNullOrEmpty(un))
            {
                un = nwusr;
            }
            DataSet dst1 = new DataSet();
            dst1= oBALParticipants.selectadmincount(un,null);
            if (dst1.Tables[0].Rows.Count > 1)
            {
                DataSet dst2 = new DataSet();
                dst2 = oBALParticipants.selectcall(un, null);
                foreach (DataRow rowr in dst2.Tables[0].Rows)
                {
                    string usid = rowr["url"].ToString();
                    foreach (DataRow rowr1 in dst1.Tables[0].Rows)
                    {
                        string chlid = rowr1["channel"].ToString();
                        oBALParticipants.updatechnlData(usid, chlid, null);
                    }
                }
                oBALParticipants.deleteParticipantData(un, "2", null);
                isclos = false;
            }
            else
            {
                oBALParticipants.updatecloseData(un, "4", null);
                oBALParticipants.deleteParticipantData(un, "2", null);



                isclos = false;
                //embeddedForm2.loaduri(chl2);
                try
                {

                    string aid = generateID();
                    oBALParticipants.insertauth(un, aid, null);
                    //oBALParticipants.updatecloseData(un, "4", null);
                    string url = System.Configuration.ConfigurationManager.AppSettings["url"] + "?id=" + aid;
                    tabcls tb = new tabcls();
                    tb.Main(url);




                }
                catch (Exception eex)
                {
                    MessageBox.Show("Chrome Not Installed!");
                }
            }
            this.player.Stop();
            this.Close();
        }

        private void Form4_Load_1(object sender, EventArgs e)
        {
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
            this.ControlBox = false;
            this.label1.Text = chl2 + " Calling";
            try
            {
                player.PlayLooping();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
