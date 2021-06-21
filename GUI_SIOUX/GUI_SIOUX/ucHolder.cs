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
        int currentAmount;
        int prevExited;

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
            currentAmount = default(int);
            prevExited = default(int);
            this.Dock = DockStyle.Fill;
            lbQueue.Hide();
        }

        private void setup()
        {
            this.lbGateNr.Text = "Gate " + this.Gate.GateNumber.ToString();
        }

        public void Refresher()
        {
            if (Gate.queue == true)
                lbQueue.Show();
            else if(Gate.queue == false)
                lbQueue.Hide();

            lbPass.Text = "Entered: " + Gate.Entered.ToString();
            lbExit.Text = "Exited: " + Gate.Exited.ToString();

            if(Gate.Entered > 0)
            {
                if (pictureBox1.Image != GUI_SIOUX.Properties.Resources.access_1_)
                {
                    Task.Run(() =>
                    {
                        if (prevExited < Gate.Exited) 
                        {
                            pictureBox1.Image = GUI_SIOUX.Properties.Resources.access_2_;
                            Thread.Sleep(5000);
                            pictureBox1.Image = GUI_SIOUX.Properties.Resources.access_3_;
                        }
                        else if(currentAmount < Gate.Entered)
                        {
                            pictureBox1.Image = GUI_SIOUX.Properties.Resources.access_1_;
                            Thread.Sleep(5000);
                            pictureBox1.Image = GUI_SIOUX.Properties.Resources.access_3_;
                        }
                        currentAmount = Gate.Entered;
                        prevExited = Gate.Exited;
                    });
                }
            }
        }

        private void pbDelete_Click(object sender, EventArgs e)
        {
            Form1.Settings.delete(gate);
        }
    }
}
