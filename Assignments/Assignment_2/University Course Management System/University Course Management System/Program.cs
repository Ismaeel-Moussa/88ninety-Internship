
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using University_Course_Management_System.DataAccess;
using University_Course_Management_System.Entities;


// Seed data 
void SeedUsers() 
{
    using var context = new UniversityDbContext();

    context.Users.AddRange(new List<User>
    {
        new() {
            UserName = "Ismaeel-Moussa",
            FirstName = "Ismaeel",
            LastName = "Moussa",
            EmailAddress = "ismaeel.moussa1@gmail.com",
            PhoneNumber = "+905346917747",
            Role = "Student"
        },
        new() {
            UserName = "Abdulsalam-Fateh",
            FirstName = "Abdulsalam",
            LastName = "Fateh",
            EmailAddress = "fatehabdalsalam@gmail.com",
            PhoneNumber = "+963958361088",
            Role = "Student"
        },
        new() {
            UserName = "Ahmad-Thaer-Ater",
            FirstName = "Ahmad",
            LastName = "Ater",
            EmailAddress = "aeter520@gmail.com",
            PhoneNumber = "+963946946565",
            Role = "Student"
        },
        new() {
            UserName = "Ihap-Abuwarda",
            FirstName = "Ihap",
            LastName = "Abuwarda",
            EmailAddress = "ihababuwardah@gmail.com",
            PhoneNumber = "+905355807082",
            Role = "Student"
        },
        new() {
            UserName = "Muhammed-Elrimi",
            FirstName = "Muhammed",
            LastName = "Elrimi",
            EmailAddress = "mohamadrimi12345@gmail.com",
            PhoneNumber = "+905343346036",
            Role = "Student"
        },
        new() {
            UserName = "Wasem-Alhariri",
            FirstName = "Wasem",
            LastName = "Alhariri",
            EmailAddress = "wasemalhariri13@gmail.com",
            PhoneNumber = "+963994801706",
            Role = "Student"
        },
        new() {
            UserName = "Sami-Hijazi",
            FirstName = "Sami",
            LastName = "Hijazi",
            EmailAddress = "sami.hijazi@88ninety.com",
            PhoneNumber = "+1(240)381-9639",
            Role = "Teacher"
        },
        new() {
            UserName = "Feryal-Tulaimat",
            FirstName = "Feryal",
            LastName = "Tulaimat",
            EmailAddress = "feryal.tulaimat@88ninety.com",
            PhoneNumber = "+905523381309",
            Role = "Teacher"
        }
    });

    context.SaveChanges();
}

void SeedSyllabi()
{
    using var context = new UniversityDbContext();

    context.Syllabi.AddRange(new List<Syllabus>
    {
        new() {Description = "Study fundamentals of sql"},
        new() {Description = "Learn C# fundamentals"},
        new() {Description = "Learn fundamentals of Entity Framework"},
        new() {Description = "Learn Requests and Status code of web api"},
        new() {Description = "Learn Components and state management in react"},
    });

    context.SaveChanges();

}

void SeedCourses()
{
    using var context = new UniversityDbContext();

    context.Courses.AddRange(new List<Course>
{
    new()
    {
        CourseName = "SQL",
        StartDate = DateTime.Parse("2026-12-03"),
        EndDate = DateTime.Parse("2027-01-01"),
        TeacherId = 7,
        SyllabusId = 1
    },
    new()
    {
        CourseName = "C#",
        StartDate = DateTime.Parse("2026-09-03"),
        EndDate = DateTime.Parse("2026-11-03"),
        TeacherId = 8,
        SyllabusId = 2
    },
    new()
    {
        CourseName = "Entity Framework",
        StartDate = DateTime.Parse("2025-03-03"),
        EndDate = DateTime.Parse("2025-06-03"),
        TeacherId = 7,
        SyllabusId = 3
    },
    new()
    {
        CourseName = "Web api",
        StartDate = DateTime.Parse("2026-02-03"),
        EndDate = DateTime.Parse("2026-09-03"),
        TeacherId = 8,
        SyllabusId = 4
    },
    new()
    {
        CourseName = "React",
        StartDate = DateTime.Parse("2026-01-03"),
        EndDate = DateTime.Parse("2026-04-03"),
        TeacherId = 7,
        SyllabusId = 5
    }
});

    context.SaveChanges();
}

void SeedAssignments() 
{
    using var context = new UniversityDbContext();

    context.Assignments.AddRange(new List<Assignment>
{
    // Course 1 - SQL
    new() { CourseId = 1, AssignmentTitle = "Learn Syntax", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-11-11") },
    new() { CourseId = 1, AssignmentTitle = "Create Database", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-01-03") },
    new() { CourseId = 1, AssignmentTitle = "Learn Select", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-05-03") },
    new() { CourseId = 1, AssignmentTitle = "Learn Insert", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-01-09") },
    new() { CourseId = 1, AssignmentTitle = "Learn Index", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-07-03") },

    // Course 2 - C#
    new() { CourseId = 2, AssignmentTitle = "Learn Functions in C#", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-08-06") },
    new() { CourseId = 2, AssignmentTitle = "Learn Classes in C#", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-07-06") },
    new() { CourseId = 2, AssignmentTitle = "Learn Objects in C#", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-02-06") },
    new() { CourseId = 2, AssignmentTitle = "Learn OOP in C#", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-01-06") },
    new() { CourseId = 2, AssignmentTitle = "Learn Linq in C#", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-09-06") },

    // Course 3 - Entity Framework
    new() { CourseId = 3, AssignmentTitle = "Learn Fundamentals of EF", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-08-06") },
    new() { CourseId = 3, AssignmentTitle = "Learn DbContext", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-07-06") },
    new() { CourseId = 3, AssignmentTitle = "Convert classes into tables", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-02-06") },
    new() { CourseId = 3, AssignmentTitle = "Manipulate Queries using Linq", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-01-06") },
    new() { CourseId = 3, AssignmentTitle = "Learn Migrations", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-09-06") },

    // Course 4 - Web API
    new() { CourseId = 4, AssignmentTitle = "Learn Fundamentals of web api", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-08-06") },
    new() { CourseId = 4, AssignmentTitle = "Learn HTTP Requests", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-07-06") },
    new() { CourseId = 4, AssignmentTitle = "Learn Status codes", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-02-06") },
    new() { CourseId = 4, AssignmentTitle = "Learn Json", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-01-06") },
    new() { CourseId = 4, AssignmentTitle = "Learn web History", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-09-06") },

    // Course 5 - React
    new() { CourseId = 5, AssignmentTitle = "Learn Fundamentals React", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-08-06") },
    new() { CourseId = 5, AssignmentTitle = "Learn State", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-07-06") },
    new() { CourseId = 5, AssignmentTitle = "Learn Components", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-02-06") },
    new() { CourseId = 5, AssignmentTitle = "Learn UseEffect", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-01-06") },
    new() { CourseId = 5, AssignmentTitle = "Learn Conditional Rendering", Weight = 20, MaxGrade = 100, DueDate = DateTime.Parse("2026-09-06") }
});

    context.SaveChanges();
}

void SeedComments()
{
    using var context = new UniversityDbContext();

    context.Comments.AddRange(new List<Comment>
    {
        new() { CommentContent = "It was very good", CreatedDate = DateTime.Parse("2026-03-03"), AssignmentId = 1, CreatedByUserId = 1 },
        new() { CommentContent = "It was very good", CreatedDate = DateTime.Parse("2026-01-03"), AssignmentId = 12, CreatedByUserId = 2 },
        new() { CommentContent = "It was very good", CreatedDate = DateTime.Parse("2026-06-03"), AssignmentId = 8, CreatedByUserId = 3 },
        new() { CommentContent = "It was very good", CreatedDate = DateTime.Parse("2026-03-08"), AssignmentId = 22, CreatedByUserId = 4 },
        new() { CommentContent = "It was very good", CreatedDate = DateTime.Parse("2026-07-03"), AssignmentId = 25, CreatedByUserId = 5 },
        new() { CommentContent = "It was very good", CreatedDate = DateTime.Parse("2026-11-03"), AssignmentId = 16, CreatedByUserId = 6 },
        new() { CommentContent = "It was very good", CreatedDate = DateTime.Parse("2026-12-03"), AssignmentId = 6, CreatedByUserId = 4 },
        new() { CommentContent = "It was very good", CreatedDate = DateTime.Parse("2026-02-03"), AssignmentId = 19, CreatedByUserId = 1 },
        new() { CommentContent = "It was very good", CreatedDate = DateTime.Parse("2026-07-10"), AssignmentId = 23, CreatedByUserId = 2 },
        new() { CommentContent = "It was very good", CreatedDate = DateTime.Parse("2026-03-15"), AssignmentId = 14, CreatedByUserId = 3 }
    });

    context.SaveChanges();
}

void SeedGrades()
{
   using var context = new UniversityDbContext();

    context.Grades.AddRange(new List<Grade>
    {
        new() {Mark = 81 ,AssignmentId = 1, StudentId = 1},
        new() {Mark = 89 ,AssignmentId = 2, StudentId = 1},
        new() {Mark = 68 ,AssignmentId = 3, StudentId = 1},
        new() {Mark = 88 ,AssignmentId = 4, StudentId = 1},
        new() {Mark = 93 ,AssignmentId = 5, StudentId = 1},
        new() {Mark = 93 ,AssignmentId = 6, StudentId = 1},
        new() {Mark = 79 ,AssignmentId = 7, StudentId = 1},
        new() {Mark = 89 ,AssignmentId = 8, StudentId = 1},
        new() {Mark = 72 ,AssignmentId = 9, StudentId = 1},
        new() {Mark = 86 ,AssignmentId = 10, StudentId = 1},
        new() {Mark = 92 ,AssignmentId = 11, StudentId = 1},
        new() {Mark = 71 ,AssignmentId = 12, StudentId = 1},
        new() {Mark = 65 ,AssignmentId = 13, StudentId = 1},
        new() {Mark = 72 ,AssignmentId = 14, StudentId = 1},
        new() {Mark = 81 ,AssignmentId = 15, StudentId = 1},
        new() {Mark = 70 ,AssignmentId = 16, StudentId = 1},
        new() {Mark = 77 ,AssignmentId = 17, StudentId = 1},
        new() {Mark = 71 ,AssignmentId = 18, StudentId = 1},
        new() {Mark = 80 ,AssignmentId = 19, StudentId = 1},
        new() {Mark = 67 ,AssignmentId = 20, StudentId = 1},
        new() {Mark = 92 ,AssignmentId = 21, StudentId = 1},
        new() {Mark = 91 ,AssignmentId = 22, StudentId = 1},
        new() {Mark = 66 ,AssignmentId = 23, StudentId = 1},
        new() {Mark = 85 ,AssignmentId = 24, StudentId = 1},
        new() {Mark = 90 ,AssignmentId = 25, StudentId = 1},
        new() {Mark = 73 ,AssignmentId = 1, StudentId = 2},
        new() {Mark = 84 ,AssignmentId = 2, StudentId = 2},
        new() {Mark = 81 ,AssignmentId = 3, StudentId = 2},
        new() {Mark = 78 ,AssignmentId = 4, StudentId = 2},
        new() {Mark = 82 ,AssignmentId = 5, StudentId = 2},
        new() {Mark = 73 ,AssignmentId = 6, StudentId = 2},
        new() {Mark = 90 ,AssignmentId = 7, StudentId = 2},
        new() {Mark = 92 ,AssignmentId = 8, StudentId = 2},
        new() {Mark = 66 ,AssignmentId = 9, StudentId = 2},
        new() {Mark = 70 ,AssignmentId = 10, StudentId = 2},
        new() {Mark = 78 ,AssignmentId = 11, StudentId = 2},
        new() {Mark = 69 ,AssignmentId = 12, StudentId = 2},
        new() {Mark = 67 ,AssignmentId = 13, StudentId = 2},
        new() {Mark = 69 ,AssignmentId = 14, StudentId = 2},
        new() {Mark = 89 ,AssignmentId = 15, StudentId = 2},
        new() {Mark = 70 ,AssignmentId = 16, StudentId = 2},
        new() {Mark = 72 ,AssignmentId = 17, StudentId = 2},
        new() {Mark = 81 ,AssignmentId = 18, StudentId = 2},
        new() {Mark = 82 ,AssignmentId = 19, StudentId = 2},
        new() {Mark = 67 ,AssignmentId = 20, StudentId = 2},
        new() {Mark = 88 ,AssignmentId = 21, StudentId = 2},
        new() {Mark = 86 ,AssignmentId = 22, StudentId = 2},
        new() {Mark = 65 ,AssignmentId = 23, StudentId = 2},
        new() {Mark = 87 ,AssignmentId = 24, StudentId = 2},
        new() {Mark = 98 ,AssignmentId = 25, StudentId = 2},
        new() {Mark = 99 ,AssignmentId = 1, StudentId = 3},
        new() {Mark = 91 ,AssignmentId = 2, StudentId = 3},
        new() {Mark = 99 ,AssignmentId = 3, StudentId = 3},
        new() {Mark = 90 ,AssignmentId = 4, StudentId = 3},
        new() {Mark = 73 ,AssignmentId = 5, StudentId = 3},
        new() {Mark = 65 ,AssignmentId = 6, StudentId = 3},
        new() {Mark = 75 ,AssignmentId = 7, StudentId = 3},
        new() {Mark = 83 ,AssignmentId = 8, StudentId = 3},
        new() {Mark = 90 ,AssignmentId = 9, StudentId = 3},
        new() {Mark = 85 ,AssignmentId = 10, StudentId = 3},
        new() {Mark = 90 ,AssignmentId = 11, StudentId = 3},
        new() {Mark = 95 ,AssignmentId = 12, StudentId = 3},
        new() {Mark = 65 ,AssignmentId = 13, StudentId = 3},
        new() {Mark = 72 ,AssignmentId = 14, StudentId = 3},
        new() {Mark = 86 ,AssignmentId = 15, StudentId = 3},
        new() {Mark = 70 ,AssignmentId = 16, StudentId = 3},
        new() {Mark = 90 ,AssignmentId = 17, StudentId = 3},
        new() {Mark = 73 ,AssignmentId = 18, StudentId = 3},
        new() {Mark = 87 ,AssignmentId = 19, StudentId = 3},
        new() {Mark = 75 ,AssignmentId = 20, StudentId = 3},
        new() {Mark = 80 ,AssignmentId = 21, StudentId = 3},
        new() {Mark = 93 ,AssignmentId = 22, StudentId = 3},
        new() {Mark = 86 ,AssignmentId = 23, StudentId = 3},
        new() {Mark = 74 ,AssignmentId = 24, StudentId = 3},
        new() {Mark = 90 ,AssignmentId = 25, StudentId = 3},
        new() {Mark = 97 ,AssignmentId = 1, StudentId = 4},
        new() {Mark = 87 ,AssignmentId = 2, StudentId = 4},
        new() {Mark = 67 ,AssignmentId = 3, StudentId = 4},
        new() {Mark = 73 ,AssignmentId = 4, StudentId = 4},
        new() {Mark = 77 ,AssignmentId = 5, StudentId = 4},
        new() {Mark = 81 ,AssignmentId = 6, StudentId = 4},
        new() {Mark = 87 ,AssignmentId = 7, StudentId = 4},
        new() {Mark = 67 ,AssignmentId = 8, StudentId = 4},
        new() {Mark = 67 ,AssignmentId = 9, StudentId = 4},
        new() {Mark = 86 ,AssignmentId = 10, StudentId = 4},
        new() {Mark = 67 ,AssignmentId = 11, StudentId = 4},
        new() {Mark = 77 ,AssignmentId = 12, StudentId = 4},
        new() {Mark = 74 ,AssignmentId = 13, StudentId = 4},
        new() {Mark = 92 ,AssignmentId = 14, StudentId = 4},
        new() {Mark = 80 ,AssignmentId = 15, StudentId = 4},
        new() {Mark = 76 ,AssignmentId = 16, StudentId = 4},
        new() {Mark = 95 ,AssignmentId = 17, StudentId = 4},
        new() {Mark = 99 ,AssignmentId = 18, StudentId = 4},
        new() {Mark = 83 ,AssignmentId = 19, StudentId = 4},
        new() {Mark = 77 ,AssignmentId = 20, StudentId = 4},
        new() {Mark = 78 ,AssignmentId = 21, StudentId = 4},
        new() {Mark = 79 ,AssignmentId = 22, StudentId = 4},
        new() {Mark = 91 ,AssignmentId = 23, StudentId = 4},
        new() {Mark = 84 ,AssignmentId = 24, StudentId = 4},
        new() {Mark = 77 ,AssignmentId = 25, StudentId = 4},
        new() {Mark = 87 ,AssignmentId = 1, StudentId = 5},
        new() {Mark = 74 ,AssignmentId = 2, StudentId = 5},
        new() {Mark = 85 ,AssignmentId = 3, StudentId = 5},
        new() {Mark = 99 ,AssignmentId = 4, StudentId = 5},
        new() {Mark = 71 ,AssignmentId = 5, StudentId = 5},
        new() {Mark = 65 ,AssignmentId = 6, StudentId = 5},
        new() {Mark = 77 ,AssignmentId = 7, StudentId = 5},
        new() {Mark = 91 ,AssignmentId = 8, StudentId = 5},
        new() {Mark = 66 ,AssignmentId = 9, StudentId = 5},
        new() {Mark = 98 ,AssignmentId = 10, StudentId = 5},
        new() {Mark = 83 ,AssignmentId = 11, StudentId = 5},
        new() {Mark = 81 ,AssignmentId = 12, StudentId = 5},
        new() {Mark = 96 ,AssignmentId = 13, StudentId = 5},
        new() {Mark = 80 ,AssignmentId = 14, StudentId = 5},
        new() {Mark = 78 ,AssignmentId = 15, StudentId = 5},
        new() {Mark = 68 ,AssignmentId = 16, StudentId = 5},
        new() {Mark = 90 ,AssignmentId = 17, StudentId = 5},
        new() {Mark = 79 ,AssignmentId = 18, StudentId = 5},
        new() {Mark = 70 ,AssignmentId = 19, StudentId = 5},
        new() {Mark = 91 ,AssignmentId = 20, StudentId = 5},
        new() {Mark = 73 ,AssignmentId = 21, StudentId = 5},
        new() {Mark = 93 ,AssignmentId = 22, StudentId = 5},
        new() {Mark = 90 ,AssignmentId = 23, StudentId = 5},
        new() {Mark = 95 ,AssignmentId = 24, StudentId = 5},
        new() {Mark = 78 ,AssignmentId = 25, StudentId = 5},
        new() {Mark = 71 ,AssignmentId = 1, StudentId = 6},
        new() {Mark = 94 ,AssignmentId = 2, StudentId = 6},
        new() {Mark = 66 ,AssignmentId = 3, StudentId = 6},
        new() {Mark = 93 ,AssignmentId = 4, StudentId = 6},
        new() {Mark = 90 ,AssignmentId = 5, StudentId = 6},
        new() {Mark = 74 ,AssignmentId = 6, StudentId = 6},
        new() {Mark = 96 ,AssignmentId = 7, StudentId = 6},
        new() {Mark = 94 ,AssignmentId = 8, StudentId = 6},
        new() {Mark = 83 ,AssignmentId = 9, StudentId = 6},
        new() {Mark = 97 ,AssignmentId = 10, StudentId = 6},
        new() {Mark = 91 ,AssignmentId = 11, StudentId = 6},
        new() {Mark = 65 ,AssignmentId = 12, StudentId = 6},
        new() {Mark = 80 ,AssignmentId = 13, StudentId = 6},
        new() {Mark = 83 ,AssignmentId = 14, StudentId = 6},
        new() {Mark = 67 ,AssignmentId = 15, StudentId = 6},
        new() {Mark = 96 ,AssignmentId = 16, StudentId = 6},
        new() {Mark = 78 ,AssignmentId = 17, StudentId = 6},
        new() {Mark = 96 ,AssignmentId = 18, StudentId = 6},
        new() {Mark = 80 ,AssignmentId = 19, StudentId = 6},
        new() {Mark = 84 ,AssignmentId = 20, StudentId = 6},
        new() {Mark = 90 ,AssignmentId = 21, StudentId = 6},
        new() {Mark = 77 ,AssignmentId = 22, StudentId = 6},
        new() {Mark = 66 ,AssignmentId = 23, StudentId = 6},
        new() {Mark = 75 ,AssignmentId = 24, StudentId = 6},
        new() {Mark = 71 ,AssignmentId = 25, StudentId = 6},
    });

   context.SaveChanges();

  
}

// Get data
List<Course> GetAllCourses()
{
    using var context = new UniversityDbContext();

    return [.. context.Courses];
}

List<Assignment> GetAllAssignmentsByCourseId(int CourseId)
{
    using var context = new UniversityDbContext();
    return [.. context.Assignments.Where(a => a.CourseId == CourseId)];
}

List<User> GetAllStudents()
{
    using var context = new UniversityDbContext();
    return [.. context.Users.Where(u => u.Role == "Student")];
}

List<User> GetAllTeachers()
{
    using var context = new UniversityDbContext();
    return [.. context.Users.Where(u => u.Role == "Teacher")];
}

List<Comment> GetAllCommentsByAssignmentId(int AssignmentId)
{
    using var context = new UniversityDbContext();
    return [.. context.Comments.Where(c => c.AssignmentId == AssignmentId)];
}

List<Grade> GetAllGradesByStudentId(int StudentId)
{
    using var context = new UniversityDbContext();
    return [.. context.Grades.Where(g => g.StudentId == StudentId)];
}

// Print data
void PrintCourses(List<Course> courses)
{

    Console.WriteLine("Printing Courses:");
    Console.WriteLine($"======================================================================");
    Console.WriteLine($"    {"CourseName",-5} | {"StartDate",-5} | {"EndDate",-5} | {"TeacherId",-5} | {"SyllabusId",-5}");
    Console.WriteLine($"======================================================================");

    foreach (var course in courses)
    {
        Console.WriteLine($"{course.CourseName}, {course.StartDate:d}, {course.EndDate:d}, {course.TeacherId}, {course.SyllabusId}");
    }

    Console.WriteLine("\n");

}

void PrintAssignments(List<Assignment> assignments)
{
    Console.WriteLine("Printing Assignments:");
    Console.WriteLine($"===========================================================================");
    Console.WriteLine($"    {"AssignmentTitle",-5} | {"Weight",-5} | {"MaxGrade",-5} | {"DueDate",-5} | {"CourseId",-5}");
    Console.WriteLine($"===========================================================================");

    foreach (var assignment in assignments)
    {
        Console.WriteLine($"{assignment.AssignmentTitle}, {assignment.Weight}, {assignment.MaxGrade}, {assignment.DueDate:d}, {assignment.CourseId}");
    }

    Console.WriteLine("\n");

}

void PrintUsers(List<User> users, string role = "users")
{
    string roleToPrint = role == "students" ? "Students" : role == "teachers" ? "Teachers" : "Users";
    Console.WriteLine($"Printing {roleToPrint}:");
    Console.WriteLine($"===========================================================================");
    Console.WriteLine($"    {"UserName",-5} | {"FirstName",-5} | {"LastName",-5} | {"EmailAddress",-5} | {"PhoneNumber",-5} | {"Role",-5}");
    Console.WriteLine($"===========================================================================");

    foreach (var user in users)
    {
        Console.WriteLine($"{user.UserName}, {user.FirstName}, {user.LastName}, {user.EmailAddress}, {user.PhoneNumber}, {user.Role}");
    }

    Console.WriteLine("\n");

}

void PrintComments(List<Comment> comments)
{
    Console.WriteLine($"======================================================================");
    Console.WriteLine($"    {"CommentContent",-5} | {"CreatedDate",-5} | {"AssignmentId",-5} | {"CreatedByUserId",-5}");
    Console.WriteLine($"======================================================================");
    foreach (var comment in comments)
    {
        Console.WriteLine($"{comment.CommentContent}, {comment.CreatedDate:d}, {comment.AssignmentId}, {comment.CreatedByUserId}");
    }

    Console.WriteLine("\n");    
}

void PrintGrades(List<Grade> grades)
{
    Console.WriteLine($"======================================================================");
    Console.WriteLine($"    {"Mark",-5} | {"AssignmentId",-5} | {"StudentId",-5}");
    Console.WriteLine($"======================================================================");
    foreach (var grade in grades)
    {
        Console.WriteLine($"{grade.Mark}, {grade.AssignmentId}, {grade.StudentId}");
    }
    Console.WriteLine("\n");
}

// Get and print data
void GetAndPrintAllAssignmentsWithCourseNameAndTeacherFullName()
{
    using var context = new UniversityDbContext();
    var assignments = context.Assignments
        .Select(a => new
        {
            a.AssignmentTitle,
            a.Weight,
            a.MaxGrade,
            a.DueDate,
            a.Course.CourseName,
            TeacherFullName = $"{a.Course.Teacher.FirstName} {a.Course.Teacher.LastName}"
        })
        .ToList();

    Console.WriteLine($"Printing Assignments with it's course and teacher:");
    Console.WriteLine($"================================================================================");
    Console.WriteLine($"    {"AssignmentTitle",-5} | {"Weight",-5} | {"MaxGrade",-5} | {"DueDate",-5} | {"CourseName",-5} | {"TeacherFullName",-5}");
    Console.WriteLine($"================================================================================");

    foreach (var assignment in assignments)
    {
        Console.WriteLine($"{assignment.AssignmentTitle}, {assignment.Weight}, {assignment.MaxGrade}, {assignment.DueDate}, {assignment.CourseName}, {assignment.TeacherFullName}");
    }

    Console.WriteLine("\n");


}

async Task GetAndPrintAverageGradePerCourse()
{
    using var context = new UniversityDbContext();

    // i used here async/await so the grouping happens in sql not in memory.
    var averageGrades = await context.Grades
          .GroupBy(g => g.Assignment.Course)
          .Select(g => new
          {
              g.Key.CourseName,
              AverageGrade = (int)g.Average(g => g.Mark)
          }).ToListAsync();

    Console.WriteLine($"======================================================================");
    Console.WriteLine($"    {"CourseName",-5} | {"AverageGrade",-5}");
    Console.WriteLine($"======================================================================");
    foreach (var grade in averageGrades)
    {
        Console.WriteLine($"{grade.CourseName}, {grade.AverageGrade}");
    }
    Console.WriteLine("\n");


}

// calculate data
char CalculateStudentGradeInCourse(int StudentId, int CourseId)
{
    if (StudentId <= 0 || CourseId <= 0) return ',';

    using var context = new UniversityDbContext();

    var student = context.Users.FirstOrDefault(u => u.Id == StudentId);
    if (student == null)
    {
        Console.WriteLine("Student not found");
        return ',';
    }

    var course = context.Courses.FirstOrDefault(u => u.Id == CourseId);
    if (course == null)
    {
        Console.WriteLine("Course not found");
        return ',';
    }

    var studentGradesInCourse = context.Grades
        .Where(g => g.StudentId == StudentId && g.Assignment.CourseId == CourseId);

    if (!studentGradesInCourse.Any())
    {
        Console.WriteLine("There is no grades for this student in this course");
        return ',';
    }

    var averageStudentGradeInCourse = studentGradesInCourse.Average(g => g.Mark);

    return averageStudentGradeInCourse switch
    {
        > 90 => 'A',
        > 80 => 'B',
        > 70 => 'C',
        > 60 => 'D',
        > 40 => 'E',
        _ => 'F',
    };
}

double CalculateStudentGPA(int studentId)
{
    if (studentId <= 0) return 0;

    using var context = new UniversityDbContext();

    var student = context.Users.FirstOrDefault(u => u.Id == studentId);
    if (student == null)
    {
        Console.WriteLine("Student not found");
        return 0;
    }

    double sumOfGradesInCourses = 0;
    int NumberOfCourses = 0;

    for (int courseId = 1; courseId <= 5; courseId++)
    {
        char studentGradeInCourse = CalculateStudentGradeInCourse(studentId, courseId);

        if (studentGradeInCourse == ',') continue;

        NumberOfCourses++;
        sumOfGradesInCourses += studentGradeInCourse switch
        {
            'A' => 4,
            'B' => 3.5,
            'C' => 3,
            'D' => 2.5,
            'E' => 2,
            _ => 0,

        };
    }

    double gpa = sumOfGradesInCourses / NumberOfCourses;
    return gpa;
}

// update data
void UpdateUserRoleTo(int userId, string updateToRole)
{
    using var context = new UniversityDbContext();

    var student = context.Users.FirstOrDefault(s => s.Id == userId);

    if (student == null) return;
    if (student.Role == updateToRole) return;

    var role = student.Role;

    student.Role = updateToRole;

    context.SaveChanges();

    Console.WriteLine($"Updates from {role} to {student.Role}");
}

// delete data
void DeleteCommentById(int commentId)
{
    using var context = new UniversityDbContext();

    var comment = context.Comments.FirstOrDefault(s => s.Id == commentId);

    if (comment == null) return;

    context.Comments.Remove(comment);

    context.SaveChanges();

    Console.WriteLine("Comment deleted successfully.");
}


//// Seeding data
//SeedUsers();
//SeedSyllabi();
//SeedCourses();
//SeedAssignments();
//SeedComments();
//SeedGrades();

//// Printing data
PrintCourses(GetAllCourses());
PrintAssignments(GetAllAssignmentsByCourseId(1));
PrintUsers(GetAllStudents(), "students");
PrintComments(GetAllCommentsByAssignmentId(1));
PrintGrades(GetAllGradesByStudentId(1));

//// Get and Print data
GetAndPrintAllAssignmentsWithCourseNameAndTeacherFullName();
await GetAndPrintAverageGradePerCourse();

// calculate data
Console.WriteLine($"Student Grade in Course : {CalculateStudentGradeInCourse(1, 1)}");
Console.WriteLine($"Student GPA = {CalculateStudentGPA(1)}");

// update data
UpdateUserRoleTo(5, "Teacher");

// delete data
DeleteCommentById(9);




Console.ReadKey();

