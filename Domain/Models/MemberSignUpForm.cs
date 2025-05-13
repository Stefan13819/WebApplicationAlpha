using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;

public class MemberSignUpForm
{
 
    
        [Required]
        [Display(Name = "First Name", Prompt = "Enter First Name")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; } = null!;
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name", Prompt = "Enter Last Name")]
       
        public string LastName { get; set; } = null!;
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email", Prompt = "Enter Email")]
        public string Email { get; set; } = null!;
        [Required]
        [Display(Name = "Password", Prompt = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Confirm Password")]
        public string ConfirmPassword { get; set; } = null!;


         [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone", Prompt = "Phone")]
    public string? PhoneNumber { get; set; } 




}
