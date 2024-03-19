using System.ComponentModel.DataAnnotations;

namespace MyCompanyAPI.DTOs
{
    public class CustomerDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Age { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "Phone Number must have a maximum length of 11")]
        [RegularExpression("^(080|081|070|091|090)[0-9]*$", ErrorMessage = "Phone Number must follow righr format and must be 11 dights.")]
        [Required]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$", ErrorMessage = "Invalid email format. Please enter a valid Gmail address.")]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }

    }

}
