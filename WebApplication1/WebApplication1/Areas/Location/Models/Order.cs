using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Order
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        [Required]
        public int CustId { get; set; }
        [Required]
        public int LocationId { get; set; }
        [ForeignKey("CustId")]
        public virtual Customer Customer { get; set; }
        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }
    }
}