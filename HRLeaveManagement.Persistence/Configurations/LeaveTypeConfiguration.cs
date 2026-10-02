using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Persistence.Configurations
{
    internal class LeaveTypeConfiguration : IEntityTypeConfiguration<HRLeaveManagement.Domain.LeaveType>
    {
        public void Configure(EntityTypeBuilder<HRLeaveManagement.Domain.LeaveType> builder)
        {
            builder.HasData(
                new HRLeaveManagement.Domain.LeaveType { Id = 1, Name = "Vacation", DefaultDays = 10, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new HRLeaveManagement.Domain.LeaveType { Id = 2, Name = "Sick", DefaultDays = 12, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new HRLeaveManagement.Domain.LeaveType { Id = 3, Name = "Maternity", DefaultDays = 90, DateCreated = DateTime.Now, DateModified = DateTime.Now }
            );
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.DefaultDays).IsRequired();
            builder.Property(e => e.DateCreated).IsRequired();
            builder.Property(e => e.DateModified).IsRequired();
        }
    }
}
