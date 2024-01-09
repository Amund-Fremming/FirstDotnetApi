using System;

namespace Models;

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; }

    public Student(int studentId, string name)
    {
        StudentId = studentId;
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}