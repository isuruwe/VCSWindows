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
    public partial class waiting : Form
    {
        public waiting()
        {
            InitializeComponent();
        }
        BALParticipants oBALParticipants = new BALParticipants();
        public string callid;
        private int cnt=0;
        public System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\Windows\Media\Alarm02.wav");
        private void waiting_Load(object sender, EventArgs e)
        {
            try
            {
                player.PlayLooping();
            }
            catch(Exception ex)
            {

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string un = System.Configuration.ConfigurationManager.AppSettings["username"];
            if (String.IsNullOrEmpty(un))
            {
                un = nwusr;
            }
           // isclos = false;
            oBALParticipants.deleteParticipantData(callid, "3", null);

            DataTable dtAllParticipants = new DataTable();
            dtAllParticipants = oBALParticipants.selectAllusers(un, null);
            //dataGridView1.DataSource = dtAllParticipants;
            


            if (dtAllParticipants.Rows.Count > 0)
            {
                cnt = 1;

                string chlb = dtAllParticipants.Rows[0]["channel"].ToString();

                DataTable dtAllParticipants1 = new DataTable();
                dtAllParticipants1 = oBALParticipants.selectcurusers(chlb, null);
                if (dtAllParticipants1.Rows.Count > 1)
                {
                    
                }
                else
                {
                    try
                    {

                        oBALParticipants.updatecloseData(un, "3", null);
                        //System.Diagnostics.Process.Start(@"chrome.exe", "https://meet.jit.si/" );
                    }
                    catch (Exception eex)
                    {
                    }
                }

            }
            else
            {
               
            }


            this.player.Stop();
            // this.player.Stop();
            this.Close();
        }

        private void waiting_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.player.Stop();
        }
    }
}
