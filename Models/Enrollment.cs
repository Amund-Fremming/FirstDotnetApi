using System;
using Models;

namespace Models;

public class Enrollment
{
    // Foreign key for Student
    public int? StudentId { get; set; }

    // Navigation property for Student
    public Student? Student { get; set; }

    // Foreign key for Course
    public string? CourseId { get; set; }

    // Navigation property for Course
    public Course? Course { get; set; }

    // Status property
    public string? Status { get; set; }

    public Enrollment()
    {
        
    }
}
