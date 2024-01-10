using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Data.SqlClient;

namespace Repositories;

public class EnrollmentRepo
{
    public readonly AppDbContext _context;

    public EnrollmentRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Enrollment>> GetStudentEnrollments(int studentId)
    {
        return await _context.Enrollments
                            .Where(e => e.Student.StudentId == studentId)
                            .Include(e => e.Student)
                            .Include(e => e.Course)
                            .ToListAsync();
    }

    public async Task<List<Enrollment>> GetCourseEnrollments(string courseId)
    {
        return await _context.Enrollments
                            .Where(e => e.Course.CourseId == courseId)
                            .ToListAsync();
    }

    public async Task AddStudentToCourse(Enrollment enrollment)
    {
        _context.Add(enrollment);
        await _context.SaveChangesAsync();
    }
}