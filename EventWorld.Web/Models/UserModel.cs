using System;
using System.ComponentModel.DataAnnotations;

namespace EventWorld.Web.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [RegularExpression("^((?!^First Name$)[a-zA-Z '])+$", ErrorMessage = "First name is required and must be properly formatted.")]
        public string FirstName { get; set; }
        [RegularExpression("^((?!^Last Name$)[a-zA-Z '])+$", ErrorMessage = "Last name is required and must be properly formatted.")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
