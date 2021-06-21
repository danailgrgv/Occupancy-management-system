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

namespace GateDisplay
{
    public partial class Form1 : Form
    {
        public char[] splitChars = { '#' };


        string message;
        public Form1()
        {
            InitializeComponent();
            
            //refreshLabels("1", "CLOSED", "0");

            Task.Run(() =>
            {
                while (true)
                {
                    if (!spGate.IsOpen)
                    {
                        try
                        {
                            spGate.Open();
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

        /// <summary>
        /// Refreshes the text in the labels on the display
        /// </summary>
        void refreshLabels(string gateID, string gateState, string otherGate)
        {
            lblID.Text = "GATE " + gateID;

            if(gateState == "C")
            {
                lblState.Text = "CLOSED";
            }
            else
            {
                lblState.Text = "OPEN";
            }

            lblOtherGate.Text = "Gate overloaded, go to gate " + otherGate;


            if(gateState == "C")
            {
                otherGate.Trim();
                if(otherGate.StartsWith("0"))
                {
                    lblOtherGate.Text = "Building is full!";
                }

                
                BackColor = Color.Red;
                lblOtherGate.Visible = true;
            }
            else
            {
                BackColor = Color.YellowGreen;
                lblOtherGate.Visible = false;
            }

        }

        private void spGate_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if(spGate.BytesToRead > 0)
            {
                message = spGate.ReadLine();
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
                        string[] msgArr = message.Split(splitChars);
                        Changer(msgArr);

                    }
                    catch { }
                }
            }
            catch { }
        }


        private void Changer(string[] arr)
        {
            try
            {
                // G#<id>#<state>#<other gate id>
                if (arr[0].StartsWith("I"))
                {
                    refreshLabels(arr[1], arr[2], arr[3]);
                }
            }
            catch { }
        }

    }
}
