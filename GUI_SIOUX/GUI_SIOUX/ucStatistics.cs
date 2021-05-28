using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_SIOUX
{
    public partial class ucStatistics : UserControl
    {
        public ucStatistics()
        {
            InitializeComponent();

        }

        int pplIn = 0, pplRem = 150, toiletIn = 0, toiletLeft = 50, co2 = 23;
        
        string message;
        List<Gate> gates = new List<Gate>();

        private void ucStatistics_Leave(object sender, EventArgs e)
        {
            serialPort1.Close();
        }

        public char[] splitChars = { '#' };


        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            while(serialPort1.BytesToRead > 0)
            {
                message = serialPort1.ReadLine();
                Handler();
            }
        }

        private void Handler()
        {
            try
            {
                if (InvokeRequired)
                    Invoke(new MethodInvoker(Handler));
                else
                {
                    try
                    {
                        string[] arr = message.Split(splitChars);
                        if(message.StartsWith("G"))
                        {
                            arr[0] = arr[0].Remove(0,1);
                            
                            try
                            {

                                int gateNmr = int.Parse(arr[0]);
                                var id = gates.Find(x => x.GateNumber == gateNmr);
                                if(id != null)
                                {
                                    if(id.GateNumber == gateNmr)
                                    {
                                        if (arr[1].Contains("+1"))
                                        {
                                            id.GateCounter++;
                                            pplIn++;
                                            pplRem--;
                                        }

                                        else if (arr[1].Contains("-1"))
                                        {
                                            if(id.GateCounter > 0)
                                            {
                                                id.GateCounter--;
                                                pplIn--;
                                                pplRem++;
                                            }
                                        }

                                        else if(arr[1].Contains("ALARM"))
                                        {
                                            btnAssistance();
                                        }
                                    }
                                }
                                else
                                    gates.Add(new Gate(gateNmr));
                            }
                            catch
                            {

                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
        }



        private void btnAssist_Click(object sender, EventArgs e)
        {
            if (btnAssist.BackColor == Color.Red)
            {
                btnAssist.BackColor = Color.Lime;
                btnAssist.Text = "";
            }
            else
            {
                btnAssist.BackColor = Color.Red;
                btnAssist.Text = "Need Help\nGate x";
            }
        }


        private void btnAssistance()
        {
            if (btnAssist.BackColor == Color.Red)
            {
                btnAssist.BackColor = Color.Lime;
                btnAssist.Text = "";
            }
            else
            {
                btnAssist.BackColor = Color.Red;
                btnAssist.Text = "Need Help\nGate x";
            }
        }


        double q, w;
        private void timer1_Tick(object sender, EventArgs e)
        {

            if(co2 >29)
            {
                co2 = 23;
            }

            if(co2 >= 26 && co2 < 28)
            {
                lblCO2.ForeColor = Color.Orange;
            }
            else if(co2 >= 28)
            {
                lblCO2.ForeColor = Color.Red;
            }
            else
            {
                lblCO2.ForeColor = SystemColors.Control;
            }

            lblCO2.Text = "CO2: " + co2.ToString() + "ppm";

            if(pplRem <= 0)
            {
                pplIn = 0;
                pplRem = 150;
            }

            if (toiletLeft <= 0)
            {
                toiletIn = 0;
                toiletLeft = 50;
            }

            lblLeftPlaces.Text = "Remaining: " + pplRem.ToString();
            lblInsideBuilding.Text = "Inside: " + pplIn.ToString();

            lblToiletLeft.Text = "Remaining: " + toiletLeft.ToString();
            lblToiletIn.Text = "Inside: " + toiletIn.ToString();

            //i = (int)(pplIn * 0.1);
            
            if (pplIn > 0)
            {
                q = (pplIn*100/150);
            }
            if(toiletIn > 0)
            {
                w = (toiletIn*100/50);
            }

            Common_cpb(cpbOccupancy, (int)q);
            Common_cpb(cpbToilet, (int)w);
        }


        private void Common_cpb(CircularProgressBar.CircularProgressBar sender, int value)
        {
            CircularProgressBar.CircularProgressBar cpb = sender as CircularProgressBar.CircularProgressBar;

            if (value >= 50 && value < 75)
            {
                cpb.ProgressColor = Color.Yellow;
                cpb.ForeColor = Color.Yellow;
            }
            else if (value >= 75 && value < 95)
            {
                cpb.ProgressColor = Color.Orange;
                cpb.ForeColor = Color.Orange;
            }
            else if (value >= 95)
            {
                cpb.ProgressColor = Color.Red;
                cpb.ForeColor = Color.Red;
            }
            else
            {
                cpb.ProgressColor = Color.FromArgb(85, 213, 219);
                cpb.ForeColor = SystemColors.Control;
            }

            cpb.Value = value;
            cpb.Text = value.ToString() + "%";
        }
    }
}
