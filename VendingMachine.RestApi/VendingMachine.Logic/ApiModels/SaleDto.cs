namespace VendingMachine.Domain.ApiModels
{
    public class SaleDto
    {
        public DateTime? Date { get; set; }
        public string Name { get; set; }

        public float Price { get; set; }
        public string PaymentMethod { get; set; }
    }
}
