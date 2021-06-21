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
    public partial class ucSettings : UserControl
    {
        public ucStatistics ucStatistics1 { get; set; }
        private List<ucHolder> hold { get; set; }
        public ucSettings()
        {
            InitializeComponent();
            tlpGates.AutoScroll = false;
            tlpGates.HorizontalScroll.Enabled = false;
            tlpGates.HorizontalScroll.Visible = false;
            tlpGates.HorizontalScroll.Maximum = 0;
            tlpGates.AutoScroll = true;
            hold = new List<ucHolder>();
        }

        public void add(Gate gate)
        {
            tlpGates.SuspendLayout();
            ucHolder holder = new ucHolder();
            holder.Gate = gate;
            hold.Add(holder);
            tlpGates.Controls.Add(holder);
            tlpGates.ResumeLayout();
        }

        public void delete(Gate gate)
        {
            tlpGates.SuspendLayout();
            var uc = hold.Find(x => x.Gate.GateNumber == gate.GateNumber);
            tlpGates.Controls.Remove(uc);
            hold.Remove(uc);
            ucStatistics1.gateLst.Remove(gate);
            tlpGates.ResumeLayout();
        }

        public void update(UInt32 gateNum)
        {
            ucHolder gate = hold.Find(x => x.Gate.GateNumber == gateNum);
            gate.Refresher();

        }
    }
}
