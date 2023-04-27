using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student>students= new List<Student>()
        {
                new Student()
                {
                    Id=1,
                    Name="vedant",
                    Age=34,
                    City="Akola"

                },
                 new Student()
                {
                    Id=2,
                    Name="aditya",
                    Age=35,
                    City="jalagaon"

                }
            };
        [HttpGet]
        [Route("getStudents")]
        public async Task<ActionResult<Student>> GetStudents()
        {
            return Ok(students);
        }
        [HttpGet]
        [Route("getStudent")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = students.Find(x => x.Id == id);
                if (student == null)
                return BadRequest("No student found");
            return Ok(students);
        }

        [HttpPost]
        [Route("addStudent")]
        public async Task<ActionResult<Student>> AddStudent(Student request)
        {
            students.Add(request);
            return Ok(students);
        }

        [HttpPut]
        [Route("updateStudent")]
        public async Task<ActionResult<Student>> UpdateStudent(Student request)
        {
            var student = students.Find(x => x.Id == request.Id);
            if (student == null)
                return BadRequest("No student found!");
            student.Name=request.Name;
            student.Age = request.Age;
            student.City = request.City;

            return Ok(students);
            
        }

        [HttpDelete]
        [Route("deleteStudent")]
        public async Task<ActionResult<Student>> deleteStudent(int id)
        {
            var student = students.Find(x => x.Id == id);
            if (student == null)
                return BadRequest("No student found!");
           
            students.Remove(student);
            return Ok(students);

        }
    }
    }

