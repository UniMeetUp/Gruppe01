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
                .Where(i => i.GroupId == id).Include(a => a.User).ToList();

            return locations;
        }

        public void UpdateLocation(Location location)
        {
            
            var checkIfLocationExist = _context.Location
                .Where(i => i.UserId == location.UserId && i.GroupId == location.GroupId).FirstOrDefault();

            if (checkIfLocationExist == null)
            {
                _context.Location.Add(location);
            }

            var locations = _context.Location
                .Where(i => i.UserId == location.UserId).ToList();

            foreach (var item in locations)
            {
                item.Latitude = location.Latitude;
                item.Longitude = location.Longitude;
            }


        }
    }
}
