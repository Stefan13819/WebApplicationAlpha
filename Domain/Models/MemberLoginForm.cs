using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;

public class MemberLoginForm
{
    [Required]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Enter Email")]
    [RegularExpression(@"^[\w.-]+@[\w.-]+\.\w{2,}$")]
    public string Email { get; set; } = null!;
    [Required]
    [Display(Name = "Password", Prompt = "Enter Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    [Display(Name = "Remember Me")]
    public bool RememberMe { get; set; }

}
