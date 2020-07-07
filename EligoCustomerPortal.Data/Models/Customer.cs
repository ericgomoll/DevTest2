using EligoCustomerPortal.Data.Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EligoCustomerPortal.Data.Models
{
    /// <summary>
    /// Represents a Customer entity.
    /// </summary>
    public class Customer : IEligoEntity
    {
        /// <inheritdoc/>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DisplayName("Customer Number")]
        public int ID { get; set; }

        /// <summary>
        /// First name of customer.
        /// </summary>
        [Required(ErrorMessage = "Please provide a first name")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of customer.
        /// </summary>
        [Required(ErrorMessage = "Please provide a last name")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Email address of customer.
        /// </summary>
        [Required(ErrorMessage = "Please provide an email address")]
        [EmailAddress(ErrorMessage = "Please provide a valid email address")]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Phone number of customer.
        /// </summary>
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        #region Navigation Properties

        public ICollection<Account> Accounts { get; set; }

        #endregion
    }
}
