using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SameDayServicezFinal.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public string Type { get; set; }

        public string ReturnUrl { get; set; }
    }

    public class RegisterViewModel
    {
        //[Required]
        //[EmailAddress]
        //[Display(Name = "Email")]
        //public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Please Enter Your First Name",
    AllowEmptyStrings = false)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        //[Required(ErrorMessage = "Please Enter Your  Middle Name",
        //  AllowEmptyStrings = false)]
        //[Display(Name = "Middle Name")]
        //public string MiddleName { get; set; }



        [Required(ErrorMessage = "Please Enter Your Last Name",
        AllowEmptyStrings = false)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


      //  [Required(ErrorMessage = "Please Enter Your Street Address",
      // AllowEmptyStrings = false)]
      //  [Display(Name = "Address")]
      //  public string Address { get; set; }


      //  [Required(ErrorMessage = "Please Enter Your City",
      // AllowEmptyStrings = false)]
      //  [Display(Name = "City")]
      //  public string City { get; set; }

      //  [Required(ErrorMessage = "Please Enter Your State",
      //   AllowEmptyStrings = false)]
      //  [Display(Name = "State")]
      //  public string State { get; set; }
      //  public IEnumerable<SelectListItem> States { get; set; }


      //  [Required(ErrorMessage = "Please Enter Your Zip Code",
      // AllowEmptyStrings = false)]
      //  [StringLength(5, MinimumLength = 5)]
      //  [RegularExpression("(^\\d{5}(-\\d{4})?$)|(^[ABCEGHJKLMNPRSTVXY]{1}\\d{1}[A-Z]{1} *\\d{1}[A-Z]{1}\\d{1}$)", ErrorMessage = "Zip code is invalid.")] // US or Canada

      //  [Display(Name = "Zip Code")]
      //  public string ZipCode { get; set; }

      //  [Required(ErrorMessage = "Please Enter Your Phone Number",
      //AllowEmptyStrings = false)]
      //  [DataType(DataType.PhoneNumber)]
      //  [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone number")]
      //  [Display(Name = "Phone Number")]
      //  public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Please Enter Email Address")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
        ErrorMessage = "Please Enter Correct Email Address")]
        public string Email { get; set; }


        //  [Required(ErrorMessage = "Please Enter a Password",
        //AllowEmptyStrings = false)]
        //  [DataType(DataType.Password)]
        //  public string Password { get; set; }

        //[NotMapped]
        //[DataType(DataType.Password)]
        //[System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Confirm password doesn't match, Try Again!")]
        //public string ConfirmPassword { get; set; }


     //   [Required(ErrorMessage = "Choose date of birth")]
     //   [Display(Name = "Date of Birth")]
     //   public string BirthDate { get; set; }


     //   [Required(ErrorMessage = "Please Enter Your Bio",
     //AllowEmptyStrings = false)]
     //   [Display(Name = "Bio")]
     //   public string Bio { get; set; }


        public bool IsInContractorMode { get; set; }
        public bool IsInCustomerMode { get; set; }

        //public double latitude { get; set; }
        //public double longitude { get; set; }

        //[Display(Name = "Hourly Rate")]
        //public decimal ByTheHourRate { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
