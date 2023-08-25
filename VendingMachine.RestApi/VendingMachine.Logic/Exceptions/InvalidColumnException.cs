namespace VendingMachine.Logic.Exceptions
{
    public class InvalidColumnException : Exception
    {
        private const string DefaultMessage = "Invalid id: {0}";
        public InvalidColumnException(int shelfNumber)
        : base(String.Format(DefaultMessage, shelfNumber))
        {
        }
        

    }
}
