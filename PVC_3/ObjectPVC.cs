using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PVC_3
{
    abstract class ObjectPVC
    {

        private decimal costOfWindowPer_m2 = 0;
        private bool ideal400;
        private bool ideal500;
        private bool ideal800;
        private bool wintech5;
        private bool wintech6;

        protected int numberOfObjects;
        public int NumberOfObjects
        {
            get { return numberOfObjects; }
            set { this.numberOfObjects = value; }
        }

        protected int heihgt;
        public int Height
        {
            get { return heihgt; }
            set { this.heihgt = value; }
        }

        protected int width;
        public int Width
        {
            get { return width; }
            set { this.width = value; }
        }

        public ObjectPVC(int numberOfObjects, int height, int width)
        {
            this.numberOfObjects = numberOfObjects;
            this.heihgt = height;
            this.width = width;
        }

        public int CalculateDimension(int height, int width)
        {
            int dimension = heihgt * width;
            return dimension;
        }

        public decimal CostOfAluplastWindowPer_m2(bool i4, bool i5, bool i8)
        {
            ideal400 = i4;
            ideal500 = i5;
            ideal800 = i8;

            if (ideal400)
                return costOfWindowPer_m2 = 0.019M; //setting price per cm2
            else if (ideal500)
                return costOfWindowPer_m2 = .0205M;
            else if (ideal800)
                return costOfWindowPer_m2 = .0220M;
            else
                return costOfWindowPer_m2 = .00M;
        }

        public decimal CostOfWintechWindowPer_m2(bool w5, bool w6)
        {
            wintech5 = w5;
            wintech6 = w6;

            if (wintech5)
                return costOfWindowPer_m2 = .0140M;
            else if (wintech6)
                return costOfWindowPer_m2 = .0160M;
            else
                return costOfWindowPer_m2 = .00M;
        }

        public string SetAluplastProfil(bool i4, bool i5, bool i8)
        {
            ideal400 = i4;
            ideal500 = i5;
            ideal800 = i8;

            if (i4)
                return "Aluplast IDEAL 4000, 5-komorni sistem";
            else if (i5)
                return "Aluplast IDEAL 5000, 5-komorni sistem";
            else if (i8)
                return "Aluplast IDEAL 8000, 6-komorni sistem";
            else
                return "Izaberi profil";
        }

        public string SetWintechProfil(bool w5, bool w6)
        {
            wintech5 = w5;
            wintech6 = w6;

            if (w5)
                return "WINTECH 5-komorni sistem";
            else if (w6)
                return "WINTECH 6-komorni sistem";
            else
                return "Izaberi profil";
        }

        public string CalculateOnlyOne()
        {
            decimal totalCost = costOfWindowPer_m2 * CalculateDimension(heihgt, width);
            return totalCost.ToString("0,0.00.##");
        }

        public string CalculateCostOfAll(bool isoGlass)
        {
            decimal totalCost = numberOfObjects * decimal.Parse(CalculateOnlyOne());
            if (isoGlass)
            {
                totalCost += (totalCost * 0.10M);
                return totalCost.ToString("0,0.00.##");
            }
            else
                return totalCost.ToString("0,0.00.##");
        }
    }
}
