using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

public static class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Base Directory: {AppDomain.CurrentDomain.BaseDirectory}");

        using (var context = new StudentInfoContext())
        {
            context.Database.EnsureCreated();
            context.SeedData();
        }

        MainMenu.Run();
    }


    public static void AddStudent(StudentInfoContext context, string name, string surname, string studentNumber, string email, string departmentCode)
    {
        try
        {
            if (!Validator.IsValidName(name))
                throw new ValidationException("Invalid name. Name must be 2-50 characters long and contain only letters.");

            if (!Validator.IsValidName(surname))
                throw new ValidationException("Invalid surname. Surname must be 2-50 characters long and contain only letters.");

            if (!Validator.IsValidStudentNumber(studentNumber))
                throw new ValidationException("Invalid student number. Student number must be exactly 8 digits.");

            if (!Validator.IsValidEmail(email))
                throw new ValidationException("Invalid email address.");

            if (string.IsNullOrWhiteSpace(departmentCode))
                throw new ValidationException("Department code is required.");

            var department = context.Departments.Find(departmentCode)
                ?? throw new EntityNotFoundException($"Department with code {departmentCode} not found.");

            var existingStudent = context.Students.Find(studentNumber);
            if (existingStudent != null)
                throw new EntityAlreadyExistsException($"A student with number {studentNumber} already exists.");

            var existingEmail = context.Students.FirstOrDefault(s => s.Email == email);
            if (existingEmail != null)
                throw new EntityAlreadyExistsException($"A student with email {email} already exists.");

            var student = new Student
            {
                Name = name,
                Surname = surname,
                StudentNumber = studentNumber,
                Email = email,
                DepartmentCode = departmentCode
            };
            context.Students.Add(student);
            context.SaveChanges();
        }
        catch (StudentInfoSystemException ex)
        {
            // Log the exception
            Console.WriteLine($"Error adding student: {ex.Message}");
            throw; // Re-throw to be handled by the UI layer
        }
    }

    public static void AddDepartment(StudentInfoContext context, string code, string name)
    {
        try
        {
            if (!Validator.IsValidDepartmentName(name))
                throw new ValidationException("Invalid department name. Name must be 3-100 characters long and contain only letters, numbers, and spaces.");

            if (!Validator.IsValidDepartmentCode(code))
                throw new ValidationException("Invalid department code. Code must be exactly 6 characters long and contain only letters and numbers.");

            var existingDepartment = context.Departments.Find(code);
            if (existingDepartment != null)
                throw new EntityAlreadyExistsException("A department with this code already exists.");

            var department = new Department { Name = name, Code = code };
            context.Departments.Add(department);
            context.SaveChanges();
        }
        catch (StudentInfoSystemException ex)
        {
            // Log the exception
            Console.WriteLine($"Error adding department: {ex.Message}");
            throw; // Re-throw to be handled by the UI layer
        }
    }

    public static void AddLecture(StudentInfoContext context, string name, string time, string day)
    {
        try
        {
            if (!Validator.IsValidLectureName(name))
                throw new ValidationException("Invalid lecture name. Name must be at least 5 characters long.");

            if (!Validator.IsValidLectureTime(time))
                throw new ValidationException("Invalid lecture time. Time must be in HH:MM format and between 00:00 and 23:59.");

            if (!Validator.IsValidLectureDay(day))
                throw new ValidationException("Invalid lecture day. Day must be Monday, Tuesday, Wednesday, Thursday, or Friday.");

            var existingLecture = context.Lectures.Find(name);
            if (existingLecture != null)
                throw new EntityAlreadyExistsException("A lecture with this name already exists.");

            // Check for overlapping lectures
            var startTime = TimeSpan.Parse(time);
            var endTime = startTime.Add(TimeSpan.FromHours(1.5));
            var overlappingLecture = context.Lectures.FirstOrDefault(l => l.Day == day &&
                TimeSpan.Parse(l.Time) < endTime &&
                TimeSpan.Parse(l.Time).Add(TimeSpan.FromHours(1.5)) > startTime);
            if (overlappingLecture != null)
                throw new ValidationException("This lecture time overlaps with an existing lecture.");

            var lecture = new Lecture { Name = name, Time = time, Day = day };
            context.Lectures.Add(lecture);
            context.SaveChanges();
        }
        catch (StudentInfoSystemException ex)
        {
            // Log the exception
            Console.WriteLine($"Error adding lecture: {ex.Message}");
            throw; // Re-throw to be handled by the UI layer
        }
    }

    public static void TransferStudent(StudentInfoContext context, string studentNumber, string newDepartmentCode)
    {
        var student = context.Students.Find(studentNumber);
        if (student == null)
            throw new EntityNotFoundException("Student not found.");

        var newDepartment = context.Departments.Find(newDepartmentCode);
        if (newDepartment == null)
            throw new EntityNotFoundException("New department not found.");

        var oldDepartmentCode = student.DepartmentCode;

        // Remove student from old department lectures
        var oldStudentLectures = context.StudentLectures
            .Where(sl => sl.StudentNumber == studentNumber)
            .ToList();
        context.StudentLectures.RemoveRange(oldStudentLectures);

        // Update student's department
        student.DepartmentCode = newDepartmentCode;

        // Add student to new department lectures
        var newDepartmentLectures = context.DepartmentLectures
            .Where(dl => dl.DepartmentCode == newDepartmentCode)
            .ToList();
        foreach (var lecture in newDepartmentLectures)
        {
            context.StudentLectures.Add(new StudentLecture { StudentNumber = studentNumber, LectureName = lecture.LectureName });
        }

        context.SaveChanges();

        Console.WriteLine($"Student {studentNumber} transferred from {oldDepartmentCode} to {newDepartmentCode}");
        Console.WriteLine("New lectures:");
        foreach (var lecture in newDepartmentLectures)
        {
            Console.WriteLine($"- {lecture.LectureName}");
        }
    }

    public static void AddDepartmentWithExistingLectures(StudentInfoContext context, string code, string name, List<string> lectureNames)
    {
        try
        {
            if (!Validator.IsValidDepartmentName(name))
                throw new ValidationException("Invalid department name. Name must be 3-100 characters long and contain only letters, numbers, and spaces.");

            if (!Validator.IsValidDepartmentCode(code))
                throw new ValidationException("Invalid department code. Code must be exactly 6 characters long and contain only letters and numbers.");

            var existingDepartment = context.Departments.Find(code);
            if (existingDepartment != null)
                throw new EntityAlreadyExistsException("A department with this code already exists.");

            var department = new Department { Name = name, Code = code };
            context.Departments.Add(department);

            foreach (var lectureName in lectureNames)
            {
                var lecture = context.Lectures.Find(lectureName);
                if (lecture == null)
                    throw new EntityNotFoundException($"Lecture {lectureName} not found.");

                context.DepartmentLectures.Add(new DepartmentLecture { DepartmentCode = code, LectureName = lectureName });
            }

            context.SaveChanges();
        }
        catch (StudentInfoSystemException ex)
        {
            // Log the exception
            Console.WriteLine($"Error adding department with existing lectures: {ex.Message}");
            throw; // Re-throw to be handled by the UI layer
        }
    }
}
