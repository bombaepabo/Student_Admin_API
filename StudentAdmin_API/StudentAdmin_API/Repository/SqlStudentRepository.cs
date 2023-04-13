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
        public async Task<List<Student>> GetStudentsAsync()
        {
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }

       
    }
}
