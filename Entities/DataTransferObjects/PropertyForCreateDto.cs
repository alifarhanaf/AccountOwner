using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class PropertyForCreateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string  Location  { get; set; }

        [Required(ErrorMessage = "Contact is required")]
        [StringLength(100, ErrorMessage = "Contact cannot be longer than 100 characters")]
        public string Contact { get; set; }
    }
}
