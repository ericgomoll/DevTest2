using EligoCustomerPortal.Data.Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EligoCustomerPortal.Data.Models
{
    /// <summary>
    /// Represents a PaymentMethod entity.
    /// </summary>
    public class PaymentMethod : IEligoEntity
    {
        ///<inheritdoc/>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Name of payment method.
        /// </summary>
        [Required(ErrorMessage = "Please provide a name for the payment method.")]
        public string Name { get; set; }

        #region Navigation Properties

        public ICollection<Payment> Payments { get; set; }

        #endregion
    }
}
