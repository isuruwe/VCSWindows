using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace slafconf
{
    public partial class Form3 : MetroForm
    {
        public Form3()
        {
            InitializeComponent();
        }
        BALParticipants oBALParticipants = new BALParticipants();
        public string UserValue;
        public Form1 fm3;
        private void button1_Click(object sender, EventArgs e)
        {

           
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }
        //public static string GetLocalIPAddress()
        //{
        //    var host = Dns.GetHostEntry(Dns.GetHostName());
        //    foreach (var ip in host.AddressList)
        //    {
        //        if (ip.AddressFamily == AddressFamily.InterNetwork)
        //        {
        //            return ip.ToString();
        //        }
        //    }
        //    throw new Exception("No network adapters with an IPv4 address in the system!");
        //}
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            bool isnetok = false;
            try
            {

                isnetok = PingHost("135.22.67.113");
            }
            catch (Exception ex)
            {
                isnetok = false;
            }
           // isnetok = true;
            if (isnetok == true)
            {

                try
                {


                    // string ipo=    GetLocalIPAddress();

                    byte[] input = UTF8Encoding.UTF8.GetBytes(textBox2.Text.ToString().Trim().ToLower());
                    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                    tdes.Key = UTF8Encoding.UTF8.GetBytes("XijszJdfJFFIHIdlfkWKIoTo");
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;
                    ICryptoTransform ct = tdes.CreateEncryptor();
                    byte[] result = ct.TransformFinalBlock(input, 0, input.Length);
                    tdes.Clear();

                    string decrypted = Convert.ToBase64String(result);
                    DataSet ods = new DataSet();
                    ods = oBALParticipants.SelectUserDetails(textBox1.Text.ToString().Trim(), decrypted.Trim(), null);

                    if (ods.Tables[0].Rows.Count > 0)
                    {
                        UserValue = ods.Tables[0].Rows[0]["CardID"].ToString();

                    }
                    if (UserValue.ToLower() == textBox1.Text.ToString().Trim().ToLower())
                    {
                        Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

                        config.AppSettings.Settings.Remove("username");
                        config.AppSettings.Settings.Add("username", UserValue);

                        config.Save(ConfigurationSaveMode.Modified);


                        //Form1.ControlID.TextData = UserValue;
                        //Form1 f1 = new Form1();
                        //f1.newuser = UserValue;

                        //f1.ShowDialog();
                        fm3.newuser = UserValue;
                        fm3.un = UserValue;
                        //fm3.label1.Text = UserValue;
                        fm3.loginAgainToolStripMenuItem.Text= UserValue;
                        this.Close();


                    }
                    else
                    {
                        MessageBox.Show("Incorrect Username or Password!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Incorrect Username or Password!");
                }
            }
            else
            {
                MessageBox.Show("Please Check Your Network Connection!");
            }
        }

        private void Form3_Load_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
