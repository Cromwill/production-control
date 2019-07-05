using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Location.Models
{
    [Table("Location")]
    public partial class Location
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Location()
        {
            UsersId = new HashSet<string>();
        }

        [Key]
        public int LocationId { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(100)]
        public string SecondTitle { get; set; }
        [StringLength(60)]
        public string Customer { get; set; }
        //[StringLength(60)]
        //public string CreatorId { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<string> UsersId { get; set; } = new HashSet<string>();
        [NotMapped]
        public string TitleName => $"{Title} + {SecondTitle}";
    }

    public class CreateLocationViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
        [Display(Name = "Титул объекта")]
        public string Title { get; set; }

        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
        [Display(Name = "Наименование строительства")]
        public string SecondTitle { get; set; }

        [Required]
        [Display(Name = "Заказчик")]
        public string Customer { get; set; }
    }

    public partial class Location
    {
        public override string ToString()
        {
            return $"{ this.Title} is a {this.SecondTitle} {this.Customer} with ID {this.LocationId}.";
        }
    }



}