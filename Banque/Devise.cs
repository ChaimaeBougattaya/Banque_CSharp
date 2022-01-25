using System;

namespace Banque
{
    abstract class Devise
    {

        double valeur;
        public Devise(double val)
        {
            this.valeur = val;
        }
        public Devise(Devise dev)
        {
            this.valeur = dev.valeur;
        }
        public virtual void print()
        {
            Console.WriteLine("\nle solde est " + this.valeur);
        }
        public double calculVal(double taux)
        {
            return this.valeur * taux;
        }
        public void modifierSolde(double val)
        {
            this.valeur = val;
        }


        public override string ToString()
        {
            return "Valeur : " + valeur;
        }
        public abstract MAD convertToMAD();
        public abstract Euro convertToEuro();

        public abstract Dollar convertToDollar();


        public bool checkmoit(Devise dev)
        {
            if (this.valeur / 2 >= dev.valeur)
                return true;
            return false;
        }
        public bool check_solde_dec(Devise dev1, Devise dev2)
        {
            if (this.convertToMAD().valeur >= (dev1.valeur + dev2.valeur))
                return true;
            return false;
        }


        public static Devise operator +(Devise th, Devise dev)
        {
            th.valeur += dev.valeur;
            return th;
        }
        public static Devise operator -(Devise th, Devise dev)
        {
            th.valeur -= dev.valeur;
            return th;
        }

        public static bool operator <=(Devise th, Devise dev)
        {
            return (th.valeur <= dev.valeur);
        }
        public static bool operator >=(Devise th, Devise dev)
        {
            return th.valeur >= dev.valeur;
        }
    }
}
