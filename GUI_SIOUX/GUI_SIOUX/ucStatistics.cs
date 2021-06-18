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

        }

        int pplIn = 0, pplRem = 150, toiletIn = 0, toiletLeft = 50, toiletMax = 50, BuildingMax = 150;//, co2 = 23;
        
        string message;
        List<Gate> gateLst = new List<Gate>();
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
                        string[] arr = message.Split(splitChars);
                        changer(arr);
                        //ucSettings1.update();
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


        private void changer(string[] arr)
        {
            //try 
            //{
            //    if (arr[0].StartsWith("G"))
            //    {
            //        arr[0] = arr[0].Remove(0, 1);
            //        int gateNmr = int.Parse(arr[0]);
            //        var GateId = gateLst.Find(x => x.GateNumber == gateNmr && x.IsToilet == false);
            //        if(GateId != null)
            //        {
            //            if (GateId.GateNumber == gateNmr)
            //            {
            //                if (arr[1].Contains("+1"))
            //                {
            //                    if(pplIn < BuildingMax)
            //                    {
            //                        GateId.GateCounter++;
            //                        pplIn++;
            //                        pplRem--;
            //                    }
            //                }
            //                else if (arr[1].Contains("-1"))
            //                {
            //                    if (GateId.GateCounter > 0)
            //                    {
            //                        GateId.GateCounter--;
            //                        pplIn--;
            //                        pplRem++;
            //                    }
            //                }
            //                else if (arr[1].Contains("ALARM"))
            //                {
            //                    btnAssistance(gateNmr, GateId.IsToilet);
            //                }

            //                if (pplRem <= 0)
            //                {
            //                    pplIn = 0;
            //                    pplRem = 150;
            //                }
            //                int bldPrc = 0;
            //                if (pplIn > 0)
            //                {
            //                    bldPrc = (pplIn * 100 / BuildingMax);
            //                    Common_cpb(cpbOccupancy, (int)bldPrc);
            //                }

            //                Common_cpb(cpbOccupancy, (int)bldPrc);

            //                lblLeftPlaces.Text = "Remaining: " + pplRem.ToString();
            //                lblInsideBuilding.Text = "Inside: " + pplIn.ToString();
            //            }
            //        }
            //        else
            //            gateLst.Add(new Gate(gateNmr,false));
            //    }

            //    else if (arr[0].StartsWith("T"))
            //    {
            //        arr[0] = arr[0].Remove(0, 1);
            //        int toiletNum = int.Parse(arr[0]);
            //        var ToiletId = toiletLst.Find(x => x.GateNumber == toiletNum && x.IsToilet == true);
            //        if(ToiletId != null)
            //        {
            //            if(ToiletId.GateNumber == toiletNum)
            //            {
            //                if (arr[1].Contains("+1"))
            //                {
            //                    if(toiletIn < toiletMax)
            //                    {
            //                        ToiletId.GateCounter++;
            //                        toiletIn++;
            //                        toiletLeft--;
            //                    }
            //                }
            //                else if (arr[1].Contains("-1"))
            //                {
            //                    if (ToiletId.GateCounter > 0)
            //                    {
            //                        ToiletId.GateCounter--;
            //                        toiletIn--;
            //                        toiletLeft++;
            //                    }
            //                }
            //                //else if (arr[1].Contains("ALARM"))
            //                //{
            //                //    btnAssistance(toiletNum, ToiletId.IsToilet);
            //                //}
            //            }
            //        }
            //        else
            //            toiletLst.Add(new Gate(toiletNum, true));

            //        if (toiletLeft <= 0)
            //        {
            //            toiletIn = 0;
            //            toiletLeft = toiletMax;
            //        }
            //        int toilPrc = 0;
            //        if (toiletIn > 0)
            //        {
            //            toilPrc = (toiletIn * 100 / toiletMax);
            //            //Common_cpb(cpbToilet, (int)toilPrc);
            //        }
            //        Common_cpb(cpbToilet, (int)toilPrc);

            //        lblToiletLeft.Text = "Remaining: " + toiletLeft.ToString();
            //        lblToiletIn.Text = "Inside: " + toiletIn.ToString();
            //    }

            //    else if (arr[0].StartsWith("C"))
            //    {
            //        int ppm = int.Parse(arr[1]);
            //        ppmChange(ppm);
            //    }
            //}
            //catch { }



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

                                if (int.TryParse(arr[1],out parsedValue) == true)
                                {
                                    GateId.GateCounter = parsedValue;
                                    pplIn = 0;

                                    foreach (var item in gateLst)
                                    {
                                        pplIn += item.GateCounter;
                                    }

                                    if(pplIn >= BuildingMax)
                                    {
                                        pplIn = BuildingMax;
                                    }

                                    if (pplIn <= BuildingMax)
                                    {
                                        pplRem = BuildingMax - pplIn;
                                    }

                                    int bldPrc = 0;

                                    if (pplIn > 0)
                                    {
                                        bldPrc = (pplIn * 100 / BuildingMax);
                                        Common_cpb(cpbOccupancy, (int)bldPrc);
                                    }
                                }
                            }

                            ucSettings1.update(GateId.GateNumber);

                            lblLeftPlaces.Text = "Remaining: " + pplRem.ToString();
                            lblInsideBuilding.Text = "Inside: " + pplIn.ToString();
                        }
                    }
                    else
                    {
                        Gate gate = new Gate(gateNmr,false);
                        gateLst.Add(gate);
                        ucSettings1.add(gate);
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
                                ToiletId.GateCounter = parsedValue;
                                toiletIn = 0;

                                foreach (var item in toiletLst)
                                {
                                    toiletIn += item.GateCounter;
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
                        toiletLst.Add(new Gate(toiletNum, true));
                }

                else if (arr[0].StartsWith("C"))
                {
                    int ppm = int.Parse(arr[1]);
                    ppmChange(ppm);
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


        private void ppmChange(int co2)
        {
            if (co2 > 29)
            {
                co2 = 23;
            }

            if (co2 >= 26 && co2 < 28)
            {
                lblCO2.ForeColor = Color.Orange;
            }
            else if (co2 >= 28)
            {
                lblCO2.ForeColor = Color.Red;
            }
            else
            {
                lblCO2.ForeColor = SystemColors.Control;
            }

            lblCO2.Text = "CO2: " + co2.ToString() + "ppm";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //serialPort1.WriteLine("ON");
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
