using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVC_3
{
    class PvcP8 : ObjectPVC
    {
        private decimal costOfBlinds = 0;
        public decimal CostOfBlinds { get; private set; }

        public PvcP8(int numberOfObjects, int height, int width)
            : base(numberOfObjects, height, width)
        {
        }

        public decimal CalculateCostOfOnlyOneBlinds(bool checkBoxBlinds)
        {
            decimal costOfOneBlinds = 0;
            if (checkBoxBlinds)
            {
                costOfBlinds = 0.012M;
                costOfOneBlinds = costOfBlinds * CalculateDimension(heihgt, width);
                return costOfOneBlinds;
            }
            return costOfOneBlinds;
        }

        public string CalculateCostOfAllBlinds(bool checkBoxBlinds)
        {
            decimal finalCostOfAllBlinds = 0;
            if (checkBoxBlinds)
            {
                finalCostOfAllBlinds = numberOfObjects * CalculateCostOfOnlyOneBlinds(checkBoxBlinds);
            }
            return finalCostOfAllBlinds.ToString("0,0.00.##");
        }
    }
}
