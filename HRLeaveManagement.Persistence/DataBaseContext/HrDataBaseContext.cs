using HRLeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Persistence.DataBaseContext
{
    public class HrDataBaseContext : DbContext
    {
        public HrDataBaseContext(DbContextOptions<HrDataBaseContext> options) : base(options)
        {
        }
        public DbSet<Domain.LeaveType> LeaveTypes { get; set; }
        public DbSet<Domain.LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<Domain.LeaveRequest> LeaveRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity mappings here
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrDataBaseContext).Assembly);
            modelBuilder.ApplyConfiguration(new Configurations.LeaveTypeConfiguration());

            base.OnModelCreating(modelBuilder);

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Add any custom logic before saving changes, if needed
            foreach (var entry in ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                // Set modified date or other properties for updated entities
                entry.Entity.DateModified = DateTime.UtcNow;
                if (entry.State == EntityState.Added)
                {
                    // Set created date or other properties for new entities
                    entry.Entity.DateCreated = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
