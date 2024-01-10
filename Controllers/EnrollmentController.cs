using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers;

[Route("api/enrollment")]
[ApiController]
public class EnrollmentController : ControllerBase
{
    public readonly EnrollmentService _enrollmentService;

    public EnrollmentController(EnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    [HttpGet("/student")]
    public async Task<ActionResult> GetStudentEnrollments([FromQuery] string studentId)
    {
        var idString = int.Parse(studentId);
        var enrollments = await _enrollmentService.GetStudentEnrollments(idString);

        return Ok(enrollments);
    }

    [HttpGet("/course")]
    public async Task<ActionResult> GetCourseEnrollments(string courseId)
    {
        var enrollments = await _enrollmentService.GetCourseEnrollments(courseId);

        return Ok(enrollments);
    }

    [HttpPost]
    public async Task<ActionResult> AddEnrollment([FromQuery] string studentId, [FromQuery] string courseId, [FromQuery] string status)
    {
        await _enrollmentService.AddStudentToCourse(int.Parse(studentId), courseId, status);
        
        return NoContent();
    }
}