using System;
using Models;

namespace Models;

public class Enrollment
{
    public int StudentId { get; set; }
    public Student Student { get; set; }

    public string CourseId { get; set; }
    public Course Course { get; set; }

    public string Status { get; set; }

    public Enrollment(int studentId, string courseId, string status)
    {
        StudentId = studentId;
        CourseId = courseId;
        Status = status ?? throw new ArgumentNullException(nameof(status));
    }
}