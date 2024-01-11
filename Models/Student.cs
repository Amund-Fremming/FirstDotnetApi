using System;
using System.Collections.Generic; // Required for ICollection

namespace Models;

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }

    public Student(int studentId, string name)
    {
        Enrollments = new HashSet<Enrollment>();
        StudentId = studentId;
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}
