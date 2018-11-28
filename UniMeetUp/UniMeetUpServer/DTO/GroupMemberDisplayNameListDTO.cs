using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniMeetUpServer.DTO
{
    public class GroupMemberDisplayNameListDTO
    {
        public int GroupId { get; set; }

        public List<UserDisplayNameDTO> UserDisplayNamesList { get; set; } = new List<UserDisplayNameDTO>();
    }
}
