using System.ComponentModel.DataAnnotations;

namespace CommonLib.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string HashedPassword { get; set; }
        [MaxLength(20)]
        public string DisplayName { get; set; }
    }
}
