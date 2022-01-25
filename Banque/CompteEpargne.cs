using System;
namespace Banque
{
    class CompteEpargne : Compte
    {
        static double TauxInteret = 2;
        public CompteEpargne(Client client, Devise solde)
            : base(client, solde)
        {
        }
        public void calculInteret()
        {
            this.calculInteretSolde(TauxInteret);
        }
        public override string ToString()
        {
            return "\nDetails compte Epargne : \n" + base.ToString();
        }
        override public bool debiter(Devise montant)
        {
            // si le montant qu'on veut débité est <= à la moitié du compte
            if (this.comparerMoitie(montant) == true)
            {
                Console.WriteLine("\non peut debiter le compte epargne \n");
                base.debiter(montant);
                return true;
            }
            Console.WriteLine("\non ne peut pas débiter le compte Epargne car le montant est > la moitié");

            return false;
        }
    }
}
