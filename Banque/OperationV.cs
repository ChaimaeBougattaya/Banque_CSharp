namespace Banque
{
    class OperationV : Operation
    {
        public OperationV(Compte compte, string date, Devise montant)
            : base(compte, date, montant)
        {
        }
        public override string ToString()
        {
            return "\nOperation de Versemment" + base.ToString();
        }
    }
}
