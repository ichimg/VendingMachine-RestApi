using System.ComponentModel.DataAnnotations;

namespace VendingMachine.Domain.ApiModels.Requests
{
    /// <summary>
    /// Represents a request to create or update a product in the database.
    /// </summary>
    public class CreateOrUpdateProductRequest
    {
        /// <summary>
        /// Represents the shelf number of the product. Required.
        /// </summary>
        [Required(ErrorMessage = "Shelf number is required.")]
        public int Id { get; set; }

        /// <summary>
        /// Represents the name of the product. Required.
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(30, ErrorMessage = "Name must not exceed 30 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// Represents the price of the product. Required.
        /// </summary>
        [Required(ErrorMessage = "Price is required.")]
        public float Price { get; set; }

        /// <summary>
        /// Represents the quantity of the product. Required.
        /// </summary>
        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }


    }
}
