using Microsoft.AspNetCore.Mvc;
using Servies;
using Models;
using System.Numerics;
using Microsoft.EntityFrameworkCore.Storage;

namespace Controller;

[Route("api/student")]
[ApiController]
public class StudentController : ControllerBase
{
    public readonly StudentService _studentService;

    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllStudents()
    {   
        var students = await _studentService.GetStudentsAsync();
        return Ok(students);
    }

    [HttpPost]
    public async Task<ActionResult> AddStudent([FromQuery] string studentId, [FromQuery] string name)
    {
        var idString = int.Parse(studentId);
        Student student = new Student(idString, name);

        await _studentService.AddStudentAsync(student);

        return NoContent();
    }
}