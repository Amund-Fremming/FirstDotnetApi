using Models;
using Repositories;

namespace Services;

public class CourseService
{
    private readonly CourseRepo _courseRepo;
    public CourseService(CourseRepo courseRepo)
    {   
        _courseRepo = courseRepo;
    }

    public async Task<List<Course>> GetAllCoursesAsync()
    {
        return await _courseRepo.GetAllCourses();
    }

    public async Task AddStudentAsync(Course course)
    {
        await _courseRepo.AddCourseAsync(course);
    }
}