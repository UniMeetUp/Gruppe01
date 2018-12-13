using System.Collections.Generic;
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
        List<GroupMemberDisplayNameListDTO> GetAllMembersDisplayNameOfAllGruops(string email);
        FileMessageForDownloadDTO GetFileToDownloadById(int fileId);
        void UpdateWayPointForGroup(Waypoint waypoint);
        Waypoint GetWaypointById(int groupId);
        void PostUserWithEmailNameAndPassword(UserToPostDTO user);
        List<MessageForLoadDTO> GetMessagesByGroupId(int groupId);
        void AddUserGroup(UserGroup userGroup);
    }
}
