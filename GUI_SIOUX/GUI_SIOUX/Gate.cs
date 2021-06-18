using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_SIOUX
{
    public class Gate
    {
        //public int GateNumber { get; set; }

        public UInt32 GateNumber { get; set; }
        public int GateCounter { get; set; }
        public bool IsToilet { get; }
        public bool queue { get; set; }

        //public Gate(int gateNumb)
        //{
        //    this.GateNumber = gateNumb;
        //    this.GateCounter = 0;
        //    //this.IsToilet = toilet;
        //}

        //public Gate(int toiletNum, bool toilet)
        //{
        //    this.IsToilet = toilet;
        //    this.GateCounter = 0;
        //    this.GateNumber = toiletNum;
        //}

        public Gate(UInt32 toiletNum, bool toilet)
        {
            this.IsToilet = toilet;
            this.GateCounter = 0;
            this.GateNumber = toiletNum;
        }
    }
}
