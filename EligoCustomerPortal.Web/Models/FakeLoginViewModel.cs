using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EligoCustomerPortal.Web.Models
{
    public class FakeLoginViewModel
    {
        [Required(ErrorMessage = "Please enter your customer ID")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid customer number")]
        [DisplayName("Customer Number")]
        public int CustomerID { get; set; }
    }
}
