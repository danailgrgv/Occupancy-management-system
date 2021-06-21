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
        public ucSettings ucSettings1 { get; set; }
        public ucStatistics()
        {
            InitializeComponent();
            Common_cpb(cpbOccupancy, (int)bldPrc);
            Common_cpb(cpbToilet, (int)bldPrc);
        }


        int toiletIn = 0, toiletLeft = 50, toiletMax = 50, bldPrc = 0;

        public int BuildingMax = 1000;//, co2 = 23;
        string message;


        public List<Gate> gateLst = new List<Gate>();
        List<Gate> toiletLst = new List<Gate>();

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
                        string[] mesArr = message.Split(splitChars);
                        changer(mesArr);
                    }
                    catch { }
                }
            }
            catch { }
        }


        private void changer(string[] arr)
        {
            string[] msgAgain = new string[arr.Length];
            arr.CopyTo(msgAgain, 0);

            try
            {
                if (arr[0].StartsWith("G"))
                {
                    arr[0] = arr[0].Remove(0, 1);
                    UInt32 gateNmr = UInt32.Parse(arr[0]);
                    var GateId = gateLst.Find(x => x.GateNumber == gateNmr && x.IsToilet == false);
                    if (GateId != null)
                    {
                        if (GateId.GateNumber == gateNmr)
                        {
                            if(arr[1].Contains("Q"))
                            {
                                GateId.queue = true;
                            }
                            else if(arr[1].Contains("N"))
                            {
                                GateId.queue = false;
                            }
                            else if (arr[1].Contains("HELP"))
                            {
                                btnAssistance(gateNmr, GateId.IsToilet);
                            }
                            else
                            {
                                int parsedValue = default(int);

                                int PrevPeople = GateId.Entered;
                                
                                if (int.TryParse(arr[1],out parsedValue) == true)
                                {
                                    int count = parsedValue - (GateId.Entered - GateId.Exited);


                                    if(count > 0)
                                    {
                                        GateId.Entered += count;
                                        Gate.Occupancy += count;
                                    }
                                    else if(count < 0)
                                    {
                                        if(Gate.Occupancy > 0)
                                        {
                                            GateId.Exited -= count;
                                            Gate.Occupancy += count;
                                        }
                                    }
                                    
                                    if(GateId.Entered > BuildingMax)
                                    {
                                        GateId.Entered = BuildingMax;
                                    }

                                    if(Gate.Occupancy >= BuildingMax)
                                    {
                                        Gate.Occupancy = BuildingMax;
                                    }

                                    if(Gate.Occupancy <= 0)
                                    {
                                        Gate.Occupancy = 0;
                                    }

                                    bldPrc = 0;

                                    if (Gate.Occupancy > 0)
                                    {
                                        bldPrc = (Gate.Occupancy * 100 / BuildingMax);
                                        Common_cpb(cpbOccupancy, (int)bldPrc);
                                    }
                                }
                            }

                            ucSettings1.update(GateId.GateNumber);

                            lblLeftPlaces.Text = "Remaining: " + (BuildingMax - Gate.Occupancy).ToString();
                            lblInsideBuilding.Text = "Inside: " + Gate.Occupancy.ToString();
                        }
                    }
                    else
                    {
                        Gate gate = new Gate(gateNmr,false);
                        gateLst.Add(gate);
                        ucSettings1.add(gate);
                        changer(msgAgain);
                    }
                }

                else if (arr[0].StartsWith("T"))
                {
                    arr[0] = arr[0].Remove(0, 1);
                    UInt32 toiletNum = UInt32.Parse(arr[0]);
                    var ToiletId = toiletLst.Find(x => x.GateNumber == toiletNum && x.IsToilet == true);
                    if (ToiletId != null)
                    {
                        if (ToiletId.GateNumber == toiletNum)
                        {
                            int parsedValue = default(int);

                            if(int.TryParse(arr[1],out parsedValue) == true)
                            {
                                ToiletId.Entered = parsedValue;
                                toiletIn = 0;

                                foreach (var item in toiletLst)
                                {
                                    toiletIn += item.Entered;
                                }

                                if (toiletIn >= toiletMax)
                                {
                                    toiletIn = toiletMax;
                                }

                                if (toiletIn <= toiletMax)
                                {
                                    toiletLeft = toiletMax - toiletIn;
                                }

                                int toilPrc = 0;

                                if (toiletIn > 0)
                                {
                                    toilPrc = (toiletIn * 100 / toiletMax);
                                    Common_cpb(cpbToilet, (int)toilPrc);
                                }
                            }
                        }
                        lblToiletLeft.Text = "Remaining: " + toiletLeft.ToString();
                        lblToiletIn.Text = "Inside: " + toiletIn.ToString();
                    }
                    else
                    {
                        toiletLst.Add(new Gate(toiletNum, true));
                        changer(msgAgain);
                    }
                }

                else if (arr[0].StartsWith("C"))
                {
                    int ppm = int.Parse(arr[1]);
                    ppmChange(ppm);
                }

                else if (arr[0].StartsWith("MAX"))
                {
                    timer1.Enabled = true;
                    BuildingMax = int.Parse(arr[1]);
                }
            }
            catch { }
        }

        private void btnAssist_Click(object sender, EventArgs e)
        {
            if (btnAssist.BackColor == Color.Red)
            {
                btnAssist.BackColor = Color.Lime;
                btnAssist.Text = "";
            }
        }

        private void btnAssistance(UInt32 number, bool toilet)
        {
            if(toilet)
            {
                btnAssist.BackColor = Color.Red;
                btnAssist.Text = $"Need Help\nToilet {number}";
            }
            else
            {
                btnAssist.BackColor = Color.Red;
                btnAssist.Text = $"Need Help\nGate {number}";
            }
        }

        private void btnMaxOccupancy_Click(object sender, EventArgs e)
        {
            if(!tbxMaxOccupancy.Text.Contains("Currently:"))
            {
                try
                {
                    BuildingMax = Convert.ToInt32(tbxMaxOccupancy.Text);
                    lblLeftPlaces.Text = "Remaining: " + BuildingMax.ToString();
                    bldPrc = (Gate.Occupancy * 100 / BuildingMax);
                    Common_cpb(cpbOccupancy, (int)bldPrc);
                }
                catch { MessageBox.Show("Wrong value!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
        }

        private void tbxMaxOccupancy_Leave_1(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void tbxMaxOccupancy_Enter(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            tbxMaxOccupancy.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tbxMaxOccupancy.Text = "Currently: " + BuildingMax.ToString();
            timer1.Enabled = false;
        }

        private void ppmChange(int co2)
        {
            //if (co2 > 29)
            //{
            //    co2 = 23;
            //}

            //if (co2 >= 26 && co2 < 28)
            //{
            //    lblCO2.ForeColor = Color.Orange;
            //}
            //else if (co2 >= 28)
            //{
            //    lblCO2.ForeColor = Color.Red;
            //}
            //else
            //{
            //    lblCO2.ForeColor = SystemColors.Control;
            //}

            lblCO2.Text = "CO2: " + co2.ToString() + "ppm";
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