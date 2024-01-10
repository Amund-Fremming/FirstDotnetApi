using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories;

public class StudentRepo
{
    public readonly AppDbContext _context;

    public StudentRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Student?> GetStudentById(int studentId)
    {
        return await _context.Students.FindAsync(studentId);
    }

    public async Task<List<Student>> GetAllStudentsAsync()
    {
        return await _context.Students
                    .Include(e => e.Enrollments)            // The Includes adds the relations to the request
                    .ToListAsync();
    }

    public async Task AddStudentAsync(Student student)
    {
        _context.Add(student);
        await _context.SaveChangesAsync();
    }
}