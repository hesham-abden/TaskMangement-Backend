using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Identity;
using TaskMangement.Domain.Entities.Common;

namespace TaskManagement.Persistance.Context
{
    public class TaskAppDbContext : IdentityDbContext<User,Role,long>
    {

        public DbSet<TaskItem> TaskItem { get; set; }
        public TaskAppDbContext(DbContextOptions<TaskAppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(TaskAppDbContext).Assembly);
            base.OnModelCreating(builder);
            builder.Entity<User>(entity =>
            {
                entity.Ignore(e => e.UserName);
                entity.Ignore(e => e.Email);
                entity.Ignore(e => e.NormalizedUserName);
                entity.Ignore(e => e.NormalizedEmail);
                entity.Ignore(e => e.EmailConfirmed);
                entity.Ignore(e => e.PasswordHash);
                entity.Ignore(e => e.SecurityStamp);
                entity.Ignore(e => e.ConcurrencyStamp);
                entity.Ignore(e => e.PhoneNumber);
                entity.Ignore(e => e.PhoneNumberConfirmed);
                entity.Ignore(e => e.TwoFactorEnabled);
                entity.Ignore(e => e.LockoutEnabled);
                entity.Ignore(e => e.LockoutEnd);
                entity.Ignore(e => e.AccessFailedCount);
            });
            builder.Entity<User>().HasData(
                                        new User
                                        {
                                            Id = 1,
                                            FirstName = "System",
                                            LastName = "Admin"
                                        },
                                        new User
                                        {
                                            Id = 2,
                                            FirstName = "Hesham",
                                            LastName = "Abden"
                                        },
                                        new User
                                        {
                                            Id = 3,
                                            FirstName = "Mohamed",
                                            LastName = "Nady"
                                        }
                                        );
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is IAuditableEntity auditableEntity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        auditableEntity.CreatedBy =1; // current user id
                        auditableEntity.CreatedDate = DateTime.UtcNow;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        auditableEntity.LastModifiedBy= 1;
                        auditableEntity.LastModifiedDate = DateTime.UtcNow;
                    }
                }
                if (entry.Entity is IBaseEntityDel softDeletable && entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    softDeletable.IsDeleted = true;
                    softDeletable.DeletedBy = 1;
                    softDeletable.DeletedDate = DateTime.UtcNow;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}