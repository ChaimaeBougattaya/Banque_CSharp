namespace Banque
{
    abstract class Operation
    {
        static int compteur;
        int Numop;
        string date;
        Devise Montant;
        Compte CompteOp;
        public Operation(Compte compte, string date, Devise montant)
        {
            compteur++;
            Numop = compteur;
            this.CompteOp = compte;
            this.date = date;
            this.Montant = montant;
        }
        public override string ToString()
        {
            return "\nDetails : " + date + " || N° : " + Numop + " || " + Montant;
        }

    }
}
