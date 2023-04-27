using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace slafconf
{
    public partial class Form6 : MetroForm
    {
        BALParticipants oBALParticipants = new BALParticipants();
        public string u1;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string admin = "";
            string[] jarr;
            string jid = "";
            string jid2 = "";
            jid = textBox1.Text;
            jarr = jid.Split('/');
            jid2 = jarr[jarr.Length - 1];
           // string un = System.Configuration.ConfigurationManager.AppSettings["username"];
            if (!String.IsNullOrEmpty(u1))
            {
                DataTable ods = new DataTable();
                ods = oBALParticipants.selectmeeeting(jid2, null);

                if (ods.Rows.Count > 0)
                {
                    admin= ods.Rows[0]["url"].ToString();
               
                CMNParticipants oCMNParticipants = new CMNParticipants();

                oCMNParticipants.Initials = "2";
                oCMNParticipants.RegistrationNo = jid2;
                oCMNParticipants.RankID = admin;
                oCMNParticipants.Status = 0;
                oCMNParticipants.Surname = u1;
                // oCMNParticipants.OtherNames = txtOtherNames.Text.Trim();
                //  oCMNParticipants.CountryID = cmbCountry.SelectedValue.ToString();



                oBALParticipants.insertParticipantData(oCMNParticipants, null);
                string aid = generateID();
                oBALParticipants.insertauth(u1, aid, null);
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
    }
}
