namespace CampusSystem.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class StudentRegisterViewModel : IMapTo<User>
    {
        private const string ErrorMessage = "The {0} must be at least {2} characters long.";

        [Required]
        [StringLength(30, ErrorMessage = ErrorMessage, MinimumLength = 2)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle name")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "University name")]
        public string University { get; set; }

        [Required]
        public string FacultyName { get; set; }

        [Required]
        public string FacultyNumber { get; set; }

        [Required]
        [Range(1, 5)]
        public int Course { get; set; }

        [Required]
        [Range(1, 100)]
        public int GroupNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}