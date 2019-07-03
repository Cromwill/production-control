using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.Models.EF
{
    public class DataInitializer : DropCreateDatabaseAlways<ProductContolEntities>
    {
        protected override void Seed(ProductContolEntities context)
        {
            base.Seed(context);
        }
    }
}