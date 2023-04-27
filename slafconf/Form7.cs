using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace slafconf
{
    public partial class Form7 : MetroForm
    {
        internal string u1;
        BALParticipants oBALParticipants = new BALParticipants();
        DataTable dt = new DataTable();
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            string dbConString = System.Configuration.ConfigurationManager.AppSettings["cons"];
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            conn.ConnectionString = dbConString;
            conn.Open();
            string query = "SELECT  [SysID],[Surname],[CardID] FROM [vidconf].[dbo].[tblParticipants]";
            cmd.Connection = conn;
            cmd.CommandText = query;
            
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            foreach (DataRow row in dt.Rows)
            {
                string myItem = row["Surname"].ToString();
                checkedListBox1.Items.Add(myItem, false);//true means check the items. use false if you don't want to check the items or simply .....Items.Add(myItem);
            }
            conn.Close();
           
           
        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CMNParticipants oCMNParticipants = new CMNParticipants();
            try
            {
                foreach (object item in checkedListBox1.CheckedItems)
                {
                    string itemchecked = item.ToString();
                    DataRow[] dr1 = dt.Select("Surname='"+itemchecked+"'");

                    foreach (DataRow row in dr1)
                    {
                        string name = row.Field<string>("Surname");
                        string contact = row.Field<string>("CardID");
                        string mtdesc = this.textBox1.Text;
                        string mtdate = this.dateTimePicker1.Text;
                        string mttime = this.dateTimePicker2.Text;
                        string mdt = mtdate + " " + mttime;

                      

                        oCMNParticipants.Initials = mtdesc;
                        oCMNParticipants.RegistrationNo = mdt;
                        oCMNParticipants.RankID = contact;
                        oCMNParticipants.Surname = u1;



                        oBALParticipants.insertmeet(oCMNParticipants, null);



                    }
                }


                string mtdesc1 = this.textBox1.Text;
                string mtdate1 = this.dateTimePicker1.Text;
                string mttime1 = this.dateTimePicker2.Text;
                string mdt1 = mtdate1 + " " + mttime1;

               // CMNParticipants oCMNParticipants = new CMNParticipants();

                oCMNParticipants.Initials = mtdesc1;
                oCMNParticipants.RegistrationNo = mdt1;
                oCMNParticipants.RankID = u1;
                oCMNParticipants.Surname = u1;



                oBALParticipants.insertmeet(oCMNParticipants, null);

                MessageBox.Show("Saved!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
               // loadmeeeet()
                this.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void metroTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            int index = checkedListBox1.FindString(this.metroTextBox1.Text);
            if (0 <= index)
            {
                checkedListBox1.SelectedIndex = index;

            }
            if (this.metroTextBox1.Text.Trim() == "")
                checkedListBox1.SelectedIndex = -1;
        }
    }
}
