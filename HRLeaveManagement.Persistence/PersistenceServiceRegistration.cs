using HRLeaveManage.Application.Contract.Persistence;
using HRLeaveManagement.Persistence.DataBaseContext;
using HRLeaveManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRLeaveManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration confiuration)
        {
            // Register your persistence services here
            services.AddDbContext<HrDataBaseContext>(options =>
                options.UseSqlServer(confiuration.GetConnectionString("HrDataBaseConnectionString"))); // Replace with your actual connection string
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            return services;
        }
    }
}
