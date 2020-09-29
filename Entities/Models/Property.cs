using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("property")]
    public class Property
    {
        [Column("PropertyId")]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(60, ErrorMessage = "Length Shoud not be more than 60 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Location is Required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Contact Information Required")]
        [StringLength(20, ErrorMessage = "It should be not more than 20 characters")]
        public string Contact { get; set; }



    }
}
