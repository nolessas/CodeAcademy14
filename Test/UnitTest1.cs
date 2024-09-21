using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


[TestClass]
public class StudentInformationSystemTests
{
    private StudentInfoContext _context;
    private DbContextOptions<StudentInfoContext> _options;

    [TestInitialize]
    public void TestInitialize()
    {
        _options = new DbContextOptionsBuilder<StudentInfoContext>()
            .UseInMemoryDatabase(databaseName: "TestStudentInfoSystem")
            .Options;

        _context = new StudentInfoContext(_options);
        _context.Database.EnsureCreated();
    }

    [TestCleanup]
    public void TestCleanup()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }

    [TestMethod]
    public void AddStudent_ValidData_ShouldAddSuccessfully()
    {
        // Arrange
        var departmentCode = "CS1234";
        Program.AddDepartment(_context, departmentCode, "Computer Science");

        // Act
        Program.AddStudent(_context, "John", "Doe", "12345678", "john.doe@example.com", departmentCode);

        // Assert
        var student = _context.Students.Find("12345678");
        Assert.IsNotNull(student);
        Assert.AreEqual("John", student.Name);
        Assert.AreEqual("Doe", student.Surname);
        Assert.AreEqual("john.doe@example.com", student.Email);
        Assert.AreEqual(departmentCode, student.DepartmentCode);
    }

    [TestMethod]
    public void AddStudent_InvalidName_ShouldThrowValidationException()
    {
        using (var context = new StudentInfoContext())
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                Program.AddStudent(context, "Jo1n", "Doe", "12345678", "john.doe@example.com", "CS1234");
            });
        }
    }

    [TestMethod]
    public void AddStudent_ShortName_ShouldThrowValidationException()
    {
        using (var context = new StudentInfoContext())
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                Program.AddStudent(context, "J", "Doe", "12345678", "john.doe@example.com", "CS1234");
            });
        }
    }

    [TestMethod]
    public void AddStudent_LongName_ShouldThrowValidationException()
    {
        using (var context = new StudentInfoContext())
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                Program.AddStudent(context, new string('A', 51), "Doe", "12345678", "john.doe@example.com", "CS1234");
            });
        }
    }

    [TestMethod]
    public void AddStudent_InvalidSurname_ShouldThrowValidationException()
    {
        using (var context = new StudentInfoContext())
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                Program.AddStudent(context, "John", "Sm!th", "12345678", "john.doe@example.com", "CS1234");
            });
        }
    }

    [TestMethod]
    public void AddStudent_ShortStudentNumber_ShouldThrowValidationException()
    {
        using (var context = new StudentInfoContext())
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                Program.AddStudent(context, "John", "Doe", "1234567", "john.doe@example.com", "CS1234");
            });
        }
    }

    [TestMethod]
    public void AddStudent_LongStudentNumber_ShouldThrowValidationException()
    {
        using (var context = new StudentInfoContext())
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                Program.AddStudent(context, "John", "Doe", "123456789", "john.doe@example.com", "CS1234");
            });
        }
    }

    [TestMethod]
    public void AddStudent_NonNumericStudentNumber_ShouldThrowValidationException()
    {
        using (var context = new StudentInfoContext())
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                Program.AddStudent(context, "John", "Doe", "1234ABCD", "john.doe@example.com", "CS1234");
            });
        }
    }

    [TestMethod]
    public void AddStudent_DuplicateStudentNumber_ShouldThrowEntityAlreadyExistsException()
    {
        // Arrange
        var departmentCode = "CS1234";
        using (var context = new StudentInfoContext(_options))
        {
            Program.AddDepartment(context, departmentCode, "Computer Science");
            Program.AddStudent(context, "John", "Doe", "12345678", "john.doe@example.com", departmentCode);
        }

        // Act & Assert
        using (var context = new StudentInfoContext(_options))
        {
            var ex = Assert.ThrowsException<EntityAlreadyExistsException>(() =>
            {
                Program.AddStudent(context, "Jane", "Doe", "12345678", "jane.doe@example.com", departmentCode);
            });
            Assert.AreEqual("A student with number 12345678 already exists.", ex.Message);
        }
    }

    [TestMethod]
    public void AddStudent_InvalidEmail_NoAtSymbol_ShouldThrowValidationException()
    {
        using (var context = new StudentInfoContext())
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                Program.AddStudent(context, "John", "Doe", "12345678", "john.doeexample.com", "CS1234");
            });
        }
    }

    [TestMethod]
    public void AddStudent_InvalidEmail_NoDomain_ShouldThrowValidationException()
    {
        using (var context = new StudentInfoContext())
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                Program.AddStudent(context, "John", "Doe", "12345678", "john.doe@", "CS1234");
            });
        }
    }

    [TestMethod]
    public void AddStudent_InvalidEmail_NoLocalPart_ShouldThrowValidationException()
    {
        using (var context = new StudentInfoContext())
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                Program.AddStudent(context, "John", "Doe", "12345678", "@example.com", "CS1234");
            });
        }
    }

    [TestMethod]
    public void AddStudent_InvalidEmail_IncompleteTopLevelDomain_ShouldThrowValidationException()
    {
        using (var context = new StudentInfoContext())
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                Program.AddStudent(context, "John", "Doe", "12345678", "john.doe@example", "CS1234");
            });
        }
    }

    [TestMethod]
    public void AddStudent_NonExistentDepartment_ShouldThrowEntityNotFoundException()
    {
        using (var context = new StudentInfoContext())
        {
            Assert.ThrowsException<EntityNotFoundException>(() =>
            {
                Program.AddStudent(context, "John", "Doe", "12345678", "john.doe@example.com", "NONEXISTENT");
            });
        }
    }

    [TestMethod]
    public void AddDepartment_ValidData_ShouldAddSuccessfully()
    {
        // Act
        Program.AddDepartment(_context, "CS1234", "Computer Science");

        // Assert
        var department = _context.Departments.Find("CS1234");
        Assert.IsNotNull(department);
        Assert.AreEqual("Computer Science", department.Name);
    }

    [TestMethod]
    public void AddDepartment_DuplicateCode_ShouldThrowEntityAlreadyExistsException()
    {
        Program.AddDepartment(_context, "CS1234", "Computer Science");
        Assert.ThrowsException<EntityAlreadyExistsException>(() =>
        {
            Program.AddDepartment(_context, "CS1234", "Another Department");
        });
    }

    [TestMethod]
    public void AddLecture_ValidData_ShouldAddSuccessfully()
    {
        // Act
        Program.AddLecture(_context, "Algorithms", "10:00", "Monday");

        // Assert
        var lecture = _context.Lectures.Find("Algorithms");
        Assert.IsNotNull(lecture);
        Assert.AreEqual("10:00", lecture.Time);
        Assert.AreEqual("Monday", lecture.Day);
    }

    [TestMethod]
    public void AddLecture_DuplicateName_ShouldThrowEntityAlreadyExistsException()
    {
        Program.AddLecture(_context, "Algorithms", "10:00", "Monday");
        Assert.ThrowsException<EntityAlreadyExistsException>(() =>
        {
            Program.AddLecture(_context, "Algorithms", "14:00", "Tuesday");
        });
    }

    [TestMethod]
    public void AssignLectureToDepartment_ValidData_ShouldAssignSuccessfully()
    {
        // Arrange
        Program.AddDepartment(_context, "CS1234", "Computer Science");
        Program.AddLecture(_context, "Algorithms", "10:00", "Monday");

        // Act
        _context.DepartmentLectures.Add(new DepartmentLecture { DepartmentCode = "CS1234", LectureName = "Algorithms" });
        _context.SaveChanges();

        // Assert
        var assignment = _context.DepartmentLectures.FirstOrDefault(dl => dl.DepartmentCode == "CS1234" && dl.LectureName == "Algorithms");
        Assert.IsNotNull(assignment);
    }

    [TestMethod]
    public void TransferStudent_ValidData_ShouldTransferSuccessfully()
    {
        // Arrange
        Program.AddDepartment(_context, "CS1234", "Computer Science");
        Program.AddDepartment(_context, "MTH567", "Mathematics");
        Program.AddStudent(_context, "John", "Doe", "12345678", "john.doe@example.com", "CS1234");

        // Act
        var student = _context.Students.Find("12345678");
        student.DepartmentCode = "MTH567";
        _context.SaveChanges();

        // Assert
        student = _context.Students.Find("12345678");
        Assert.AreEqual("MTH567", student.DepartmentCode);
    }

    [TestMethod]
    public void ViewStudentsInDepartment_ShouldReturnCorrectStudents()
    {
        // Arrange
        Program.AddDepartment(_context, "CS1234", "Computer Science");
        Program.AddStudent(_context, "John", "Doe", "12345678", "john.doe@example.com", "CS1234");
        Program.AddStudent(_context, "Jane", "Doe", "87654321", "jane.doe@example.com", "CS1234");

        // Act
        var students = _context.Students.Where(s => s.DepartmentCode == "CS1234").ToList();

        // Assert
        Assert.AreEqual(2, students.Count);
        Assert.IsTrue(students.Any(s => s.StudentNumber == "12345678"));
        Assert.IsTrue(students.Any(s => s.StudentNumber == "87654321"));
    }

    [TestMethod]
    public void ViewLecturesInDepartment_ShouldReturnCorrectLectures()
    {
        // Arrange
        Program.AddDepartment(_context, "CS1234", "Computer Science");
        Program.AddLecture(_context, "Algorithms", "10:00", "Monday");
        Program.AddLecture(_context, "Data Structures", "14:00", "Tuesday");
        _context.DepartmentLectures.Add(new DepartmentLecture { DepartmentCode = "CS1234", LectureName = "Algorithms" });
        _context.DepartmentLectures.Add(new DepartmentLecture { DepartmentCode = "CS1234", LectureName = "Data Structures" });
        _context.SaveChanges();

        // Act
        var lectures = from dl in _context.DepartmentLectures
                       join l in _context.Lectures on dl.LectureName equals l.Name
                       where dl.DepartmentCode == "CS1234"
                       select l;

        // Assert
        Assert.AreEqual(2, lectures.Count());
        Assert.IsTrue(lectures.Any(l => l.Name == "Algorithms"));
        Assert.IsTrue(lectures.Any(l => l.Name == "Data Structures"));
    }

    [TestMethod]
    public void AddStudent_EmptyName_ShouldThrowValidationException()
    {
        using (var context = new StudentInfoContext())
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                Program.AddStudent(context, "", "Doe", "12345678", "john.doe@example.com", "CS1234");
            });
        }
    }

    [TestMethod]
    public void AddStudent_NullName_ShouldThrowValidationException()
    {
        using (var context = new StudentInfoContext())
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                Program.AddStudent(context, null, "Doe", "12345678", "john.doe@example.com", "CS1234");
            });
        }
    }

    [TestMethod]
    public void AddStudent_EmptyEmail_ShouldThrowValidationException()
    {
        using (var context = new StudentInfoContext())
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                Program.AddStudent(context, "John", "Doe", "12345678", "", "CS1234");
            });
        }
    }

    [TestMethod]
    public void AddStudent_NullEmail_ShouldThrowValidationException()
    {
        using (var context = new StudentInfoContext())
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                Program.AddStudent(context, "John", "Doe", "12345678", null, "CS1234");
            });
        }
    }

    [TestMethod]
    public void AddStudent_NullDepartment_ShouldThrowValidationException()
    {
        using (var context = new StudentInfoContext())
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                Program.AddStudent(context, "John", "Doe", "12345678", "john.doe@example.com", null);
            });
        }
    }

    [TestMethod]
    public void AddDepartment_ShortName_ShouldThrowValidationException()
    {
        using (var context = new StudentInfoContext())
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                Program.AddDepartment(context, "CS", "CS");
            });
        }
    }

    [TestMethod]
    public void AddDepartment_LongName_ShouldThrowValidationException()
    {
        using (var context = new StudentInfoContext())
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                Program.AddDepartment(context, "CS1234", new string('A', 101));
            });
        }
    }

    [TestMethod]
    public void AddDepartment_InvalidCode_ShouldThrowValidationException()
    {
        using (var context = new StudentInfoContext())
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                Program.AddDepartment(context, "CS12@", "Computer Science");
            });
        }
    }

    [TestMethod]
    public void AddLecture_ShortName_ShouldThrowValidationException()
    {
        using (var context = new StudentInfoContext())
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                Program.AddLecture(context, "Math", "10:00", "Monday");
            });
        }
    }

    [TestMethod]
    public void AddLecture_InvalidTime_ShouldThrowValidationException()
    {
        using (var context = new StudentInfoContext())
        {
            Assert.ThrowsException<ValidationException>(() =>
            {
                Program.AddLecture(context, "Algorithms", "25:00", "Monday");
            });
        }
    }

    [TestMethod]
    public void AddLecture_InvalidDay_ShouldThrowValidationException()
    {
        Assert.ThrowsException<ValidationException>(() =>
        {
            Program.AddLecture(_context, "Weekend Algorithms", "10:00", "Sunday");
        });
    }

    [TestMethod]
    public void AssignLectureToStudent_ValidData_ShouldAssignSuccessfully()
    {
        // Arrange
        Program.AddDepartment(_context, "CS1234", "Computer Science");
        Program.AddStudent(_context, "John", "Doe", "12345678", "john.doe@example.com", "CS1234");
        Program.AddLecture(_context, "Algorithms", "10:00", "Monday");

        // Act
        _context.StudentLectures.Add(new StudentLecture { StudentNumber = "12345678", LectureName = "Algorithms" });
        _context.SaveChanges();

        // Assert
        var assignment = _context.StudentLectures.FirstOrDefault(sl => sl.StudentNumber == "12345678" && sl.LectureName == "Algorithms");
        Assert.IsNotNull(assignment);
    }

    [TestMethod]
    public void ViewLecturesForStudent_ShouldReturnCorrectLectures()
    {
        // Arrange
        Program.AddDepartment(_context, "CS1234", "Computer Science");
        Program.AddStudent(_context, "John", "Doe", "12345678", "john.doe@example.com", "CS1234");
        Program.AddLecture(_context, "Algorithms", "10:00", "Monday");
        Program.AddLecture(_context, "Data Structures", "14:00", "Tuesday");
        _context.StudentLectures.Add(new StudentLecture { StudentNumber = "12345678", LectureName = "Algorithms" });
        _context.StudentLectures.Add(new StudentLecture { StudentNumber = "12345678", LectureName = "Data Structures" });
        _context.SaveChanges();

        // Act
        var lectures = from sl in _context.StudentLectures
                       join l in _context.Lectures on sl.LectureName equals l.Name
                       where sl.StudentNumber == "12345678"
                       select l;

        // Assert
        Assert.AreEqual(2, lectures.Count());
        Assert.IsTrue(lectures.Any(l => l.Name == "Algorithms"));
        Assert.IsTrue(lectures.Any(l => l.Name == "Data Structures"));
    }

    [TestMethod]
    public void AddStudent_DuplicateEmail_ShouldThrowEntityAlreadyExistsException()
    {
        // Arrange
        var departmentCode = "CS1234";
        using (var context = new StudentInfoContext(_options))
        {
            Program.AddDepartment(context, departmentCode, "Computer Science");
            Program.AddStudent(context, "John", "Doe", "12345678", "john.doe@example.com", departmentCode);
        }

        // Act & Assert
        using (var context = new StudentInfoContext(_options))
        {
            var ex = Assert.ThrowsException<EntityAlreadyExistsException>(() =>
            {
                Program.AddStudent(context, "Jane", "Doe", "87654321", "john.doe@example.com", departmentCode);
            });
            Assert.AreEqual("A student with email john.doe@example.com already exists.", ex.Message);
        }
    }

    [TestMethod]
    public void AddLecture_OverlappingTime_ShouldThrowValidationException()
    {
        // Arrange
        var departmentCode = "CS1234";
        Program.AddDepartment(_context, departmentCode, "Computer Science");
        Program.AddLecture(_context, "Algorithms", "10:00", "Monday");
        _context.DepartmentLectures.Add(new DepartmentLecture { DepartmentCode = departmentCode, LectureName = "Algorithms" });
        _context.SaveChanges();

        // Act & Assert
        Assert.ThrowsException<ValidationException>(() =>
        {
            Program.AddLecture(_context, "Data Structures", "11:00", "Monday");
        });
    }

    [TestMethod]
    public void TransferStudent_UpdatesLectures_Successfully()
    {
        // Arrange
        Program.AddDepartment(_context, "CS1234", "Computer Science");
        Program.AddDepartment(_context, "MTH567", "Mathematics");
        Program.AddLecture(_context, "Algorithms", "10:00", "Monday");
        Program.AddLecture(_context, "Data Structures", "14:00", "Tuesday");
        Program.AddLecture(_context, "Calculus", "10:00", "Wednesday");
        _context.DepartmentLectures.Add(new DepartmentLecture { DepartmentCode = "CS1234", LectureName = "Algorithms" });
        _context.DepartmentLectures.Add(new DepartmentLecture { DepartmentCode = "CS1234", LectureName = "Data Structures" });
        _context.DepartmentLectures.Add(new DepartmentLecture { DepartmentCode = "MTH567", LectureName = "Calculus" });
        Program.AddStudent(_context, "John", "Doe", "12345678", "john.doe@example.com", "CS1234");
        _context.StudentLectures.Add(new StudentLecture { StudentNumber = "12345678", LectureName = "Algorithms" });
        _context.StudentLectures.Add(new StudentLecture { StudentNumber = "12345678", LectureName = "Data Structures" });
        _context.SaveChanges();

        // Act
        Program.TransferStudent(_context, "12345678", "MTH567");

        // Assert
        var student = _context.Students.Find("12345678");
        Assert.AreEqual("MTH567", student.DepartmentCode);

        var studentLectures = _context.StudentLectures.Where(sl => sl.StudentNumber == "12345678").ToList();
        Assert.AreEqual(1, studentLectures.Count);
        Assert.AreEqual("Calculus", studentLectures[0].LectureName);
    }

    [TestMethod]
    public void TransferStudent_NonExistentStudent_ShouldThrowEntityNotFoundException()
    {
        using (var context = new StudentInfoContext())
        {
            // Add departments only if they don't exist
            if (context.Departments.Find("CS1234") == null)
            {
                Program.AddDepartment(context, "CS1234", "Computer Science");
            }
            if (context.Departments.Find("MTH567") == null)
            {
                Program.AddDepartment(context, "MTH567", "Mathematics");
            }

            Assert.ThrowsException<EntityNotFoundException>(() =>
            {
                Program.TransferStudent(context, "99999999", "MTH567");
            });
        }
    }

    [TestMethod]
    public void AddDepartmentWithExistingLectures_ValidData_ShouldAddSuccessfully()
    {
        // Arrange
        Program.AddLecture(_context, "Algorithms", "10:00", "Monday");
        Program.AddLecture(_context, "Data Structures", "14:00", "Tuesday");

        // Act
        Program.AddDepartmentWithExistingLectures(_context, "CS1234", "Computer Science", new List<string> { "Algorithms", "Data Structures" });

        // Assert
        var department = _context.Departments.Find("CS1234");
        Assert.IsNotNull(department);
        Assert.AreEqual("Computer Science", department.Name);

        var departmentLectures = _context.DepartmentLectures.Where(dl => dl.DepartmentCode == "CS1234").ToList();
        Assert.AreEqual(2, departmentLectures.Count);
        Assert.IsTrue(departmentLectures.Any(dl => dl.LectureName == "Algorithms"));
        Assert.IsTrue(departmentLectures.Any(dl => dl.LectureName == "Data Structures"));
    }

    [TestMethod]
    public void AddDepartmentWithExistingLectures_NonExistentLecture_ShouldThrowEntityNotFoundException()
    {
        // Arrange
        Program.AddLecture(_context, "Algorithms", "10:00", "Monday");

        // Act & Assert
        Assert.ThrowsException<EntityNotFoundException>(() =>
        {
            Program.AddDepartmentWithExistingLectures(_context, "CS1234", "Computer Science", new List<string> { "Algorithms", "NonExistentLecture" });
        });
    }
}