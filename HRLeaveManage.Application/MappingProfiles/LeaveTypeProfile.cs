using AutoMapper;
using HRLeaveManage.Application.Feature.LeaveType.Queries.GetAllLeaveTypes;
using HRLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManage.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailsDto>().ReverseMap();
            // // CreateMap<LeaveType, UpdateLeaveTypeDto>().ReverseMap();
        }
    }
}
