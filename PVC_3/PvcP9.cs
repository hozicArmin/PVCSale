using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVC_3
{
    class PvcP9 : ObjectPVC
    {
        private decimal costOfFencePer_m2 = 0;
        public decimal CostOfFencePer_m2 { get; private set; }


        public PvcP9(int numberOfObjects, int height, int width)
            : base(numberOfObjects, height, width)
        {
        }

        public decimal CalculateCostOfFencePer_m2(bool cBFence, bool f80, bool f90, bool f100, bool f110, bool f120, bool f130, bool f140, bool f150)
        {
            if (cBFence)
            {
                if (f80)
                {
                    costOfFencePer_m2 = .008M;
                    decimal cost = costOfFencePer_m2 * CalculateDimension(heihgt, width);
                    return cost;
                }
                else if (f90)
                {
                    costOfFencePer_m2 = .009M;
                    decimal cost = costOfFencePer_m2 * CalculateDimension(heihgt, width);
                    return cost;
                }
                else if (f100)
                {
                    costOfFencePer_m2 = .010M;
                    decimal cost = costOfFencePer_m2 * CalculateDimension(heihgt, width);
                    return cost;
                }
                else if (f110)
                {
                    costOfFencePer_m2 = .011M;
                    decimal cost = costOfFencePer_m2 * CalculateDimension(heihgt, width);
                    return cost;
                }
                else if (f120)
                {
                    costOfFencePer_m2 = .012M;
                    decimal cost = costOfFencePer_m2 * CalculateDimension(heihgt, width);
                    return cost;
                }
                else if (f130)
                {
                    costOfFencePer_m2 = .013M;
                    decimal cost = costOfFencePer_m2 * CalculateDimension(heihgt, width);
                    return cost;
                }
                else if (f140)
                {
                    costOfFencePer_m2 = .014M;
                    decimal cost = costOfFencePer_m2 * CalculateDimension(heihgt, width);
                    return cost;
                }
                else if (f150)
                {
                    costOfFencePer_m2 = .015M;
                    decimal cost = costOfFencePer_m2 * CalculateDimension(heihgt, width);
                    return cost;
                }
                else
                    return costOfFencePer_m2 = 0;
            }
            else
                return costOfFencePer_m2 = 0;
        }

        public string CalculateCostOfAllFence(bool cBFence, bool f80, bool f90, bool f100, bool f110, bool f120, bool f130, bool f140, bool f150)
        {
            decimal costOfAllFence = numberOfObjects * CalculateCostOfFencePer_m2(cBFence, f80, f90, f100, f110, f120, f130, f140, f150);
            return costOfAllFence.ToString("0,0.00.##");
        }
    }
}
