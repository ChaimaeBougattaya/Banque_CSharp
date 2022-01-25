using System;
using System.Collections.Generic;

namespace Banque
{
    abstract class Compte
    {

        Client propretaire;
        int numCompte;
        static int compteur;
        Devise solde;
        static Devise plafond = new MAD(200);
        private List<Operation> listOp;

        public Compte(Client client, Devise solde)
        {
            compteur++;
            this.numCompte = compteur;
            this.propretaire = client;
            this.solde = solde;
            this.listOp = new List<Operation>();
        }
        public void addOperation(Operation op)
        {
            this.listOp.Add(op);
        }
        public override string ToString()
        {
            String res = "\nNumCompte = " + numCompte + "   ||   Solde : " + solde.ToString();
            if (listOp.Count > 0)
                foreach (Operation op in this.listOp)
                {
                    res += op.ToString();
                }
            return res;
        }

        public void calculInteretSolde(double val)
        {
            double val1;
            val1 = this.solde.calculVal(1 - (val / 100));
            this.solde.modifierSolde(val1);
        }
        public bool comparerSolde(Devise d, Devise dec)
        {
            // si le solde du compte est >= ( decouvert + le montant à débiter)
            return this.solde.check_solde_dec(d, dec);
        }

        public bool comparerMoitie(Devise d)
        {
            if (this.solde.GetType() == typeof(MAD))
            {
                if (this.solde.checkmoit(d.convertToMAD()) == true)
                    return true;
            }
            else if (this.solde.GetType() == typeof(Euro))
            {
                if (this.solde.checkmoit(d.convertToEuro()) == true)
                    return true;
            }
            else if (this.solde.GetType() == typeof(Dollar))
            {
                if (this.solde.checkmoit(d.convertToDollar()) == true)
                    return true;
            }
            return false;
        }

        public void Mise_A_jour_payant(double taux)
        {
            this.solde.modifierSolde(this.solde.calculVal(1 - taux));
        }

        public virtual void crediter(Devise montant)
        {
            if (this.solde.GetType() == typeof(MAD))
                this.solde = this.solde + montant.convertToMAD();
            else
                if (this.solde.GetType() == typeof(Euro))
                this.solde = this.solde + montant.convertToEuro();
            else
                    if (this.solde.GetType() == typeof(Dollar))
                this.solde = this.solde + montant.convertToDollar();

            Operation op = new OperationV(this, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), montant);
            this.addOperation(op);
        }
        public virtual bool debiter(Devise M)
        {

            if (M.convertToMAD() <= plafond)
            {
                if (this.solde.GetType() == typeof(MAD))
                {
                    if (this.solde >= M.convertToMAD())
                    {
                        this.solde = this.solde - M.convertToMAD();
                        Operation op = new OperationR(this, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), M);
                        this.addOperation(op);
                        return true;
                    }
                }
                if (this.solde.GetType() == typeof(Euro))
                {
                    if (this.solde >= M.convertToEuro())
                    {
                        this.solde = this.solde - M.convertToEuro();
                        Operation op = new OperationR(this, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), M);
                        this.addOperation(op);
                        return true;
                    }
                }
                if (this.solde.GetType() == typeof(Dollar))
                {
                    if (this.solde >= M.convertToDollar())
                    {
                        this.solde = this.solde - M.convertToDollar();
                        Operation op = new OperationR(this, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), M);
                        this.addOperation(op);
                        return true;
                    }
                }
            }
            Console.WriteLine("\non ne peut pas débiter le compte car le montant est > plafond" + plafond.ToString());
            return false;
        }

        public bool verser(Compte compte, Devise montant)
        {
            if (this.debiter(montant) == true)
            {
                compte.crediter(montant);
                return true;
            }
            return false;
        }

    }
}
