namespace VendingMachine.Logic.Exceptions
{
    public class InvalidDateException : Exception
    {
        private const string DefaultMessage = "Invalid date: {0}";
        public InvalidDateException(DateTime? date)
        : base(String.Format(DefaultMessage, date))
        {
        }
    }
}
