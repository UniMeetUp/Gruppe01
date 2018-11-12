namespace CommonLib.Models
{
    public class FileMessage
    {
        public int Id { get; set; }
        public byte[] FileBinary { get; set; }
        public string FileHeaders { get; set; }
        public int GroupId { get; set; }
        public int SenderUserId { get; set; }
    }
}
