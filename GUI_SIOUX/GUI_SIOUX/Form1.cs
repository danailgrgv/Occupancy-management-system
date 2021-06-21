using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace GUI_SIOUX
{
    public partial class Form1 : Form
    {
        public static ucSettings Settings { get; private set; }
        public Form1()
        {
            InitializeComponent();
            InitLoad();

            this.ucStettings1.ucStatistics1 = this.ucStatistics1;
            this.ucStatistics1.ucSettings1 = this.ucStettings1;
            Form1.Settings = this.ucStettings1;
            
            Task.Run(() =>
            {
                while (true)
                {
                    if (!ucStatistics1.serialPort1.IsOpen)
                    {
                        try
                        {
                            ucStatistics1.serialPort1.Open();
                        }
                        catch
                        {
                            Thread.Sleep(1000);
                        }
                    }
                    else
                        Thread.Sleep(5000);
                }
            });
        }

        private void pbLogo_MouseEnter(object sender, EventArgs e)
        {
            pbLogo.Image = GUI_SIOUX.Properties.Resources.Sioux_Logo31;
        }

        private void pbLogo_MouseLeave(object sender, EventArgs e)
        {
            pbLogo.Image = GUI_SIOUX.Properties.Resources.Sioux_Logo2;
        }

        private void timerNowTime_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToString();
        }

        private void InitLoad()
        {
            lbTime.Text = DateTime.Now.ToString();
            ucStettings1.Hide();
            ucStatistics1.Hide();
        }

        private void btnSetings_Click(object sender, EventArgs e)
        {
            ucStettings1.Show();
            ucStatistics1.Hide();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            ucStettings1.Hide();
            ucStatistics1.Show();
        }

        private void pbLogo_Click(object sender, EventArgs e)
        {
            ucStettings1.Hide();
            ucStatistics1.Hide();
        }
    }
}