using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVC_3
{
    class PvcP10
    {
        private decimal costOfSillsPer_m = 0;
        private int numberOfObjects;
        public int NumberOfObjects
        {
            get { return numberOfObjects; }
            set { this.numberOfObjects = value; }
        }

        protected int width;
        public int Width
        {
            get { return width; }
            set { this.width = value; }
        }

        public PvcP10(int numberOfObjects, int width)
        {
            this.numberOfObjects = numberOfObjects;
            this.width = width;
        }

        public decimal CalculateCostOfSillsPer_m(bool checkBSills, bool rS10, bool rS20, bool rS30, bool rS40, bool rS50)
        {
            if (checkBSills)
            {
                if (rS10)
                {
                    costOfSillsPer_m = .10M; //Postavljamo KM po cm2
                    decimal cost = costOfSillsPer_m * width;
                    return cost;
                }
                else if (rS20)
                {
                    costOfSillsPer_m = .20M;
                    decimal cost = costOfSillsPer_m * width;
                    return cost;
                }
                else if (rS30)
                {
                    costOfSillsPer_m = .30M;
                    decimal cost = costOfSillsPer_m * width;
                    return cost;
                }
                else if (rS40)
                {
                    costOfSillsPer_m = .40M;
                    decimal cost = costOfSillsPer_m * width;
                    return cost;
                }
                else if (rS50)
                {
                    costOfSillsPer_m = .50M;
                    decimal cost = costOfSillsPer_m * width;
                    return cost;
                }
                else
                    return costOfSillsPer_m = .00M;
            }
            else
                return costOfSillsPer_m = .00M;
        }

        public decimal CalculateCostOfAllSills(bool checkBSills, bool rS10, bool rS20, bool rS30, bool rS40, bool rS50)
        {
            decimal costOfAllFence = numberOfObjects * CalculateCostOfSillsPer_m(checkBSills, rS10, rS20, rS30, rS40, rS50);
            return costOfAllFence;
        }
    }
}
