using System;

namespace Banque
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c1 = new Client("chaimae", "bougattaya", "casablanca");
            Client c2 = new Client("ghita", "alami", "rabat");

            Devise solde1 = new MAD(1000);
            Devise solde2 = new Euro(3500);
            Devise solde3 = new Dollar(1000);

            Compte compte1 = new CompteEpargne(c1, solde1);
            Compte compte2 = new ComptePayant(c2, solde2);
            Compte compte3 = new CompteEpargne(c2, solde3);


            c1.ajouterCompte(compte1);
            c2.ajouterCompte(compte2);
            c2.ajouterCompte(compte3);


            Devise solde4 = new Euro(3500);
            Devise solde5 = new MAD(1000);
            Devise solde6 = new Euro(3500);

            Devise dev1 = new MAD(455);
            Devise dev2 = new Euro(100);
            Devise dev3 = new Dollar(600);


            compte1.crediter(dev1); //compte 1 => MAD
            compte1.debiter(dev2);


            compte2.crediter(solde4); // compte 2 => Euro
            compte2.debiter(dev3);


            Console.WriteLine(c1);
            Console.WriteLine(c2);
            Console.ReadKey();
        }
    }
}
/*
 
if (c1.GetType().Name.CompareTo("Client") == 0)
                Console.WriteLine("yes");
            Console.WriteLine(c1.GetType().Name);
            Console.WriteLine(compte1.GetType().Name);
            Console.WriteLine(solde1.GetType().Name);
            Console.WriteLine(solde2.GetType().Name);
            //if( c1.GetType() == typeof(Compte))
 */