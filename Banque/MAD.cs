using System;

namespace Banque
{
    class MAD : Devise
    {
        static double tauxD = 0.11;
        static double tauxE = 0.096;
        public MAD(double val) : base(val)
        {
        }
        public override void print()
        {
            base.print();
            Console.WriteLine(" DH \n");
        }
        override public MAD convertToMAD()
        {
            return this;
        }
        override public Euro convertToEuro()
        {
            Euro d = new Euro(this.calculVal(MAD.tauxE));
            return d;
        }

        override public Dollar convertToDollar()
        {
            Dollar d = new Dollar(this.calculVal(MAD.tauxD));
            return d;
        }

        public override string ToString()
        {
            return base.ToString() + " DH";
        }



    }
}
