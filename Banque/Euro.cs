using System;

namespace Banque
{
    class Euro : Devise
    {

        static double tauxM = 10.44;
        static double tauxD = 1.13;
        public Euro(double val) : base(val)
        {
        }
        public override void print()
        {
            base.print();
            Console.WriteLine(" € \n");
        }
        override public MAD convertToMAD()
        {
            MAD d = new MAD(this.calculVal(Euro.tauxM));
            return d;
        }
        override public Euro convertToEuro()
        {
            return this;
        }

        override public Dollar convertToDollar()
        {
            Dollar d = new Dollar(this.calculVal(Euro.tauxD));
            return d;
        }
        public override string ToString()
        {
            return base.ToString() + " Euro ";
        }
    }
}
