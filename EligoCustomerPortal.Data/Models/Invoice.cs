using EligoCustomerPortal.Data.Models.Interfaces;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EligoCustomerPortal.Data.Models
{
    /// <summary>
    /// Repressents an Invoice entity.
    /// </summary>
    public class Invoice : IEligoEntity
    {
        /// <inheritdoc/>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DisplayName("Invoice Number")]
        public int ID { get; set; }

        /// <summary>
        /// ID of account the invoice is tied to.
        /// </summary>
        [ForeignKey("Account")]
        [DisplayName("Account Number")]
        public int AccountID { get; set; }

        /// <summary>
        /// Date of invoice.
        /// </summary>
        [Required(ErrorMessage = "Please provide a date for the invoice")]
        [DataType(DataType.Date, ErrorMessage = "Please provide a valid date")]
        [DisplayName("Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// Invoice amount.
        /// </summary>
        [Required(ErrorMessage = "Please enter an amount")]
        [DataType(DataType.Currency, ErrorMessage = "Please enter a valid amount")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Amount { get; set; }

        /// <summary>
        /// True if the invoice has been completely paid. 
        /// This is determined by if the amount of payment(s) towards the invoices equal the total amount of the invoice.
        /// </summary>
        [Required]
        [DisplayName("Invoice Paid")]
        public bool IsPaid { get; set; }

        #region Navigation Properties

        public Account Account { get; set; }

        public ICollection<Payment> Payments { get; set; }

        #endregion
    }
}
