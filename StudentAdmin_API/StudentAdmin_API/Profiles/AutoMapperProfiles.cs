using AutoMapper;
using StudentAdmin_API.DomainModels;
using StudentAdmin_API.Profiles.AfterMaps;
using DataModels = StudentAdmin_API.DataModels;
namespace StudentAdmin_API.Profiles
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DataModels.Student, Student>().ReverseMap();
            CreateMap<DataModels.Gender, Gender>().ReverseMap();
            CreateMap<DataModels.Address, Address>().ReverseMap();
            CreateMap<UpdateStudentRequest, DataModels.Student>().AfterMap<UpdateStudentRequestAfterMap>();
            
        }
    }
}
