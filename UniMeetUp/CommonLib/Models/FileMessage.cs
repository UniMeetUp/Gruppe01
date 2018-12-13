using System.ComponentModel.DataAnnotations;

namespace CommonLib.Models
{
    public class FileMessage 
    {
        /* FOR TESTING PURPOSES, REASONED NO ACTUAL FILES ARE IN DB */
        public FileMessage()
        {
            
        }
        public FileMessage(string fileHeaders, string userId, int groupId)
        {
            FileHeaders = fileHeaders;
            UserId = userId;
            GroupId = groupId;
        }
        /* TESTING STOPS HERE */

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
