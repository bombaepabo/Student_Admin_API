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
        private readonly IImageRepository imagerepository;

        public StudentController(IStudentRepository studentrepository, IMapper mapper, IImageRepository imagerepository)
        {
            this.studentrepository = studentrepository;
            this.mapper = mapper;
            this.imagerepository = imagerepository;
        }
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudentAsync()
        {
            var students = await studentrepository.GetStudentsAsync();
            
            
            return Ok(mapper.Map<List<DomainModels.Student>>(students));
        }
        [HttpGet]
        [Route("[controller]/{studentId:guid}"), ActionName("GetStudentAsync")]
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

            if (await studentrepository.Exists(studentId))
            {
                var updatedStudent = await studentrepository.UpdateStudent(studentId, mapper.Map<DataModels.Student>(request));
                if (updatedStudent != null)
                {
                    return Ok(mapper.Map<Student>(updatedStudent));
                }
            }

            return NotFound();


        }
        [HttpDelete]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] Guid studentId)
        {
            if (await studentrepository.Exists(studentId))
            {
                var student = await studentrepository.DeleteStudent(studentId);
                return Ok(mapper.Map<Student>(student));
            }
            return NotFound();
        }
        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddStudentAsync([FromBody] AddStudentRequest request)
        {
          var student =  await studentrepository.AddStudent(mapper.Map<DataModels.Student>(request));
            return CreatedAtAction(nameof(GetStudentAsync), new {studentId = student.ID},
                mapper.Map<Student>(student)); 
        }
        [HttpPost]
        [Route("[controller]/{studentId:guid}/upload-image")]
        public async Task<IActionResult> UploadProfileImage([FromRoute] Guid studentId,IFormFile profileimage) {
               var validExtensions = new List<string> { 
               ".jpeg",
               ".png",
               ".gif",
               ".jpg"
               };
            if(profileimage != null && profileimage.Length >0)
            {
                var extension = Path.GetExtension(profileimage.FileName);
                if (validExtensions.Contains(extension))
                {
            if(await studentrepository.Exists(studentId))
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(profileimage.FileName);
               var fileimagePath =  await imagerepository.Upload(profileimage, fileName);
               if(await studentrepository.UpdateProfileImage(studentId, fileimagePath))
                {
                    return Ok(fileimagePath);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Error uploading image");
            }

                }
            }
            return BadRequest("This is not a valid Image format");
        }
            
        




    }
}
