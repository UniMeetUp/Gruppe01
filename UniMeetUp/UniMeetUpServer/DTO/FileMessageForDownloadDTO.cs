namespace UniMeetUpServer.DTO
{
    public class FileMessageForDownloadDTO
    {
        public FileMessageForDownloadDTO(byte[] fileBinary, string fileHeaders)
        {
            FileBinary = fileBinary;
            FileHeaders = fileHeaders;
        }
        public byte[] FileBinary { get; set; }
        public string FileHeaders { get; set; }
    }
}
