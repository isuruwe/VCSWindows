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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        string url = System.Configuration.ConfigurationManager.AppSettings["url"];
        BALParticipants oBALParticipants = new BALParticipants();
        public System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\Windows\Media\Ring01.wav");
        public Form2 embeddedForm3;
        public string chl3;
        public string nwusr3;
        public bool isclos3 = false;
        private void button1_Click(object sender, EventArgs e)
        {
            string un = System.Configuration.ConfigurationManager.AppSettings["username"];
            if (String.IsNullOrEmpty(un))
            {
                un = nwusr3;
            }
            oBALParticipants.updatejoin(chl3, "2", null);
            isclos3 = false;
            //embeddedForm2.loaduri(chl2);
           
            this.player.Stop();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string un = System.Configuration.ConfigurationManager.AppSettings["username"];
            if (String.IsNullOrEmpty(un))
            {
                un = nwusr3;
            }
            isclos3 = false;
            oBALParticipants.updatejoin(chl3, "3", null);

            this.player.Stop();
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.label1.Text = chl3 + " needs to Join !";
            player.PlayLooping();
        }
    }
}
