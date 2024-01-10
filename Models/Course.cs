using System;

namespace Models;

public class Course
{
    public string? CourseId { get; set; }
    public string? Name { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; }

    public Course()
    {
        Enrollments = new HashSet<Enrollment>();
    }

    public Course(string courseId, string name) : this()
    {
        CourseId = courseId ?? throw new ArgumentNullException(nameof(courseId));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}