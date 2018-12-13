using Newtonsoft.Json;
using UniMeetUpApplication.Model.Interfaces;
using UniMeetUpApplication.ServerAccessLayer.Interfaces;

namespace UniMeetUpApplication.Model
{
    public class FileRepoModel : IFileRepoModel
    {
        private IServerAccessLayer _serverAccessLayer;
        public FileRepoModel(IServerAccessLayer serverAccessLayer)
        {
            _serverAccessLayer = serverAccessLayer;
        }

        public FileMessageForDownload DownloadFile(int fileId)
        {
            var jsonData = _serverAccessLayer.Get_File_To_Download_By_Id(fileId);
            return JsonConvert.DeserializeObject<FileMessageForDownload>(jsonData);
        }
    }
}
