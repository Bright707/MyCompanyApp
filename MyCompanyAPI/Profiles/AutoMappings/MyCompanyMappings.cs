using AutoMapper;
using MyCompanyAPI.DTOs;
using MyCompanyAPI.Models;

namespace MyCompanyAPI.Profiles.AutoMappings
{
    public class MyCompanyMappings : Profile
    {
        public MyCompanyMappings()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();

            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();

            CreateMap<Project, ProjectDTO>();
            CreateMap<ProjectDTO, Project>();
        }
    }
}
