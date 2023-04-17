using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdmin_API.DataModels;
using StudentAdmin_API.DomainModels;
using StudentAdmin_API.Repository;
using Student = StudentAdmin_API.DomainModels.Student;

namespace StudentAdmin_API.Controllers
{
    [ApiController]
    public class StudentController: Controller
    {
        private readonly IStudentRepository studentrepository;
        private readonly IMapper mapper;
        public StudentController(IStudentRepository studentrepository,IMapper mapper)
        {
            this.studentrepository = studentrepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudentAsync()
        {
            var students = await studentrepository.GetStudentsAsync();
            
            
            return Ok(mapper.Map<List<DomainModels.Student>>(students));
        }
        [HttpGet]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)
        {
            var student = await studentrepository.GetStudentAsync(studentId);

            if (student == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<DomainModels.Student>(student));
        }
        [HttpPut]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentsAsync([FromRoute] Guid studentId,
            [FromBody] UpdateStudentRequest request)
        {
            
            if(await studentrepository.Exists(studentId))
            {
                var updatedStudent = await studentrepository.UpdateStudent(studentId,mapper.Map<DataModels.Student>(request));
                if(updatedStudent != null)
                {
                    return Ok(mapper.Map<Student>(updatedStudent));
                }
            }
           
                return NotFound();
    

        }




    }
}
