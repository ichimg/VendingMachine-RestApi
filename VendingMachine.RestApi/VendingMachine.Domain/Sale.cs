
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace VendingMachine.Domain
{
    public class Sale : EntityBase
    {
        public string Name { get; set; }

        public float Price { get; set; }
        public DateTime? Date { get; set; }
        public string PaymentMethod { get; set; }

        public Sale(string name, float price, DateTime date, string paymentMethod)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            Name = name;
            Price = price;
            Date = date;

            if (string.IsNullOrEmpty(paymentMethod))
                throw new ArgumentNullException(nameof(paymentMethod));

            PaymentMethod = paymentMethod;
        }

        public Sale() { }

  
    }
}
