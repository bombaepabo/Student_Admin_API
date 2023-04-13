﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdmin_API.DataModels;
using StudentAdmin_API.DomainModels;
using StudentAdmin_API.Repository;

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


    }
}