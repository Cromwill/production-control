using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UserToUsers
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UsersId { get; set; }
    }
}