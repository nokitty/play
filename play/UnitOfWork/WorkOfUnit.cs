using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using play.Models;

namespace play.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        SchoolContext _context = new SchoolContext();

        ManageBase<User> _users = null;
        public ManageBase<User> Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserManager(_context);
                }
                return _users;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}