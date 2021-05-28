using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_SIOUX
{
    class Gate
    {
        public int GateNumber { get; set; }
        public int GateCounter { get; set; }


        public Gate(int gateNumb)
        {
            this.GateNumber = gateNumb;
            this.GateCounter = 0;
        }
    }
}
