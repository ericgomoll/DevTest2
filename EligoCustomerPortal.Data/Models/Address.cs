using EligoCustomerPortal.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EligoCustomerPortal.Data.Models
{
    /// <summary>
    /// Represents and Address entity.
    /// </summary>
    public class Address : IEligoEntity
    {
        /// <inheritdoc/>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Street address
        /// </summary>
        [Required(ErrorMessage = "Please provide a street address")]
        public string StreetAddress { get; set; }

        /// <summary>
        /// City of address.
        /// </summary>
        [Required(ErrorMessage = "Please provide a city")]
        public string City { get; set; }

        /// <summary>
        /// State/region of address.
        /// </summary>
        [Required(ErrorMessage = "Please provide a state")]
        public string State { get; set; }

        /// <summary>
        /// Postal code of address.
        /// </summary>
        [Required(ErrorMessage = "Please provide a postal code")]
        public string PostalCode { get; set; }
    }
}
