using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UniMeetUpApplication.Model.Interfaces
{
    public interface IMainMenuModel
    {
        List<FileMessageForFileFolder> GetAllFilenameAndIdForGroup(int groupId);
        Task<HttpResponseMessage> CreateGroup(string groupName);
    }

}
