using System;

namespace Banque
{
    class Dollar : Devise
    {

        static double tauxM = 9.27;
        static double tauxE = 0.89;
        public Dollar(double val) : base(val)
        {
        }
        public override void print()
        {
            base.print();
            Console.WriteLine(" $ \n");
        }
        override public MAD convertToMAD()
        {
            MAD d = new MAD(this.calculVal(Dollar.tauxM));
            return d;
        }
        override public Euro convertToEuro()
        {
            Euro d = new Euro(this.calculVal(Dollar.tauxE));
            return d;
        }

        override public Dollar convertToDollar()
        {
            return this;
        }
        public override string ToString()
        {
            return base.ToString() + " $";
        }
    }
}
