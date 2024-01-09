using Microsoft.AspNetCore.Mvc;
using Services;
using Models;

namespace Controllers;

[Route("api/course")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly CourseService _courseService;

    public CourseController(CourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllCourses() {
        var courses = await _courseService.GetAllCoursesAsync();
        return Ok(courses);
    }

    [HttpPost]
    public async Task<ActionResult> CreateNewCourse([FromQuery] string courseId, [FromQuery] string name) {
        Course course = new Course(courseId, name);
        await _courseService.AddCourseAsync(course);

        return NoContent();
    }
}