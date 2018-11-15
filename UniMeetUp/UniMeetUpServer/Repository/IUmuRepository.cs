using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLib.Models;

namespace UniMeetUpServer.Repository
{
    public interface IUmuRepository
    {
        User GetUserById(string email);
        List<Group> GetGroupsForUser(string email);
    }
}
