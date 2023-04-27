using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace slafconf
{
    public partial class chgpw : MetroForm
    {
        public chgpw()
        {
            InitializeComponent();
        }
        BALParticipants oBALParticipants = new BALParticipants();

        string un = System.Configuration.ConfigurationManager.AppSettings["username"];
        internal string un1;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Equals(this.textBox2.Text))
            {
               
                if (String.IsNullOrEmpty(un))
                {
                    un = un1;
                }

                byte[] input = UTF8Encoding.UTF8.GetBytes(textBox1.Text.ToString().Trim().ToLower());
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = UTF8Encoding.UTF8.GetBytes("XijszJdfJFFIHIdlfkWKIoTo");
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform ct = tdes.CreateEncryptor();
                byte[] result = ct.TransformFinalBlock(input, 0, input.Length);
                tdes.Clear();

                string decrypted = Convert.ToBase64String(result);
                oBALParticipants.updatepass(un, decrypted, null);
                MessageBox.Show("Success!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("New Password and Confirm Password Not Match!");
            }
        }

        private void chgpw_Load(object sender, EventArgs e)
        {

        }
    }
}
