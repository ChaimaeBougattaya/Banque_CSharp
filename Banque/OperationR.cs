namespace Banque
{
    class OperationR : Operation
    {
        public OperationR(Compte compte, string date, Devise montant)
            : base(compte, date, montant)
        {
        }

        public override string ToString()
        {
            return "\nOperation de Retrait" + base.ToString();
        }

    }
}
