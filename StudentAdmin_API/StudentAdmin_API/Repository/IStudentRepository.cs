using StudentAdmin_API.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace StudentAdmin_API.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(Guid studentId);
    }
}
