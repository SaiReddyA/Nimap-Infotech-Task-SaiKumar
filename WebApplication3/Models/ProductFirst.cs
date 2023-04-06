using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class ProductFirst
    {
        [Key]
        public int PId { get; set; }
        [Required(ErrorMessage = ("ProductName Required"))]
        public  string ProductName { get; set; }
        [Required(ErrorMessage = ("CatagoryName Required"))]
        public Nullable<int> Catagory_CId { get; set; }


        public virtual CatagoryFirst Catagory { get; set; }
    }
}