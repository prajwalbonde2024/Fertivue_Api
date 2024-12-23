using FertiVueWebapi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FertiVueWebapi.Data
{
    public class UserDbcontext: DbContext
    {
        public UserDbcontext(DbContextOptions<UserDbcontext> options) : base(options)
        { 
        
        }

        public DbSet<UserDetails> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Explicitly define primary key if needed
            modelBuilder.Entity<UserDetails>()
                .HasKey(u => u.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
