using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;

using MetroFramework;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Microsoft.Win32;
using System.Drawing.Imaging;
using System.Windows.Automation;
using System.Runtime.InteropServices;

namespace slafconf
{
    public partial class Form1 : MetroForm
    {

        // public Form1(Form MainForm) => InitializeComponent();
        public Form1()
        {
            InitializeComponent();

        }

        System.Windows.Forms.Timer timer;
        //Define here the Form class to be embedded
        // [Your Form Class]
        Form2 EmbeddedForm;
        // Form1 frm1;
        int cnt = 0;
        bool cl = false;
        bool fl = false;
        public bool isnouser = false;
        public bool isrunned = false;
        public bool isjoin = false;
        public bool isonlinu = false;
        bool iswaiting = false;
        public string newuser;
        BALParticipants oBALParticipants = new BALParticipants();
        CMNParticipants oCMNParticipants = new CMNParticipants();
        waiting w4 = new waiting();
        Form4 f4 = new Form4();
        Form5 f5 = new Form5();
        private int retid;
        Form3 fr3 = new Form3();
        Form2 fr2 = new Form2();
        string url = System.Configuration.ConfigurationManager.AppSettings["url"];
        public string un = System.Configuration.ConfigurationManager.AppSettings["username"];
        int facebookInterval = 3; //5 sec
        int twitterInterval = 5; //7 sec



        private void btnEmbedForm_Click(object sender, EventArgs e)
        {
            //EmbeddedForm = new Form2()
            //{
            //    TopLevel = false,
            //    Parent = panContainer,
            //    Location = new Point(4, 4),
            //    Enabled = true
            //};
            //EmbeddedForm.Show();
        }




        private void btnNoBorder_Click(object sender, EventArgs e)
        {
            //Position (to compensate) the embedded Form when its borders are hidden
            EmbeddedForm.Location = new Point(6, 6);
            EmbeddedForm.FormBorderStyle = FormBorderStyle.None;
        }

        private void btnHideSideBar_Click(object sender, EventArgs e)
        {
            //This timer slides the SideBar left. Another one is needed to slide right (if required)
            if (cl == false)
            {

                timer = new Timer();
                timer.Interval = 1;
                timer.Tick += (s, ev) =>
                {
                    //Simply resize the SideBar
                    //panSideBar.Width -= 5;
                    //Or, slide the Panel's controls
                    SideBar_SlideControls();
                    if (panSideBar.Width <= 6)
                    {
                        panSideBar.Width = 6;
                        timer.Stop();
                        timer.Dispose();  //!important
                        //Rectangle rect = panContainer.ClientRectangle;
                        //rect.Inflate(-3, -3);
                        //EmbeddedForm.WindowState = FormWindowState.Normal;
                        //EmbeddedForm.Size = rect.Size;

                    }
                };
                timer.Start();
                cl = true;
            }
            else
            {
                timer = new Timer();
                timer.Interval = 1;
                timer.Tick += (s, ev) =>
                {
                    //Simply resize the SideBar
                    //panSideBar.Width -= 5;
                    //Or, slide the Panel's controls
                    SideBar_SlideControls2();
                    if (panSideBar.Width >= 150)
                    {
                        panSideBar.Width = 150;
                        timer.Stop();
                        timer.Dispose();  //!important
                        //Rectangle rect = panContainer.ClientRectangle;
                        //rect.Inflate(-3, -3);
                        //EmbeddedForm.WindowState = FormWindowState.Normal;
                        //EmbeddedForm.Size = rect.Size;

                    }
                };
                timer.Start();
                cl = false;
            }
        }

        private void SideBar_SlideControls()
        {
            this.panSideBar.Controls.OfType<Control>().Select(ctl => ctl.Left -= 5).ToList();
            this.panSideBar.Width -= 5;
            panSideBar.Update();
        }
        private void SideBar_SlideControls2()
        {
            this.panSideBar.Controls.OfType<Control>().Select(ctl => ctl.Left += 5).ToList();
            this.panSideBar.Width += 5;
            panSideBar.Update();
        }
        private void panContainer_Resize(object sender, EventArgs e)
        {
            //Resizes the embedded Form when the host panel resizes
            if (fl == true)
            {
                //Rectangle rect = panContainer.ClientRectangle;
                //rect.Inflate(-3, -3);
                //EmbeddedForm.Size = rect.Size;
            }
        }

        //private void btnHideSideBar_MouseDown(object sender, MouseEventArgs e)
        //{
        //    btnHideSideBar.FlatAppearance.BorderSize = 1;
        //}

        //private void btnHideSideBar_MouseUp(object sender, MouseEventArgs e)
        //{
        //    btnHideSideBar.FlatAppearance.BorderSize = 0;
        //}




        public static class ControlID
        {
            public static string TextData { get; set; }
        }








        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }




        private void button1_Click_1(object sender, EventArgs e)
        {
            //try
            //{
            //    System.Diagnostics.Process.Start(@"chromefdf.exe", "https://mail.airforce.lk");
            //}
            //catch (Exception eex)
            //{
            //    //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\Windows\Media\Windows Critical Stop.wav");
            //    //player.Play();
            //    //MessageBox.Show("Chrome Not Installed");
            //    Process[] AllProcess = Process.GetProcesses();
            //    foreach (var process in AllProcess)
            //    {
            //        if (process.MainWindowTitle != "")
            //        {
            //            string s = process.ProcessName.ToLower();
            //            if (s == "chrome")
            //                process.Kill();
            //        }
            //    }
            //}
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            try
            {
                bool isnetok = false;

                try
                {

                    isnetok = PingHost("135.22.67.113");
                    isonlinu = isnetok;
                }
                catch (Exception ex)
                {
                    isnetok = false;
                }

                if (isnetok == true)
                {
                    facebookInterval--;
                    twitterInterval--;

                    if (facebookInterval == 0)
                    {
                        facebookInterval = 3;
                        try
                        {
                            // string un = System.Configuration.ConfigurationManager.AppSettings["username"];
                            if (String.IsNullOrEmpty(un))
                            {
                                un = newuser;
                            }
                            if (!String.IsNullOrEmpty(un))
                            {
                                loadmeeeet();


                                if (f4.isclos == false)
                                {
                                    DataSet ods = new DataSet();
                                    ods = oBALParticipants.selectcall(un.ToString().Trim(), null);

                                    if (ods.Tables[0].Rows.Count > 0)
                                    {


                                        isrunned = true;
                                        string chl = ods.Tables[0].Rows[0]["url"].ToString();
                                        isnouser = true;


                                        //f4.embeddedForm2 = EmbeddedForm;
                                        f4.isclos = true;
                                        f4.chl2 = chl;
                                        f4.nwusr = newuser;
                                        f4.ShowDialog();

                                    }


                                }




                                DataSet odsvb = new DataSet();
                                odsvb = oBALParticipants.selectcall(un.ToString().Trim(), null);

                                if (odsvb.Tables[0].Rows.Count <= 0 && f4.isclos == true)
                                {
                                    try
                                    {
                                        f4.isclos = false;
                                        f4.Close();
                                        f4.player.Stop();
                                    }
                                    catch (Exception ec)
                                    {

                                    }
                                }






                            }
                        }
                        catch (Exception ex)
                        {
                            facebookInterval = 3;
                            //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        facebookInterval = 3; //reset to base value
                    }

                    if (twitterInterval == 0)
                    {
                        facebookInterval = 3;
                        oBALParticipants.updateonline(un, null);
                        

                        twitterInterval = 20; //reset to base value
                    }
                    else if (twitterInterval < 0)
                    {
                        twitterInterval = 20;
                    }

                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {


            //try
            //{

            //    isnetok = PingHost("135.22.67.113");
            //}
            //catch (Exception ex)
            //{
            //    isnetok = false;
            //}
            if (isonlinu == true)
            {

            }
            else
            {
                MessageBox.Show("Check Your Network!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        System.Windows.Forms.Timer tmr = null;
        private void StartTimer()
        {
            tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 1000;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Enabled = true;
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.Date.ToString("dddd, dd MMMM yyyy");
            label2.Text = DateTime.Now.ToString("hh:mm tt");
        }
        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress, 1000);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }
        private void SetStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);


            rk.SetValue("slafconf", Application.ExecutablePath);


        }





        public static int FindWindow(string titleName)
        {
            int i = 0;
            Process[] pros = Process.GetProcesses(".");
            foreach (Process p in pros)
                if (p.ProcessName.ToUpper().Equals(titleName.ToUpper()))
                {
                    i++;
                   
                }
                    
            return i;
        }

        private const int SW_MAXIMIZE = 3;
        private const int SW_MINIMIZE = 6;
        // more here: http://www.pinvoke.net/default.aspx/user32.showwindow

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd);

        private void Form1_Load_1(object sender, EventArgs e)
        {
            
          
                    try
                    {
                IntPtr hwnd = FindWindowByCaption(IntPtr.Zero, "VCS");
                if (FindWindow("slafconf")>1)
                {
                    
                    ShowWindow(hwnd);
                    MessageBox.Show("App Already Running!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
               

              
                    }
                    catch (Exception ex)
                    {

                    }
              

            StartTimer();
            SetStartup();

            Rectangle r = new Rectangle(0, 0, pictureBox4.Width, pictureBox4.Height);
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            int d = 50;
            gp.AddArc(r.X, r.Y, d, d, 180, 90);
            gp.AddArc(r.X + r.Width - d, r.Y, d, d, 270, 90);
            gp.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);
            gp.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90);
            pictureBox4.Region = new Region(gp);

            label3.BackColor = Color.Transparent;
            label3.BringToFront();
            pictureBox4.SendToBack();
            ////////////////////////////////////

            System.Drawing.Drawing2D.GraphicsPath gp1 = new System.Drawing.Drawing2D.GraphicsPath();
            gp1.AddEllipse(0, 0, pictureBox5.Width - 3, pictureBox5.Height - 3);
            Region rg = new Region(gp1);
            pictureBox5.Region = rg;
            /////////////////////////////////////
            

            bool isnetok = false;
            try
            {

                isnetok = PingHost("135.22.67.113");
            }
            catch (Exception ex)
            {
                isnetok = false;
            }
           
            if (isnetok == true)
            {

                try
                {
                    // string un = System.Configuration.ConfigurationManager.AppSettings["username"];

                   


                    if (!chkver())
                    {

                        //fr2. = this;
                        fr2.ShowDialog();
                    }

                    else if (String.IsNullOrEmpty(un))
                    {
                        un = newuser;
                        if (String.IsNullOrEmpty(un))
                        {
                            fr3.fm3 = this;
                            fr3.ShowDialog();
                        }
                    }
                    else
                    {

                        loadmeeeet();


                        ///////////////////////////////////////


                        //};
                        fl = true;
                        //EmbeddedForm.Show();
                        //btnHideSideBar.BringToFront();

                        // string un = System.Configuration.ConfigurationManager.AppSettings["username"];
                        //if (String.IsNullOrEmpty(un))
                        //{
                        //    un = newuser;
                        //}
                        //this.label1.Text = un;
                        this.loginAgainToolStripMenuItem.Text= un;


                        //fr3.Close();
                    }

                    //dataGridView1.AutoGenerateColumns = false;
                    //dataGridView2.AutoGenerateColumns = false;
                    //dataGridView3.AutoGenerateColumns = false;
                    //EmbeddedForm = new Form2()
                    //{
                    //    TopLevel = false,
                    //    Parent = panContainer,
                    //    Location = new Point(4, 4),
                    //    Enabled = true
                    if (String.IsNullOrEmpty(un))
                    {
                        un = newuser;
                    }
                    DataTable uimgs = new DataTable();
                    uimgs = oBALParticipants.selectimg(un, null);
                    if (uimgs.Rows.Count > 0)
                    {

                        foreach (DataRow rowr in uimgs.Rows)
                        {
                            string dfghj = rowr["SeatRowNo"].ToString();

                            // You must change the URL to point to your Web server.
                            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(dfghj);
                            req.Method = "GET";
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                            System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                            // Skip validation of SSL/TLS certificate
                            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                            using (var response = req.GetResponse())
                            using (var stream = response.GetResponseStream())
                            {
                                pictureBox5.Image = Bitmap.FromStream(stream);
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Check Your Network!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
            this.Controls.Add(this.statusStrip1);
        }

        public void loadmeeeet()
        {
            linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            linkLabel1.LinkColor = Color.Black;

            DataTable mt = new DataTable();
            mt = oBALParticipants.selectmeet(un, null);
            if (mt.Rows.Count > 0)
            {
                this.label4.Text = "Today Scheduled Meetings";
                string schmt = "";
                int y=0;
                foreach (DataRow rowr in mt.Rows)
                {
                    if (y == 0) {
                        string mtdess =(y+1)+" "+ rowr["mdesc"].ToString() + " on " + rowr["mdate"].ToString();
                        linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
                        linkLabel1.LinkColor = Color.Black;
                        linkLabel1.Text = mtdess;
                    }
                    if (y == 1) {
                        string mtdess = (y + 1) + " " + rowr["mdesc"].ToString() + " on " + rowr["mdate"].ToString();
                        linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
                        linkLabel2.LinkColor = Color.Black;
                        linkLabel2.Text = mtdess;
                    }
                    if (y == 2) {
                        string mtdess = (y + 1) + " " + rowr["mdesc"].ToString() + " on " + rowr["mdate"].ToString();
                        linkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
                        linkLabel3.LinkColor = Color.Black;
                        linkLabel3.Text = mtdess;
                    }
                    if (y == 3) {
                        string mtdess = (y + 1) + " " + rowr["mdesc"].ToString() + " on " + rowr["mdate"].ToString();
                        linkLabel4.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
                        linkLabel4.LinkColor = Color.Black;
                        linkLabel4.Text = mtdess;
                    }
                    if (y == 4) {
                        string mtdess = (y + 1) + " " + rowr["mdesc"].ToString() + " on " + rowr["mdate"].ToString();
                        linkLabel5.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
                        linkLabel5.LinkColor = Color.Black;
                        linkLabel5.Text = mtdess;
                    }
                    

                    //schmt = schmt + mtdess + "\n";
                    y++;
                }
               
               
               
            }
        }
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fr3.fm3 = this;
            fr3.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            newuser = "";
            un = "";
            this.label1.Text = "";
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            config.AppSettings.Settings.Remove("username");
            config.AppSettings.Settings.Add("username", "");

            config.Save(ConfigurationSaveMode.Modified);
            this.Dispose();
        }
        public bool chkver()
        {

            string verstion = System.Configuration.ConfigurationManager.AppSettings["ver"];
            bool er = false;
            DataTable sdfg2 = new DataTable();
            sdfg2 = oBALParticipants.selectver(null);
            if (sdfg2.Rows.Count > 0)
            {

                foreach (DataRow rowr in sdfg2.Rows)
                {
                    string dfghj = rowr["vname"].ToString();
                    if (dfghj.Equals(verstion))
                    {
                        er = true;
                    }
                }


            }
            return er;
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            try
            {
                // string un = System.Configuration.ConfigurationManager.AppSettings["username"];
                if (String.IsNullOrEmpty(un))
                {
                    un = newuser;
                }

                DataSet odscr = new DataSet();

                odscr = oBALParticipants.selectadmin(un.ToString().Trim(), null);
                if (odscr.Tables[0].Rows.Count > 0)
                {

                    if (odscr.Tables[0].Rows[0]["callerid"].ToString().Trim() == un.ToString().Trim())
                    {

                        string val22 = odscr.Tables[0].Rows[0]["channel"].ToString();
                        DataTable sdfg2 = new DataTable();
                        sdfg2 = oBALParticipants.selectcurusers(val22, null);
                        if (odscr.Tables[0].Rows.Count > 0)
                        {

                            foreach (DataRow rowr in sdfg2.Rows)
                            {
                                string dfghj = rowr["callerid"].ToString();
                                oBALParticipants.updatecloseData(dfghj, "4", null);
                            }


                        }
                    }
                    else
                    {
                        oBALParticipants.updatecloseData(un, "4", null);
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }

        }


        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chgpw chpw5 = new chgpw();
            chpw5.ShowDialog();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registercs regh = new registercs();
            regh.ShowDialog();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                // this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = true;
                this.Show();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = true;
            this.Show();
            this.BringToFront();

        }
        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string aid = generateID();
            oBALParticipants.insertauth(un, aid, null);
            oBALParticipants.updatecloseData(un, "4", null);
            string url = System.Configuration.ConfigurationManager.AppSettings["url"] + "?id=" + aid;
            tabcls tb = new tabcls();
            tb.Main(url);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form6 fr6 = new Form6();
            fr6.u1 = un;
            fr6.ShowDialog();

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            // pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = ChangeOpacity(Properties.Resources.z1, float.Parse("50") / 100);
        }
        public static Bitmap ChangeOpacity(Image img, float opacityvalue)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height); // Determining Width and Height of Source Image
            Graphics graphics = Graphics.FromImage(bmp);
            ColorMatrix colormatrix = new ColorMatrix();
            colormatrix.Matrix33 = opacityvalue;
            ImageAttributes imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
            graphics.Dispose();   // Releasing all resource used by graphics 
            return bmp;
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            // pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Cursor = Cursors.Default;
            pictureBox1.Image = ChangeOpacity(Properties.Resources.z1, float.Parse("100") / 100);
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = ChangeOpacity(Properties.Resources.z2, float.Parse("50") / 100);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Cursor = Cursors.Default;
            pictureBox2.Image = ChangeOpacity(Properties.Resources.z2, float.Parse("100") / 100);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form7 fr7 = new Form7();
            fr7.u1 = un;
            fr7.ShowDialog();
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Cursor = Cursors.Hand;
            pictureBox3.Image = ChangeOpacity(Properties.Resources.z3, float.Parse("50") / 100);

        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Cursor = Cursors.Default;
            pictureBox3.Image = ChangeOpacity(Properties.Resources.z3, float.Parse("100") / 100);
        }

        private void fToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            


        }

        private void fToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            List<ToolStripMenuItem> allItems = new List<ToolStripMenuItem>();
            foreach (ToolStripMenuItem toolItem in menuStrip1.Items)
            {

                if (MouseIsOverControl(pictureBox4))
                {
                    toolItem.HideDropDown();
                }

            }
        }
        private bool MouseIsOverControl(PictureBox btn) =>
     btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position));


    private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            //fToolStripMenuItem_MouseEnter(sender, null);
            List<ToolStripMenuItem> allItems = new List<ToolStripMenuItem>();
            foreach (ToolStripMenuItem toolItem in menuStrip1.Items)
            {
                toolItem.ShowDropDown();
            }
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {

            List<ToolStripMenuItem> allItems = new List<ToolStripMenuItem>();
            foreach (ToolStripMenuItem toolItem in menuStrip1.Items)
            {

                if (MouseIsOverControl(pictureBox4))
                {
                    toolItem.HideDropDown();
                }

            }

        }
      



private void pictureBox5_Click(object sender, EventArgs e)
        {
            List<ToolStripMenuItem> allItems = new List<ToolStripMenuItem>();
            foreach (ToolStripMenuItem toolItem in menuStrip1.Items)
            {
                toolItem.ShowDropDown();
            }
        }

        private void menuStrip1_MouseLeave(object sender, EventArgs e)
        {
            List<ToolStripMenuItem> allItems = new List<ToolStripMenuItem>();
            foreach (ToolStripMenuItem toolItem in menuStrip1.Items)
            {

                if (MouseIsOverControl(pictureBox4))
                {
                    toolItem.HideDropDown();
                }

            }
        }

        private void logoutToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            List<ToolStripMenuItem> allItems = new List<ToolStripMenuItem>();
            foreach (ToolStripMenuItem toolItem in menuStrip1.Items)
            {

                if (MouseIsOverControl(pictureBox4))
                {
                    toolItem.HideDropDown();
                }

            }
        }

        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            newuser = "";
            un = "";
            this.label1.Text = "";
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            config.AppSettings.Settings.Remove("username");
            config.AppSettings.Settings.Add("username", "");

            config.Save(ConfigurationSaveMode.Modified);
            this.Dispose();
        }

        private void changePasswordToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            chgpw chw1 = new chgpw();
            chw1.un1 = un;
            chw1.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            DataSet ods = new DataSet();
            DataSet ods5 = new DataSet();
            ods = oBALParticipants.selectactvemt(un.ToString().Trim(), null);

            if (ods.Tables[0].Rows.Count > 0)
            {


              
                string isdfg = ods.Tables[0].Rows[0]["isadmin"].ToString();
                if (isdfg.Equals(un))
                {
                    string aid = generateID();
                    oBALParticipants.insertauth(un, aid, null);
                    string url = System.Configuration.ConfigurationManager.AppSettings["url"] + "?id=" + aid;
                    tabcls tb = new tabcls();
                    tb.Main(url);
                }
                else
                {
                    ods5 = oBALParticipants.selectactveconf(isdfg, null);
                    if (ods5.Tables[0].Rows.Count > 0)
                    {
                        string admin = "";
                        string[] jarr;
                        string jid = "";
                        string jid2 = "";
                        jid = ods5.Tables[0].Rows[0]["channel"].ToString();
                        jarr = jid.Split('/');
                        jid2 = jarr[jarr.Length - 1];
                        // string un = System.Configuration.ConfigurationManager.AppSettings["username"];
                        if (!String.IsNullOrEmpty(un))
                        {
                            DataTable ods6 = new DataTable();
                            ods6 = oBALParticipants.selectmeeeting(jid2, null);

                            if (ods6.Rows.Count > 0)
                            {
                                admin = ods6.Rows[0]["url"].ToString();

                                CMNParticipants oCMNParticipants = new CMNParticipants();

                                oCMNParticipants.Initials = "2";
                                oCMNParticipants.RegistrationNo = jid2;
                                oCMNParticipants.RankID = admin;
                                oCMNParticipants.Status = 0;
                                oCMNParticipants.Surname = un;
                                // oCMNParticipants.OtherNames = txtOtherNames.Text.Trim();
                                //  oCMNParticipants.CountryID = cmbCountry.SelectedValue.ToString();



                                oBALParticipants.insertParticipantData(oCMNParticipants, null);
                                string aid = generateID();
                                oBALParticipants.insertauth(un, aid, null);
                                string url = System.Configuration.ConfigurationManager.AppSettings["url"] + "?id=" + aid + "&id1=" + jid2;
                                tabcls tb = new tabcls();
                                tb.Main(url);
                               // this.Dispose();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Meeting ID!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Login Again!");
                        }


                    }
                    else
                    {
                        MessageBox.Show("Meeting Not Started!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    }
                
            }
            else{
                MessageBox.Show("Meeting Not Started!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataSet ods = new DataSet();
            DataSet ods5 = new DataSet();
            ods = oBALParticipants.selectactvemt(un.ToString().Trim(), null);

            if (ods.Tables[0].Rows.Count > 0)
            {



                string isdfg = ods.Tables[0].Rows[0]["isadmin"].ToString();
                if (isdfg.Equals(un))
                {
                    string aid = generateID();
                    oBALParticipants.insertauth(un, aid, null);
                    string url = System.Configuration.ConfigurationManager.AppSettings["url"] + "?id=" + aid;
                    tabcls tb = new tabcls();
                    tb.Main(url);
                }
                else
                {
                    ods5 = oBALParticipants.selectactveconf(isdfg, null);
                    if (ods5.Tables[0].Rows.Count > 0)
                    {
                        string admin = "";
                        string[] jarr;
                        string jid = "";
                        string jid2 = "";
                        jid = ods5.Tables[0].Rows[0]["channel"].ToString();
                        jarr = jid.Split('/');
                        jid2 = jarr[jarr.Length - 1];
                        // string un = System.Configuration.ConfigurationManager.AppSettings["username"];
                        if (!String.IsNullOrEmpty(un))
                        {
                            DataTable ods6 = new DataTable();
                            ods6 = oBALParticipants.selectmeeeting(jid2, null);

                            if (ods6.Rows.Count > 0)
                            {
                                admin = ods6.Rows[0]["url"].ToString();

                                CMNParticipants oCMNParticipants = new CMNParticipants();

                                oCMNParticipants.Initials = "2";
                                oCMNParticipants.RegistrationNo = jid2;
                                oCMNParticipants.RankID = admin;
                                oCMNParticipants.Status = 0;
                                oCMNParticipants.Surname = un;
                                // oCMNParticipants.OtherNames = txtOtherNames.Text.Trim();
                                //  oCMNParticipants.CountryID = cmbCountry.SelectedValue.ToString();



                                oBALParticipants.insertParticipantData(oCMNParticipants, null);
                                string aid = generateID();
                                oBALParticipants.insertauth(un, aid, null);
                                string url = System.Configuration.ConfigurationManager.AppSettings["url"] + "?id=" + aid + "&id1=" + jid2;
                                tabcls tb = new tabcls();
                                tb.Main(url);
                                this.Dispose();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Meeting ID!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Login Again!");
                        }


                    }
                    else
                    {
                        MessageBox.Show("Meeting Not Started!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            else
            {
                MessageBox.Show("Meeting Not Started!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataSet ods = new DataSet();
            DataSet ods5 = new DataSet();
            ods = oBALParticipants.selectactvemt(un.ToString().Trim(), null);

            if (ods.Tables[0].Rows.Count > 0)
            {



                string isdfg = ods.Tables[0].Rows[0]["isadmin"].ToString();
                if (isdfg.Equals(un))
                {
                    string aid = generateID();
                    oBALParticipants.insertauth(un, aid, null);
                    string url = System.Configuration.ConfigurationManager.AppSettings["url"] + "?id=" + aid;
                    tabcls tb = new tabcls();
                    tb.Main(url);
                }
                else
                {
                    ods5 = oBALParticipants.selectactveconf(isdfg, null);
                    if (ods5.Tables[0].Rows.Count > 0)
                    {
                        string admin = "";
                        string[] jarr;
                        string jid = "";
                        string jid2 = "";
                        jid = ods5.Tables[0].Rows[0]["channel"].ToString();
                        jarr = jid.Split('/');
                        jid2 = jarr[jarr.Length - 1];
                        // string un = System.Configuration.ConfigurationManager.AppSettings["username"];
                        if (!String.IsNullOrEmpty(un))
                        {
                            DataTable ods6 = new DataTable();
                            ods6 = oBALParticipants.selectmeeeting(jid2, null);

                            if (ods6.Rows.Count > 0)
                            {
                                admin = ods6.Rows[0]["url"].ToString();

                                CMNParticipants oCMNParticipants = new CMNParticipants();

                                oCMNParticipants.Initials = "2";
                                oCMNParticipants.RegistrationNo = jid2;
                                oCMNParticipants.RankID = admin;
                                oCMNParticipants.Status = 0;
                                oCMNParticipants.Surname = un;
                                // oCMNParticipants.OtherNames = txtOtherNames.Text.Trim();
                                //  oCMNParticipants.CountryID = cmbCountry.SelectedValue.ToString();



                                oBALParticipants.insertParticipantData(oCMNParticipants, null);
                                string aid = generateID();
                                oBALParticipants.insertauth(un, aid, null);
                                string url = System.Configuration.ConfigurationManager.AppSettings["url"] + "?id=" + aid + "&id1=" + jid2;
                                tabcls tb = new tabcls();
                                tb.Main(url);
                                this.Dispose();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Meeting ID!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Login Again!");
                        }


                    }
                    else
                    {
                        MessageBox.Show("Meeting Not Started!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            else
            {
                MessageBox.Show("Meeting Not Started!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataSet ods = new DataSet();
            DataSet ods5 = new DataSet();
            ods = oBALParticipants.selectactvemt(un.ToString().Trim(), null);

            if (ods.Tables[0].Rows.Count > 0)
            {



                string isdfg = ods.Tables[0].Rows[0]["isadmin"].ToString();
                if (isdfg.Equals(un))
                {
                    string aid = generateID();
                    oBALParticipants.insertauth(un, aid, null);
                    string url = System.Configuration.ConfigurationManager.AppSettings["url"] + "?id=" + aid;
                    tabcls tb = new tabcls();
                    tb.Main(url);
                }
                else
                {
                    ods5 = oBALParticipants.selectactveconf(isdfg, null);
                    if (ods5.Tables[0].Rows.Count > 0)
                    {
                        string admin = "";
                        string[] jarr;
                        string jid = "";
                        string jid2 = "";
                        jid = ods5.Tables[0].Rows[0]["channel"].ToString();
                        jarr = jid.Split('/');
                        jid2 = jarr[jarr.Length - 1];
                        // string un = System.Configuration.ConfigurationManager.AppSettings["username"];
                        if (!String.IsNullOrEmpty(un))
                        {
                            DataTable ods6 = new DataTable();
                            ods6 = oBALParticipants.selectmeeeting(jid2, null);

                            if (ods6.Rows.Count > 0)
                            {
                                admin = ods6.Rows[0]["url"].ToString();

                                CMNParticipants oCMNParticipants = new CMNParticipants();

                                oCMNParticipants.Initials = "2";
                                oCMNParticipants.RegistrationNo = jid2;
                                oCMNParticipants.RankID = admin;
                                oCMNParticipants.Status = 0;
                                oCMNParticipants.Surname = un;
                                // oCMNParticipants.OtherNames = txtOtherNames.Text.Trim();
                                //  oCMNParticipants.CountryID = cmbCountry.SelectedValue.ToString();



                                oBALParticipants.insertParticipantData(oCMNParticipants, null);
                                string aid = generateID();
                                oBALParticipants.insertauth(un, aid, null);
                                string url = System.Configuration.ConfigurationManager.AppSettings["url"] + "?id=" + aid + "&id1=" + jid2;
                                tabcls tb = new tabcls();
                                tb.Main(url);
                                this.Dispose();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Meeting ID!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Login Again!");
                        }


                    }
                    else
                    {
                        MessageBox.Show("Meeting Not Started!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            else
            {
                MessageBox.Show("Meeting Not Started!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataSet ods = new DataSet();
            DataSet ods5 = new DataSet();
            ods = oBALParticipants.selectactvemt(un.ToString().Trim(), null);

            if (ods.Tables[0].Rows.Count > 0)
            {



                string isdfg = ods.Tables[0].Rows[0]["isadmin"].ToString();
                if (isdfg.Equals(un))
                {
                    string aid = generateID();
                    oBALParticipants.insertauth(un, aid, null);
                    string url = System.Configuration.ConfigurationManager.AppSettings["url"] + "?id=" + aid;
                    tabcls tb = new tabcls();
                    tb.Main(url);
                }
                else
                {
                    ods5 = oBALParticipants.selectactveconf(isdfg, null);
                    if (ods5.Tables[0].Rows.Count > 0)
                    {
                        string admin = "";
                        string[] jarr;
                        string jid = "";
                        string jid2 = "";
                        jid = ods5.Tables[0].Rows[0]["channel"].ToString();
                        jarr = jid.Split('/');
                        jid2 = jarr[jarr.Length - 1];
                        // string un = System.Configuration.ConfigurationManager.AppSettings["username"];
                        if (!String.IsNullOrEmpty(un))
                        {
                            DataTable ods6 = new DataTable();
                            ods6 = oBALParticipants.selectmeeeting(jid2, null);

                            if (ods6.Rows.Count > 0)
                            {
                                admin = ods6.Rows[0]["url"].ToString();

                                CMNParticipants oCMNParticipants = new CMNParticipants();

                                oCMNParticipants.Initials = "2";
                                oCMNParticipants.RegistrationNo = jid2;
                                oCMNParticipants.RankID = admin;
                                oCMNParticipants.Status = 0;
                                oCMNParticipants.Surname = un;
                                // oCMNParticipants.OtherNames = txtOtherNames.Text.Trim();
                                //  oCMNParticipants.CountryID = cmbCountry.SelectedValue.ToString();



                                oBALParticipants.insertParticipantData(oCMNParticipants, null);
                                string aid = generateID();
                                oBALParticipants.insertauth(un, aid, null);
                                string url = System.Configuration.ConfigurationManager.AppSettings["url"] + "?id=" + aid + "&id1=" + jid2;
                                tabcls tb = new tabcls();
                                tb.Main(url);
                                this.Dispose();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Meeting ID!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Login Again!");
                        }


                    }
                    else
                    {
                        MessageBox.Show("Meeting Not Started!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            else
            {
                MessageBox.Show("Meeting Not Started!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
    class TransparentLabel : Label
    {
        public TransparentLabel()
        {
            this.BackColor = Color.Transparent;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Parent != null && this.BackColor == Color.Transparent)
            {
                using (var bmp = new Bitmap(Parent.Width, Parent.Height))
                {
                    Parent.Controls.Cast<Control>()
                          .Where(c => Parent.Controls.GetChildIndex(c) > Parent.Controls.GetChildIndex(this))
                          .Where(c => c.Bounds.IntersectsWith(this.Bounds))
                          .OrderByDescending(c => Parent.Controls.GetChildIndex(c))
                          .ToList()
                          .ForEach(c => c.DrawToBitmap(bmp, c.Bounds));

                    e.Graphics.DrawImage(bmp, -Left, -Top);

                }
            }
            base.OnPaint(e);
        }
    }
    class TransparentPictureBox : PictureBox
    {
        public TransparentPictureBox()
        {
            this.BackColor = Color.Transparent;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Parent != null && this.BackColor == Color.Transparent)
            {
                using (var bmp = new Bitmap(Parent.Width, Parent.Height))
                {
                    Parent.Controls.Cast<Control>()
                          .Where(c => Parent.Controls.GetChildIndex(c) > Parent.Controls.GetChildIndex(this))
                          .Where(c => c.Bounds.IntersectsWith(this.Bounds))
                          .OrderByDescending(c => Parent.Controls.GetChildIndex(c))
                          .ToList()
                          .ForEach(c => c.DrawToBitmap(bmp, c.Bounds));

                    e.Graphics.DrawImage(bmp, -Left, -Top);

                }
            }
            base.OnPaint(e);
        }
    }
}
