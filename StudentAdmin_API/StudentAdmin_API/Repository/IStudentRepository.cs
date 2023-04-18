using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using StudentAdmin_API.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace StudentAdmin_API.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(Guid studentId);
        Task<List<Gender>> GetGendersAsync();
        Task<bool> Exists(Guid studentId);
        Task<Student> UpdateStudent(Guid studentId, Student student);
        Task<Student> DeleteStudent(Guid studentId);
        Task<Student> AddStudent(Student request);
        Task<bool> UpdateProfileImage(Guid studentId, string profileImageUrl);
  
    }
}