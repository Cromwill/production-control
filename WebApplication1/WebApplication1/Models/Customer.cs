using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Customer
    {
        [Key]
        public int CustId { get; set; }
        [StringLength(60)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Address { get; set; }

        public virtual ICollection<Location> Locations { get; set; } = new HashSet<Location>();
    }
}