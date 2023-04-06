using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class GetProduct
    {
        public int PId { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> Catagory_CId { get; set; }
        public string CatagoryName { get; set; }
    }
}