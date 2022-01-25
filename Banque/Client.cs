using System;
using System.Collections.Generic;

namespace Banque
{
    class Client
    {
        string nom;
        string prenom;
        string adresse;
        List<Compte> list;

        public Client(string n, string p, string a)
        {
            this.nom = n;
            this.prenom = p;
            this.adresse = a;
            this.list = new List<Compte>();
        }
        public void ajouterCompte(Compte com)
        {
            this.list.Add(com);
        }
        public override string ToString()
        {
            String res = "Nom = " + nom + "\nPrenom = " + prenom + "\nadresse = " + adresse;

            if (list.Count > 0)
                foreach (Compte c in this.list)
                {
                    res += c.ToString() + "\n";
                }
            return res;
        }

    }
}
