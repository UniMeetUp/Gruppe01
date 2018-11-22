using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLib.Models;
using Microsoft.EntityFrameworkCore;
using UniMeetUpServer.Models;

namespace UniMeetUpServer.Repository
{
    public class UmuRepository : IUmuRepository
    {
        private readonly UniMeetUpServerContext _context;
        public UmuRepository(UniMeetUpServerContext context)
        {
            _context = context;
        }

        public User GetUserById(string email)
        {

            return _context.User.Where(u => u.EmailAddress == email).FirstOrDefault();
           
        }

        public List<Group> GetGroupsForUser(string email)
        {
            var usergroups =_context.UserGroup.Where(u => u.EmailAddress == email)
                .Include(c => c.Group).ToList();

            List<Group> groups = new List<Group>();

            foreach (var group in usergroups)
            {
                groups.Add(group.Group);
            }

            return groups;
        }

        public List<Location> getLocationsForGroup(int id)
        {
            var locations = _context.Location
                .Where(i => i.GroupId == id).ToList();

            return locations;
        }
    }
}
