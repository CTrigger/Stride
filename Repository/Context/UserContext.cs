using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public class UserContext : DbContext
    {
        #region ctor
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        #endregion

        #region dbset
        public DbSet<User> Users { get; set; }
        #endregion

        #region Roles
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();
        }
        #endregion
    }
}
