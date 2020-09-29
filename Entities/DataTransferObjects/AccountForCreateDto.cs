using System;
using System.ComponentModel.DataAnnotations;

namespace AccountOwnerWebAPI.Controllers
{
    public class AccountForCreateDto
    {
        [Required(ErrorMessage = "DateCreated is required")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Account type is required")]
        public string AccounType { get; set; }
    }
}