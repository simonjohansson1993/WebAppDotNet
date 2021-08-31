using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace environment_crime.Models {
  public class LoginModel {
    [Required(ErrorMessage ="Fyll i användarnamn.")]
    [Display(Name = "Användarnamn: ")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Fyll i Lösenord.")]
    [Display(Name = "Lösenord: ")]
    [UIHint("password")]
    public string Password { get; set; }

    public string ReturnURL { get; set; }
  }
}
