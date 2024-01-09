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

    public async Task<List<Course>> GetAllCourses()
    {
        return await _context.Courses.ToListAsync();
    }

    public async Task AddCourseAsync(Course course)
    {
        _context.Add(course);
        await _context.SaveChangesAsync();
    }
}