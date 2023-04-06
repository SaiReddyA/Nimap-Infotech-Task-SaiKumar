using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class NimapInfotechSaikumar:DbContext
    {
        public NimapInfotechSaikumar():base("NimapInfotech")
        {

        }



        public  DbSet<ProductFirst> products{ get; set; }
        public  DbSet<CatagoryFirst> Catagories { get; set; }

    }
}