using Microsoft.EntityFrameworkCore;
using HobJeei.Models;

namespace HobJeei.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<HobbyGroup> HobbyGroups { get; set; }
        public DbSet<GroupMembership> GroupMemberships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User inheritance
            modelBuilder.Entity<Company>().ToTable("Companies");
            modelBuilder.Entity<Customer>().ToTable("Customers");

            // Configure relationships
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Groups)
                .WithOne()
                .HasForeignKey(hg => hg.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GroupMembership>()
                .HasOne(gm => gm.Customer)
                .WithMany(c => c.Memberships)
                .HasForeignKey(gm => gm.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GroupMembership>()
                .HasOne(gm => gm.HobbyGroup)
                .WithMany()
                .HasForeignKey(gm => gm.HobbyGroupId)
                .OnDelete(DeleteBehavior.Restrict);

            // Add index on email for faster lookups
            modelBuilder.Entity<Company>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();

            // Configure HobbyGroup owned entities
            modelBuilder.Entity<HobbyGroup>()
                .OwnsMany(hg => hg.UpcomingSessions, session =>
                {
                    session.ToTable("Sessions");
                    session.WithOwner().HasForeignKey("HobbyGroupId");
                    session.HasKey("HobbyGroupId", "Id");
                    session.Property(s => s.Id).ValueGeneratedNever(); // SQLite doesn't support generated values on composite keys
                    session.Ignore(s => s.Attendance); // Dictionary cannot be mapped to database
                });

            modelBuilder.Entity<HobbyGroup>()
                .OwnsMany(hg => hg.Members, member =>
                {
                    member.ToTable("Members");
                    member.WithOwner().HasForeignKey("HobbyGroupId");
                    member.HasKey("HobbyGroupId", "Id");
                    member.Property(m => m.Id).ValueGeneratedNever(); // SQLite doesn't support generated values on composite keys
                });

            modelBuilder.Entity<HobbyGroup>()
                .OwnsMany(hg => hg.Messages, message =>
                {
                    message.ToTable("ChatMessages");
                    message.WithOwner().HasForeignKey("HobbyGroupId");
                    message.HasKey("HobbyGroupId", "Id");
                    message.Property(m => m.Id).ValueGeneratedNever(); // SQLite doesn't support generated values on composite keys
                });

            // Configure decimal precision for Price
            modelBuilder.Entity<HobbyGroup>()
                .Property(hg => hg.Price)
                .HasPrecision(18, 2);
        }
    }
}

