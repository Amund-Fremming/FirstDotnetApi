using System;

namespace Models;

public class Course
{
    public string CourseId { get; set; }
    public string Name { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; }

    public Course(string courseId, string name)
    {
        CourseId = courseId ?? throw new ArgumentNullException(nameof(courseId));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}