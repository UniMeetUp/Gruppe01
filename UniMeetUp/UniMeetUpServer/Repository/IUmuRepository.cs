using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLib.Models;
using UniMeetUpServer.DTO;

namespace UniMeetUpServer.Repository
{
    public interface IUmuRepository
    {
        User GetUserById(string email);
        List<Group> GetGroupsForUser(string email);
        List<Location> getLocationsForGroup(int id);
        List<FileMessageForFileFolderDTO> GetGroupFileMessagesNameAndId(int groupId);
        void UpdateLocation(Location location);
        FileMessageForDownloadDTO GetFileToDownloadById(int fileId);
        void UpdateWayPointForGroup(Waypoint waypoint);

        Waypoint GetWaypointById(int groupId);
    }
}
