using System.ComponentModel.DataAnnotations;

namespace VendingMachine.Domain
{
    public class Product: EntityBase, IEquatable<Product>
    {
        public string Name { get; set; }

        public float Price { get; set; }

        public int Quantity { get; set; }

        public Product(int id, string name, float price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public bool Equals(Product? other)
        {
            return Id == other.Id 
                && Name == other.Name 
                && Price == other.Price
                && Quantity == other.Quantity;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is Product))
                return false;

            Product otherProduct = (Product)obj;

            return Id == otherProduct.Id 
                && Name == otherProduct.Name 
                && Price == otherProduct.Price
                && Quantity == otherProduct.Quantity;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Price, Quantity);
        }
    }
}
