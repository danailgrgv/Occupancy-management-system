using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_SIOUX
{
    public class Gate
    {
        public static int Occupancy { get; set; }
        public UInt32 GateNumber { get; set; }
        public int Entered { get; set; }
        public int Exited { get; set; }
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
            this.Entered = 0;
            this.Exited = 0;
            this.GateNumber = toiletNum;
        }
    }
}
