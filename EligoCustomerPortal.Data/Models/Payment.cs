using EligoCustomerPortal.Data.Models.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EligoCustomerPortal.Data.Models
{
    /// <summary>
    /// Represents a Payment entity.
    /// </summary>
    public class Payment : IEligoEntity
    {
        ///<inheritdoc />
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DisplayName("Payment Number")]
        public int ID { get; set; }

        /// <summary>
        /// ID of invoice payment is applied to.
        /// </summary>
        [ForeignKey("Invoice")]
        [DisplayName("Invoice Number")]
        public int InvoiceID { get; set; }

        /// <summary>
        /// ID of payment method.
        /// </summary>
        [ForeignKey("Payment")]
        public int PaymentMethodID { get; set; }

        /// <summary>
        /// Date of payment.
        /// </summary>
        [Required(ErrorMessage = "Please enter a date for the payment")]
        [DataType(DataType.Date, ErrorMessage = "Please provide a valid date")]
        [DisplayName("Payment Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PaymentDate { get; set; }

        /// <summary>
        /// Amount of payment.
        /// </summary>
        [Required(ErrorMessage = "Please enter an amount")]
        [DataType(DataType.Currency, ErrorMessage = "Please enter a valid amount")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Amount { get; set; }

        #region Navigation Properties

        public Invoice Invoice { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        #endregion
    }
}
