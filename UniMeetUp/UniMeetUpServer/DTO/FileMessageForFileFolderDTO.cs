namespace UniMeetUpServer.DTO
{
    public class FileMessageForFileFolderDTO
    {
        public FileMessageForFileFolderDTO(int fileMessageId, string fileHeaders)
        {
            FileMessageId = fileMessageId;
            FileHeaders = fileHeaders;
        }
        public int FileMessageId { get; set; }
        public string FileHeaders { get; set; }
    }
}
