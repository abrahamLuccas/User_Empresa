using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace User_Empresa.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    
    [Required]
    [EmailAddress(ErrorMessage = "Email Inválido!")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Insira seu RA!")]
    public int RA { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public int Telefone { get; set; }

}

