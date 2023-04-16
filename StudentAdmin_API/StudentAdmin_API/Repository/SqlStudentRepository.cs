using StudentAdmin_API.DataModels;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentAdmin_API.Repository
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly StudentadminContext context;
        public SqlStudentRepository(StudentadminContext context)
        {
            this.context = context;
        }

        public async Task<Student> GetStudentAsync(Guid studentId)
        {
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).FirstOrDefaultAsync(x => x.ID== studentId);
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }

       
    }
}
