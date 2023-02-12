using Project.Core.Entities;
using Project.Services.ModalServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<JobTittle, JobTittleModel>();
            CreateMap<JobTittleModel, JobTittle>();
            CreateMap<Department, DepartmentDataModel>();
            CreateMap<DepartmentDataModel, Department>();
            CreateMap<AddressBookModel, AddressBook>();
            CreateMap<AddressBook, AddressBookModel>()
           .ForMember(dest => dest.JobName, act => act.MapFrom(src => src.JobTittle.JobName))
           .ForMember(dest => dest.DepartmentName, act => act.MapFrom(src => src.Department.DepartmentName));

        }
    }
}
