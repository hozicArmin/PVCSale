using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVC_3
{
    class PvcP7 : ObjectPVC
    {
        private decimal costOfDoor = 0;
        //public decimal CostOfDoor { get; private set; }

        private bool a700; //Aluplast
        private bool a900;
        private bool a1100;
        private bool a1300;
        private bool a1500;
        private bool w300;  //Wintech
        private bool w500;
        private bool w700;

        public PvcP7(int numberOfObjects, int height, int width)
            : base(numberOfObjects, height, width)
        { }

        public decimal CalculateCostOfOneDoorAluplast(bool checkBoxIdeal, bool a7, bool a9, bool a11, bool a13, bool a15)
        {
            a700 = a7;    //Ovo je postavka za reference koje je trebalo provuci kroz konstruktor klase koja je 
            a900 = a9;    //u ovom metodu trebala biti referenca i u nj. kreirati vise overloaded konstruktora 
            a1100 = a11;  //i prosljediti reference u toj drugoj klasi. Tako da se ne desava da imam 
            a1300 = a13;  //konstruktore koji sadrze vise od 3 parametra
            a1500 = a15;

            if (checkBoxIdeal)
            {
                if (a7)
                    return costOfDoor = 700.00M;
                else if (a9)
                    return costOfDoor = 900.00M;
                else if (a11)
                    return costOfDoor = 1100.00M;
                else if (a13)
                    return costOfDoor = 1300.00M;
                else if (a15)
                    return costOfDoor = 1500.00M;
                else
                    return costOfDoor = 0;
            }
            else
                return costOfDoor = 0;
        }

        public decimal CalculateCostOfOneDoorWintech(bool checkBoxWintech, bool w3, bool w5, bool w7)
        {
            w300 = w3; //Ovo je postavka za reference koje je trebalo provuci kroz konstruktor klase koja je 
            w500 = w5; //u ovom metodu trebala biti referenca i u nj. kreirati vise overloaded konstruktora
            w700 = w7;  //i prosljediti reference u toj drugoj klasi. Tako da se ne desava da imam 
                        //komstruktore koji sadrze vise od 3 parametra

            if (checkBoxWintech)
            {
                if (w3)
                    return costOfDoor = 300.00M;
                else if (w5)
                    return costOfDoor = 500.00M;
                else if (w7)
                    return costOfDoor = 700.00M;
                else
                    return costOfDoor = 0;
            }
            else
                return costOfDoor = 0;
        }

        public string CalculateCostOfAllDoors()
        {
            decimal totalCost = costOfDoor * numberOfObjects;
            return totalCost.ToString("0,0.00.##");
        }
    }
}
