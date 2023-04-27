using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace slafconf
{
    public partial class registercs : Form
    {
        public registercs()
        {
            InitializeComponent();
        }
        BALParticipants oBALParticipants = new BALParticipants();
        private void btnSave_Click(object sender, EventArgs e)
        {
            try {
                CMNParticipants oCMNParticipants1 = new CMNParticipants();
                oCMNParticipants1 = setSaveData();
                oBALParticipants.insertParticipantData2(oCMNParticipants1, null);

                MessageBox.Show("Saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       
            private OpenFileDialog Myfile = new OpenFileDialog();
          
            private void btnParticipantImage_Click(object sender, EventArgs e)
            {
                try
                {
                    Myfile.Filter = "JPEG File(*.jpeg)|*.jpg|JPG File(*.jpg)|*.jpg|Bitmap(*.BMP)|*.bmp";
                    Myfile.ShowDialog();
                    System.IO.Stream _BitData = Myfile.OpenFile();
                    Image image = Image.FromStream(_BitData);
                    pbParticipantImage.Image = image;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        
          
            public byte[] imageToByteArray(System.Drawing.Image image)
            {
                MemoryStream ms = new MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
            public static Image ResizeImageFixedWidth(Image imgToResize, int width)
            {
                int sourceWidth = imgToResize.Width;
                int sourceHeight = imgToResize.Height;

                float nPercent = ((float)width / (float)sourceWidth);

                int destWidth = (int)(sourceWidth * nPercent);
                int destHeight = (int)(sourceHeight * nPercent);

                Bitmap b = new Bitmap(destWidth, destHeight);
                Graphics g = Graphics.FromImage((Image)b);
                g.InterpolationMode = InterpolationMode.High;

                g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
                g.Dispose();

                return (Image)b;
            }
            private CMNParticipants setSaveData()
            {
            byte[] input = UTF8Encoding.UTF8.GetBytes(txtInitials.Text.ToString().Trim().ToLower());
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = UTF8Encoding.UTF8.GetBytes("XijszJdfJFFIHIdlfkWKIoTo");
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform ct = tdes.CreateEncryptor();
            byte[] result = ct.TransformFinalBlock(input, 0, input.Length);
            tdes.Clear();

            string decrypted = Convert.ToBase64String(result);

            CMNParticipants oCMNParticipants = new CMNParticipants();

                oCMNParticipants.SysID = "001";
                oCMNParticipants.RegistrationNo = txtRegistrationNo.Text.Trim();
                //oCMNParticipants.RankID = cmbRank.SelectedValue.ToString();
                oCMNParticipants.Initials = decrypted;
                oCMNParticipants.Surname = txtSurname.Text.Trim();
               // oCMNParticipants.OtherNames = txtOtherNames.Text.Trim();
              //  oCMNParticipants.CountryID = cmbCountry.SelectedValue.ToString();

                //if (rbActive.Checked == true)
                //{
                //    oCMNParticipants.Status = 1;
                //}
                //else
                //{
                //    oCMNParticipants.Status = 2;
                //}

              //  oCMNParticipants.CardID = txtCardID.Text.Trim();
                oCMNParticipants.participantImage = imageToByteArray(ResizeImageFixedWidth(pbParticipantImage.Image, 157));
              //  oCMNParticipants.IDImage = imageToByteArray(ResizeImageFixedWidth(pbIDCardImage.Image, 157));

                return oCMNParticipants;
            }

        private void btnParticipantImage_Click_1(object sender, EventArgs e)
        {
            try
            {
                Myfile.Filter = "JPEG File(*.jpeg)|*.jpg|JPG File(*.jpg)|*.jpg|Bitmap(*.BMP)|*.bmp";
                Myfile.ShowDialog();
                System.IO.Stream _BitData = Myfile.OpenFile();
                Image image = Image.FromStream(_BitData);
                pbParticipantImage.Image = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
