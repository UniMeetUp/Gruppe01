namespace UniMeetUpApplication.Model.Interfaces
{
    public interface IFileRepoModel
    {
        FileMessageForDownload DownloadFile(int fileId);
    }
}
