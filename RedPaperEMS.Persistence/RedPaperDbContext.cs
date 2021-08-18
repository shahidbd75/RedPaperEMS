using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedPaperEMS.Domain.Common;
using RedPaperEMS.Domain.Entities;

namespace RedPaperEMS.Persistence
{
    public class RedPaperDbContext: DbContext
    {
        public RedPaperDbContext(DbContextOptions<RedPaperDbContext> options):base(options)
        {
            
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RedPaperDbContext).Assembly);

            var GayeHoludId = Guid.Parse("213F105A-85A0-44FE-3DF2-08D89370E34D");
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = GayeHoludId,
                Name = "Gaye Holud"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = Guid.Parse("A3EBEA08-0A45-427D-3DF3-08D89370E34D"),
                Name = "Musalmani"
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                Name = "Sobujer Gaye Holud",
                EventId = Guid.NewGuid(),
                Artist = "Shahid",
                CategoryId = GayeHoludId,
                Date = DateTime.Now.AddDays(25),
                Description = "Baya bazar, rajshahi",
                Price = 6000,
                ImageUrl = "https://picsum.photos/200/300/?blur"
            });
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
