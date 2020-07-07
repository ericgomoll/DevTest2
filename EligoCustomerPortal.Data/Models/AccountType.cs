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
    /// Represents an AccountType entity.
    /// </summary>
    public class AccountType : IEligoEntity
    {
        /// <inheritdoc/>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Name of payment type.
        /// </summary>
        [Required(ErrorMessage = "Please provide a name for the account type")]
        [DisplayName("Account Type")]
        public string Name { get; set; }

        #region Navigation Properties

        public ICollection<Account> Accounts { get; set; }

        #endregion
    }
}
