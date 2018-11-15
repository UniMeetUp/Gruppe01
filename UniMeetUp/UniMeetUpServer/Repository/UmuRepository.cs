using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLib.Models;
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
    }
}
