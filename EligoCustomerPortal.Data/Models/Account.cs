using EligoCustomerPortal.Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EligoCustomerPortal.Data.Models
{
    /// <summary>
    /// Represents an Account entity.
    /// </summary>
    public class Account : IEligoEntity
    {
        /// <inheritdoc/>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DisplayName("Account Number")]
        public int ID { get; set; }

        /// <summary>
        /// ID of customer account is tied to.
        /// </summary>
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        /// <summary>
        /// ID of address listed as billing address on the account.
        /// </summary>
        public int BillingAddressID { get; set; }

        /// <summary>
        /// ID of address listed as service address on the account.
        /// </summary>
        public int ServiceAddressID { get; set; }

        /// <summary>
        /// ID of account type.
        /// </summary>
        [ForeignKey("AccountType")]
        public int AccountTypeID { get; set; }

        #region Navigation Properties
        
        public Customer Customer { get; set; }

        public Address BillingAddress { get; set; }

        public Address ServiceAddress { get; set; }

        public AccountType AccountType { get; set; }

        public ICollection<Invoice> Invoices { get; set; }

        #endregion
    }
}
