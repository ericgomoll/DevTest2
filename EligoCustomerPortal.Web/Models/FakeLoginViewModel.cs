using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EligoCustomerPortal.Web.Models
{
    /// <summary>
    /// "Fake login capabilities for the demo app.
    /// </summary>
    /// <remarks>This posts back to an action in the home controller that just redirects to the customer controller.</remarks>
    public class FakeLoginViewModel
    {
        /// <summary>
        /// ID of the customer to log in.
        /// </summary>
        [Required(ErrorMessage = "Please enter your customer ID")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid customer number")]
        [DisplayName("Customer Number")]
        public int CustomerID { get; set; }
    }
}
