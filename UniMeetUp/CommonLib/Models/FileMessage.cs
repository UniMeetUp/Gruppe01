using System.ComponentModel.DataAnnotations;

namespace CommonLib.Models
{
    public class FileMessage
    {
        [Key]
        public int FileMessageId { get; set; }
        [Required]
        public byte[] FileBinary { get; set; }
        public string FileHeaders { get; set; }

        public string UserId { get; set; }
        public int GroupId { get; set; }
        public User User { get; set; }
        public Group Group { get; set; }
    }
}
