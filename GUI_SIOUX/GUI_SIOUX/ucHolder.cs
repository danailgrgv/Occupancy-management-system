using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace GUI_SIOUX
{
    public partial class ucHolder : UserControl
    {
        public Gate Gate
        {
            get
            {
                return gate;
            }
            set
            {
                gate = value;
                this.setup();
            }

        }

        private Gate gate;
        public ucHolder()
        {
            InitializeComponent();
            //int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;
            //tableLayoutPanel1.Padding = new Padding(0, 0, vertScrollWidth, 0);
            this.Dock = DockStyle.Fill;
        }

        private void setup()
        {
            this.lbGateNr.Text = "Gate " + this.Gate.GateNumber.ToString();
        }

        public void Refresher()
        {
            //if(pictureBox1.Image = GUI_SIOUX.Properties.Resources.access_3_;)

            if (Gate.queue == true)
                lbQueue.Show();
            else if(Gate.queue == false)
                lbQueue.Hide();
                

            lbPass.Text = "Passed: " + Gate.GateCounter.ToString();

            if (pictureBox1.Image != GUI_SIOUX.Properties.Resources.access_1_)
            {
                Task.Run(() =>
                {
                    pictureBox1.Image = GUI_SIOUX.Properties.Resources.access_1_;
                    Thread.Sleep(5000);
                    pictureBox1.Image = GUI_SIOUX.Properties.Resources.access_3_;
                    
                });
            }
        }
    }
}
