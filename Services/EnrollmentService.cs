using Models;
using Repositories;

namespace Services;

public class EnrollmentService
{
    public readonly EnrollmentRepo _enrollmentRepo;
    public readonly StudentRepo _studentRepo;
    public readonly CourseRepo _courseRepo;

    public EnrollmentService(EnrollmentRepo enrollmentRepo, StudentRepo studentRepo, CourseRepo courseRepo)
    {
        _enrollmentRepo = enrollmentRepo;
        _studentRepo = studentRepo;
        _courseRepo = courseRepo;
    }

    public async Task<List<Enrollment>> GetStudentEnrollments(int studentId)
    {
        return await _enrollmentRepo.GetStudentEnrollments(studentId);
    }

    public async Task<List<Enrollment>> GetCourseEnrollments(string courseId)
    {
        return await _enrollmentRepo.GetCourseEnrollments(courseId);
    }

    public async Task AddStudentToCourse(int studentId, string courseId, string status)
    {
        var student = await _studentRepo.GetStudentById(studentId);
        var course = await _courseRepo.GetCourseById(courseId);

        if(student == null)
        {
            throw new ArgumentException($"Student with id {studentId} does not exists.");
        }

        if(course == null)
        {
            throw new ArgumentException($"Course with id {courseId} does not exists.");
        }

        Enrollment enrollment = new Enrollment
        {
            StudentId = studentId,
            Student = student,
            CourseId = courseId,
            Course = course,
            Status = status
        };

        await _enrollmentRepo.AddStudentToCourse(enrollment);
    }
}