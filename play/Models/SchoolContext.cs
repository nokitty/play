using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace play.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePemission> RolePermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public StoredProcedure StoredProcedure { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public SchoolContext()
            : base("name=db")
        {            
            StoredProcedure = new StoredProcedure(this);
        }

        public void Insert<T>(T entity, bool save = true) where T : class
        {
            Set<T>().Add(entity);
            if (save)
            {
                SaveChanges();
            }
        }

        public void InsertRange<T>(IEnumerable<T> entities, bool save = true) where T : class
        {
            Set<T>().AddRange(entities);
            if (save)
            {
                SaveChanges();
            }
        }

        public void InsertUser(User user)
        {
            Insert(user);
        }
    }
}