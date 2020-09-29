using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class AccountForUpdateDto
    {
        [Required(ErrorMessage = "DateCreated is required")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "AccounType is required")]
        public string AccounType { get; set; }
    }

}
