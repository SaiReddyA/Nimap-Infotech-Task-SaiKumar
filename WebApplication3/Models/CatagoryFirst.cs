using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class CatagoryFirst
    {
        [Key]
        public int CId { get; set; }

        [Required(ErrorMessage =("CatagoryName Required"))]
        public string CatagoryName { get; set; }
    }
}