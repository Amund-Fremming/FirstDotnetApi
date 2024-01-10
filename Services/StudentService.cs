using Repositories;
using Models;

namespace Servies;

public class StudentService
{
    public readonly StudentRepo _studentRepo;

    public StudentService(StudentRepo studentRepo)
    {
        _studentRepo = studentRepo;
    }

    public async Task<List<Student>> GetStudentsAsync()
    {
        return await _studentRepo.GetAllStudentsAsync();
    }

    public async Task AddStudentAsync(Student student)
    {
        await _studentRepo.AddStudentAsync(student);
    }
}