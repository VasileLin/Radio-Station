using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using WMPLib;
using System.Threading;
using System.Management;

namespace Dashboard
{
    public partial class Form1 : Form
    {
        private void RefreshStatus()
        {
            PowerStatus pwr = SystemInformation.PowerStatus;

             charge.Text = pwr.BatteryChargeStatus.ToString();
            Percentage.Text = pwr.BatteryLifePercent.ToString("P0");
            if (pwr.BatteryLifeRemaining > 0)
                life.Text = $"{pwr.BatteryLifeRemaining / 3600} hr {(pwr.BatteryLifeRemaining % 3600) / 60} min remaining";

           

            switch (pwr.PowerLineStatus)
             {
                 case (PowerLineStatus.Offline):
                    charge.Text = "not Plugged in";
                    charging.Visible = false;
                    Nocharge.Visible = true;
                     break;

                 case (PowerLineStatus.Online):
                    charge.Text = "plugged in";
                    charging.Visible = true;
                    Nocharge.Visible = false;
                    break;
             }

           
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        
        private static extern IntPtr CreateRoundRectRgn
         (
               int nLeftRect,
               int nTopRect,
               int nRightRect,
               int nBottomRect,
               int nWidthEllipse,
               int nHeightEllipse

         );


        
        public Form1()
        {
           
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnDashbord.Height;
            pnlNav.Top = btnDashbord.Top;
            pnlNav.Left = btnDashbord.Left;
            btnDashbord.BackColor = Color.FromArgb(46, 51, 73);
            lbltitle.Text = "Radio Station";
            OnlineImg.Visible = false;
            Application.AddMessageFilter(new ScrollableControls(panel3));

        }

       [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int conn, int val);



        private void btnDashbord_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDashbord.Height;
            pnlNav.Top = btnDashbord.Top;
            pnlNav.Left = btnDashbord.Left;
            btnDashbord.BackColor = Color.FromArgb(46, 51, 73);
            lbltitle.Text = "Radio Station";
        }



        private void btnsettings_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnsettings.Height;
            pnlNav.Top = btnsettings.Top;
            btnsettings.BackColor = Color.FromArgb(46, 51, 73);
            About about = new About();
            about.Show();
        }

       

        private void btnDashbord_Leave(object sender, EventArgs e)
        {
            btnDashbord.BackColor = Color.FromArgb(24, 30, 54);
        }


        private void btnsettings_Leave(object sender, EventArgs e)
        {
            btnsettings.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }



        Point lastPoint;



        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToLongTimeString();
            Date.Text = DateTime.Now.ToLongDateString();
        }

        private void RadioRecordbutton_Click_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://91.227.68.150:10000/hit128?75";
        }

        private void EuropaPlusButton_Click_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://217.26.167.180:8081/broadwave.mp3";
        }

        private void RadioZuBtn_Click_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://82.208.137.144:8004";
        }

        private void profmbtn_Click_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://s2.metaradio.ru/mradio.orbox2";
        }

        private void Diasporabtn_Click_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://radio-holding.ru:9000/marusya_default";
        }

        private void muzzfmbtn_Click_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = " http://live.muzfm.md:8000/muzfm";
        }

        private void zaycevfmclick(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "https://zaycevfm.cdnvideo.ru/ZaycevFM_pop_128.mp3";
        }

        private void hypefmclick(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "https://hfm.volna.top/HypeFM";
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            timer1.Start();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "https://listen.megahit.online/megamp128";
        }

        private void Zumbtn_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://185.181.229.196:8000/live";
        }

        private void Studentusbtn_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://45.137.229.69:8000/live";
        }

        private void Megapolis_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "https://megapolisfm.md:8443/886aac";
        }

        private void ProDjbtn_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://live.prodjradio.net:8050/";
        }

        private void Deepbtn_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "https://r51-158-108-249.relay.radiotoolkit.com:30003/rcmdeep";
        }

        private void DFMbtn_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "https://dfm.hostingradio.ru/dfm96.aacp";
        }

        private void RusMixbtn_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "https://icecast-astvru.cdnvideo.ru/astvru";
        }

        private void axWindowsMediaPlayer1_Buffering_1(object sender, AxWMPLib._WMPOCXEvents_BufferingEvent e)
        {
            int Out;

            if (InternetGetConnectedState(out Out, 0) == true)
            {
                ConnectedLabel.Visible = true;
                OfflineLabel.Visible = false;
                OfflineImg.Visible = false;
                OnlineImg.Visible = true;
               
            }
            else
            {
                ConnectedLabel.Visible = false;
                OfflineLabel.Visible = true;
                OfflineImg.Visible = true;
                OnlineImg.Visible = false;

            }

        }  


        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            RefreshStatus(); 
        }
            

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshStatus();
            timer2.Enabled = true;
        }

        private void panel9_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel9_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }

}
