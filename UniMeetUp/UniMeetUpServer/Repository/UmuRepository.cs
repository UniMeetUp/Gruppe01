using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CommonLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniMeetUpServer.DTO;
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

        public List<FileMessageForFileFolderDTO> GetGroupFileMessagesNameAndId(int groupId)
        {
            List<string> _FileHeaderlist = _context.FileMessage.Where(f => f.GroupId == groupId)
                .Select(f => f.FileHeaders).ToList();
            
            List<int> _FileIdList = _context.FileMessage.Where(f => f.GroupId == groupId)
                .Select(f => f.FileMessageId).ToList();

            List<FileMessageForFileFolderDTO> _listToReturn = new List<FileMessageForFileFolderDTO>();

            for (int i = 0; i < _FileHeaderlist.Count; i++)
            {
                _listToReturn.Add(new FileMessageForFileFolderDTO(_FileIdList[i], _FileHeaderlist[i]));
            }

            return _listToReturn;
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
                item.TimeStamp = location.TimeStamp;

            }
        }


        public void UpdateWayPointForGroup(Waypoint locationWaypoint)
        {
            var checkIfLocationExist = _context.Waypoint
                .Where(i=> i.GroupId == locationWaypoint.GroupId).FirstOrDefault();

            if (checkIfLocationExist == null)
            {
                _context.Waypoint.Add(locationWaypoint);
            }
            else
            {
                checkIfLocationExist.Latitude = locationWaypoint.Latitude;
                checkIfLocationExist.Longitude = locationWaypoint.Longitude;
                checkIfLocationExist.TimeStamp = locationWaypoint.TimeStamp;
                checkIfLocationExist.Description = locationWaypoint.Description;
                checkIfLocationExist.UserId = locationWaypoint.UserId;
            }



        }

        public Waypoint GetWaypointById(int groupId)
        {
            Waypoint waypoint = _context.Waypoint.Where(i => i.GroupId == groupId).FirstOrDefault();

            if (waypoint == null)
            {
                return null;
            }
            else
            {
                return waypoint;
            }
        }

        public FileMessageForDownloadDTO GetFileToDownloadById(int fileId)
        {
            string fileName = _context.FileMessage.Where(f => f.FileMessageId == fileId).Select(n => n.FileHeaders).FirstOrDefault();

            byte[] fileAr = _context.FileMessage.Where(f => f.FileMessageId == fileId).Select(n => n.FileBinary).FirstOrDefault();
            return new FileMessageForDownloadDTO(fileAr, fileName);
        }


        public void PostUserWithEmailNameAndPassword(UserToPostDTO user)
        {
            var result = Mapper.Map<User>(user);

            _context.User.Add(result);
            
        }


    }
}
