using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TodoApi.Models;

namespace Usermodels
{
    public class ApplicationUser : IdentityUser
    {

        // FirstName & LastName will be stored in a different table called MUserInfo
        public virtual UserInfo MyUserInfo { get; set; }
    }

    public class UserInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class ToDo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
    public class MyDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyDbContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Change the name of the table to be Users instead of AspNetUsers
            modelBuilder.Entity<IdentityUser>()
                .ToTable("Users");
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("Users");
        }

        public DbSet<ToDo> ToDoes { get; set; }

        public DbSet<UserInfo> MyUserInfo { get; set; }
        public virtual ICollection<Todoitem> Users { get; set; }
    }



}