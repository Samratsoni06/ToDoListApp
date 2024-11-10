using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ToDoListApp.Data
{
    public class NwAuthDbContext : IdentityDbContext
    {
        public NwAuthDbContext(DbContextOptions<NwAuthDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var readerRoleID = "40fcf4eb-fea4-4bb5-87f3-3ce31f640dfd";
            var WriterRoleID = "ef5271fe-b5fc-4154-b83c-291f721b78b8";

            var rols = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleID,
                    ConcurrencyStamp = readerRoleID,
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                },
                    new IdentityRole
                    {
                        Id = WriterRoleID,
                        ConcurrencyStamp = WriterRoleID,
                        Name = "Admin",
                        NormalizedName = "Admin".ToUpper()
                    }
            };

            builder.Entity<IdentityRole>().HasData(rols);
        }
    }
}
