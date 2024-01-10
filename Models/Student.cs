using System;
using System.Collections.Generic; // Required for ICollection

namespace Models;

public class Student
{
    public int? StudentId { get; set; }
    public string? Name { get; set; }

    // Initialize the collection in the constructor
    public virtual ICollection<Enrollment> Enrollments { get; set; }

    // Parameterless constructor for EF Core
    public Student()
    {
        Enrollments = new HashSet<Enrollment>();
    }

    // Additional constructor for convenience
    public Student(int studentId, string name) : this()
    {
        StudentId = studentId;
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}
