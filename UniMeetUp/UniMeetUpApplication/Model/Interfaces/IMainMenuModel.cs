using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace UniMeetUpApplication.Model.Interfaces
{
    public interface IMainMenuModel
    {
        List<FileMessageForFileFolder> GetAllFilenameAndIdForGroup(int groupId);
        Task<HttpResponseMessage> CreateGroup(string groupName);
    }
}
