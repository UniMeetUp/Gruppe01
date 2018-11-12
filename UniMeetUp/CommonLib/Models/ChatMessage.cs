using System;
using System.ComponentModel.DataAnnotations;

namespace CommonLib.Models
{
    public class ChatMessage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public string UserId { get; set; }
        public int GroupId { get; set; }
        public User User { get; set; }
        public Group Group { get; set; }
    }
}
