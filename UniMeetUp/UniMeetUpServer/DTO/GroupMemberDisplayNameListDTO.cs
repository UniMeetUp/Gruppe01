using System.Collections.Generic;

namespace UniMeetUpServer.DTO
{
    public class GroupMemberDisplayNameListDTO
    {
        public int GroupId { get; set; }
        public List<UserDisplayNameDTO> UserDisplayNamesList { get; set; } = new List<UserDisplayNameDTO>();
    }
}
