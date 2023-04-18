using AutoMapper;
using StudentAdmin_API.DomainModels;

namespace StudentAdmin_API.Profiles.AfterMaps
{
    public class AddStudentRequestAfterMap : IMappingAction<AddStudentRequest, DataModels.Student>
    {
        public void Process(AddStudentRequest source, DataModels.Student destination, ResolutionContext context)
        {
            destination.ID = Guid.NewGuid();
            destination.Address = new DataModels.Address()
            {
                Id = new Guid(),
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
            
        }
    }
}
