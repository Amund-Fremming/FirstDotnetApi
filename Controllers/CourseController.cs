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
    public ActionResult GetAllCourses() {
        List<Course> Courses = _courseService.GetAllCoursesAsync();

        return Ok();
    }

    [HttpPost]
}