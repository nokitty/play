using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace play.Models
{
    public class SchoolContextInitialize : CreateDatabaseIfNotExists<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var user = new User { Name = "dsb" };
            context.Insert(user);

            var role = new Role { Name = "管理员", Description = "系统管理员" };
            context.Insert(role);

            context.Insert(new UserRole { RoleID = role.ID, UserID = user.ID });

            Permission p = null;
            List<Permission> c=null;

            p = new Permission { Code = "User", Description = "用户管理",ParentID=0};
            context.Insert(p);
            c = new List<Permission>();
            c.Add(new Permission { Code = "User.Create", Description = "创建用户", ParentID = p.ID });
            c.Add(new Permission { Code = "User.Edit", Description = "修改用户", ParentID = p.ID });
            c.Add(new Permission { Code = "User.Delete", Description = "删除用户", ParentID = p.ID });
            context.InsertRange(c);

            context.Permissions.ToList().ForEach(i => context.Insert(new RolePemission { PermissionID = i.ID, RoleID = role.ID,Value=1 }, false));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}