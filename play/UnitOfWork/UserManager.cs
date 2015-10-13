using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace play.UnitOfWork
{
    public class UserManager:ManageBase<Models.User>
    {
        public UserManager(Models.SchoolContext context) : base(context) { }

        public override Models.User Insert(Models.User entity, bool save = true)
        {
            throw new NotImplementedException();
        }

        public override Models.User Update(Models.User entity, bool save = true)
        {
            throw new NotImplementedException();
        }

        public override Models.User Delete(Models.User entity, bool save = true)
        {
            throw new NotImplementedException();
        }
    }
}