using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories;

public class CourseRepo
{
    private readonly AppDbContext _context;

    public CourseRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Course?> GetCourseById(string courseId)
    {
        return await _context.Courses.FindAsync(courseId);
    }

    public async Task<List<Course>> GetAllCourses()
    {
        return await _context.Courses
                    .Include(e => e.Enrollments)
                    .ToListAsync();
    }

    public async Task AddCourseAsync(Course course)
    {
        _context.Add(course);
        await _context.SaveChangesAsync();
    }
}