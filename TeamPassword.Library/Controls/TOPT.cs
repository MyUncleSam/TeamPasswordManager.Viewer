using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OtpNet;

namespace TeamPassword.Library.Controls
{
    public partial class TOPT : UserControl
    {
        private Totp googleTotp = null;
        Label lblNothing = new Label();
        int? curTopt = null;
        public TOPT()
        {
            InitializeComponent();
            lblNothing.AutoSize = false;
            lblNothing.Text = "No 2FA";
            lblNothing.Font = new Font(lblNothing.Font.FontFamily, 8, FontStyle.Italic);
            lblNothing.ForeColor = Color.DarkGray;
            lblNothing.Dock = DockStyle.Fill;
            lblNothing.TextAlign = ContentAlignment.MiddleCenter;

            SetGoogleAuthenticatorSecrete(null);
        }

        public void SetGoogleAuthenticatorSecrete(string secret)
        {
            tMain.Stop();

            if (string.IsNullOrWhiteSpace(secret))
            {
                googleTotp = null;
                lblTotp.Text = "N/A";
                lblTimeRemaining.Text = "";
                pbMain.Value = 0;
            }
            else
            {
                try
                {
                    googleTotp = new Totp(Base32Encoding.ToBytes(secret));
                    tMain.Start();
                }
                catch
                {
                    tMain.Stop();
                    lblTotp.Text = "<invalid>";
                    googleTotp = null;
                }
            }

            TMain_Tick(null, null);
        }

        private void TMain_Tick(object sender, EventArgs e)
        {
            if (googleTotp == null)
            {
                curTopt = null;
                lblTotp.Cursor = Cursors.Default;
                return;
            }

            int remainingTime = googleTotp.RemainingSeconds();
            int compTotp = Convert.ToInt32(googleTotp.ComputeTotp());
            string readableTopt = MakeHumanReadable(compTotp.ToString());

            curTopt = compTotp;
            lblTotp.Cursor = Cursors.Hand;

            lblTimeRemaining.Text = remainingTime.ToString();
            lblTotp.Text = readableTopt;
            pbMain.Value = remainingTime;
        }

        public string MakeHumanReadable(string text, int splitEveryChar = 3)
        {
            int curPage = 0;
            string revText = new string(text.Reverse().ToArray());
            string curPart = new string(revText.ToArray().Skip(splitEveryChar * curPage++).Take(splitEveryChar).ToArray());

            List<string> resList = new List<string>();

            while (!string.IsNullOrWhiteSpace(curPart))
            {
                resList.Insert(0, new string(curPart.Reverse().ToArray()));
                curPart = new string(revText.ToArray().Skip(splitEveryChar * curPage++).Take(splitEveryChar).ToArray());
            }

            return string.Join(" ", resList);
        }

        private void LblTotp_Click(object sender, EventArgs e)
        {
            if (curTopt != null)
                Functions.ClipboardManager.GetInstance().SetText(curTopt.ToString());
        }
    }
}
