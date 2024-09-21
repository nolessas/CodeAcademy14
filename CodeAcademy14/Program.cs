// this is my training work i want you create a plan of c# entity console app this is the guildines of the project :
/*

Here's a comprehensive summary of the student information system project based on all three images:
Project Overview: Student Information System
Entities:
1. Department: Has many students and many lectures.
Lecture: Belongs to many departments.
Student: Has many lectures, belongs to one department.
Functionalities:
Create a department and add students and lectures to it.
Add students/lectures to an existing department.
3. Create a lecture and assign it to a department.
Create a student, add them to an existing department, and assign existing lectures.
Transfer a student to another department.
Display all students in a department.
7. Display all lectures in a department.
Display all lectures for a specific student.
Data Validation:
Student name and surname: only letters, 2-50 characters.
Student number: unique, only numbers, exactly 8 characters.
Student email: must be in correct format.
Department name: 3-100 characters, can include letters and numbers.
Department code: unique, only letters and numbers, exactly 6 characters.
Lecture name: unique, at least 5 characters.
Lecture time: must match realistic time intervals.
Validation should be performed before entering data into the database.
Create at least 3 additional custom validations.
Grading Criteria (Total: 100 points + up to 10 bonus points):
Code Quality (30 points)
Clarity and Readability (10 points)
C# Coding Guidelines (10 points)
Error Handling (10 points)
2. Database Design and Integration (30 points)
Schema Design (10 points)
Data Management (10 points)
Database Connection (10 points)
Functionality (30 points)
Core Requirements (15 points)
Additional Features (10 points)
Error-Free Execution (5 points)
4. User Interface (10 points)
User-Friendly (5 points)
Navigation (5 points)
Additional Tasks (up to 10 bonus points)
Validator Tests (5 points)
Documentation (5 points)
Key Focus Areas:
Code organization, readability, and adherence to C# guidelines
Proper database design and integration
Implementation of core and additional functionalities
Robust error handling and data validation
User-friendly interface design and logical navigation
Comprehensive testing and documentation
Additional Notes:
Bonus points for adding lectures from an existing database when creating a department
Bonus points for changing a student's lectures when transferring to a new department
Emphasis on creating a well-structured, efficient, and user-friendly system that accurately manages the relationships between departments, lectures, and students in an educational setting.





Kai įrašomi departamentų duomenys iš departments.csv
- Sukurti du departamentai su kodais CS1234 ir MTH567
- Departamentų pavadinimai turi būti ComputerScience ir Mathematics
Kai įrašomi paskaitų duomenys iš lectures.csv, duomenys turi būti
- Sukurtos trys paskaitos: Algorithms, Calculus, DataStructures.
- Paskaitų laikai turi būti 10:00, 12:00, 14:00
Kai įrašomi studentų duomenys iš students.csv, duomenys turi būti:
- Sukurti du studentai: John Smith ir Alice Johnson.
Kai įrašomi departamentų ir paskaitų asociacijų duomenys iš department_lectures.csv, duomenys turi būti:
- Departamentas CS1234 turi būti susietas su paskaitomis Algorithms ir DataStructures.
- Departamentas MTH567 turi būti susietas su paskaitomis Calculus.
Kai įrašomi studentų ir paskaitų asociacijų duomenys iš student_lectures.csv, duomenys turi būti:
- Studentas 12345678 (John Smith) turi būti užregistruotas į paskaitas Algorithms ir DataStructures.
- Studentas 87654321 (Alice Johnson) turi būti užregistruotas į paskaitą Calculus.
 
Validaciju testai:
- Jei paduodami studento vardas "Jo1n" ir pavardė "Smith", tai gaunama klaida, nes vardas turi būti sudarytas tik iš raidžių.
- Jei paduodami studento vardas "J" ir pavardė "Smith", tai gaunama klaida, nes vardas turi būti ne trumpesnis kaip 2 simboliai.
- Jei paduodami studento vardas "JohnathonJohnathonJohnathonJohnathonJohnathon" (51 simbolis) ir pavardė "Smith", tai gaunama klaida, nes vardas turi būti ne ilgesnis kaip 50 simbolių.
- Jei paduodami studento vardas "John" ir pavardė "Sm!th", tai gaunama klaida, nes pavardė turi būti sudaryta tik iš raidžių.
- Jei paduodami studento numeris "1234567" (7 skaitmenys), tai gaunama klaida, nes numeris turi būti tiksliai 8 simbolių ilgio.
- Jei paduodami studento numeris "123456789" (9 skaitmenys), tai gaunama klaida, nes numeris turi būti tiksliai 8 simbolių ilgio.
- Jei paduodami studento numeris "1234ABCD", tai gaunama klaida, nes numeris turi būti sudarytas tik iš skaičių.
- Jei paduodami studento numeris "12345678", kuris jau egzistuoja duomenų bazėje, tai gaunama klaida dėl numerio unikalumo pažeidimo.
- Jei paduodami studento numeris "ABC" (3 simboliai), tai gaunama 2 klaidos, (1)numeris turi būti tiksliai 8 simbolių ilgio,  (2)numeris turi būti sudarytas tik iš skaičių.
- Jei paduodami studento el. paštas "john.smithexample.com" (trūksta @), tai gaunama klaida, nes el. paštas turi būti teisingo formato.
- Jei paduodami studento el. paštas "john.smith@" (trūksta domeno), tai gaunama klaida dėl netinkamo formato.
- Jei paduodami studento el. paštas "@example.com" (trūksta vietovardžio), tai gaunama klaida dėl netinkamo formato.
- Jei paduodami studento el. paštas "john.smith@example" (trūksta domeno pabaigos), tai gaunama klaida dėl netinkamo formato.
- Jei paduodami studento el. paštas "john.smith@example." (trūksta domeno pabaigos), tai gaunama klaida dėl netinkamo formato.
- Jei nepaduodamas studento el. paštas, tai gaunama klaida, nes el. paštas yra privalomas.
- Jei nepaduodamas studento Departamentas, tai gaunama klaida, nes Departamentas yra privalomas.
- Jei paduodami studento vardas tuščias """ arba null, tai gaunama klaida, nes vardas yra privalomas laukas.
- Jei paduodami paskaitos pavadinimas tuščias """ arba null, tai gaunama klaida, nes pavadinimas yra privalomas laukas.
- Jei paduodami du studentai su tuo pačiu el. pašto adresu "alice.johnson@example.com", tai gaunama klaida dėl el. pašto unikalumo pažeidimo.
 
- Jei paduodami departamento pavadinimas "CS" (2 simboliai), tai gaunama klaida, nes pavadinimas turi būti ne trumpesnis kaip 3 simboliai.
- Jei paduodami departamento pavadinimas "Computer Science & Engineering" (su specialiaisiais simboliais), tai gaunama klaida, nes pavadinime gali būti tik raidės ir skaičiai.
- Jei paduodami departamento kodas "CS12" (4 simboliai), tai gaunama klaida, nes kodas turi būti tiksliai 6 simbolių ilgio.
- Jei paduodami departamento kodas "CS123@", tai gaunama klaida, nes kode gali būti tik raidės ir skaičiai.
- Jei paduodami departamento kodas "CS1234" kuris jau egzistuoja duomenų bazėje, tai gaunama klaida dėl kodo unikalumo pažeidimo.
- Jei sukuriama paskaita su pavadinimu "DataStructures" ir priskiriama departamentui su kodu "MTH567", tai gaunama sėkmingas pridėjimas.
- Jei sukuriama paskaita su pavadinimu "DataStructures" ir priskiriama departamentui su kodu "CS1234", tai gaunama klaida dėl to kad tokia paskaita departamente jau yra.
 
- Jei paduodami paskaitos pavadinimas "Math" (4 simboliai), tai gaunama klaida, nes pavadinimas turi būti ne trumpesnis kaip 5 simboliai.
 
- Jei paduodami paskaitos laikas "25:00-26:30", tai gaunama klaida, nes pradžios ir pabaigos laikas turi būti tarp 00:00 ir 24:00.
- Jei paduodami paskaitos laikas "14:00-13:00", tai gaunama klaida, nes pabaigos laikas negali būti ankstesnis už pradžios laiką.
- Jei paduodami dvi paskaitos tame pačiame departamente su laikais "10:00-11:30" ir "11:00-12:30", tai gaunama įspėjimas arba klaida dėl laiko persidengimo.
- Jei paduodama paskaitos savaitės diena "Sunday", tai gaunama klaida, nes savaitės diena gali būti tik Monday, Tuesday, Wednesday, Thursday, Friday.
- Jei paskaitos savaitės diena yra null, tuomet paskaitos skaitomos kasdien nuo Monday iki Friday.
 
- Jei paduodami studentas su numeriu "12345679" priskiriamas departamentui su kodu "ENG999", kuris neegzistuoja, tai gaunama klaida dėl neegzistuojančio departamento.
- Jei paduodami studentas iš departamento "CS1234" priskiriamas paskaitai "Calculus", kuri nepriklauso jo departamentui, tai gaunama klaida.
 
- Jei paduodami studentas su numeriu "12345678" perkeliamas į departamentą su kodu "MTH567", tai gaunama sėkmingas perkėlimas, o jo paskaitos atnaujinamos pagal naują departamentą (jei toks funkcionalumas numatytas).
- Jei paduodami studentas su numeriu "12345678" perkeliamas į neegzistuojantį departamentą "ENG999", tai gaunama klaida dėl neegzistuojančio departamento.
*/

using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

public static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    static void Main(string[] args)
    {
        Console.WriteLine($"Base Directory: {AppDomain.CurrentDomain.BaseDirectory}");

        using (var context = new StudentInfoContext())
        {
            context.Database.EnsureCreated();
            context.SeedData();
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Student Information System");
            Console.WriteLine("1. Manage Departments");
            Console.WriteLine("2. Manage Lectures");
            Console.WriteLine("3. Manage Students");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ManageDepartments();
                    break;
                case "2":
                    ManageLectures();
                    break;
                case "3":
                    ManageStudents();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    /// <summary>
    /// Manages the department-related operations.
    /// </summary>
    static void ManageDepartments()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Department Management");
            Console.WriteLine("1. Add Department");
            Console.WriteLine("2. Add Department with Existing Lectures");
            Console.WriteLine("3. View All Departments");
            Console.WriteLine("4. View Students in Department");
            Console.WriteLine("5. View Lectures in Department");
            Console.WriteLine("6. Back to Main Menu");
            Console.Write("Enter your choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddDepartment();
                    break;
                case "2":
                    AddDepartmentWithExistingLectures();
                    break;
                case "3":
                    ViewAllDepartments();
                    break;
                case "4":
                    ViewStudentsInDepartment();
                    break;
                case "5":
                    ViewLecturesInDepartment();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }
    /// <summary>
    /// Manages the lecture-related operations.
    /// </summary>
    static void ManageLectures()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Lecture Management");
            Console.WriteLine("1. Add Lecture");
            Console.WriteLine("2. View All Lectures");
            Console.WriteLine("3. Assign Lecture to Department");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Enter your choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddLecture();
                    break;
                case "2":
                    ViewAllLectures();
                    break;
                case "3":
                    AssignLectureToDepartment();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }
    /// <summary>
    /// Manages the student-related operations.
    /// </summary>
    static void ManageStudents()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Student Management");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Assign Lecture to Student");
            Console.WriteLine("4. Transfer Student to Another Department");
            Console.WriteLine("5. View Lectures for Student");
            Console.WriteLine("6. Back to Main Menu");
            Console.Write("Enter your choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    ViewAllStudents();
                    break;
                case "3":
                    AssignLectureToStudent();
                    break;
                case "4":
                    TransferStudent();
                    break;
                case "5":
                    ViewLecturesForStudent();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }
    /// <summary>
    /// Adds a new student to the system.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="name">The student's first name.</param>
    /// <param name="surname">The student's last name.</param>
    /// <param name="studentNumber">The student's unique number.</param>
    /// <param name="email">The student's email address.</param>
    /// <param name="departmentCode">The code of the department the student belongs to.</param>
    static void AddStudent()
    {
        try
        {
            string name = GetValidInput("Enter Student Name: ", Validator.IsValidName, "Invalid name. Name must be 2-50 characters long and contain only letters.");
            string surname = GetValidInput("Enter Student Surname: ", Validator.IsValidName, "Invalid surname. Surname must be 2-50 characters long and contain only letters.");
            string studentNumber = GetValidInput("Enter Student Number: ", Validator.IsValidStudentNumber, "Invalid student number. Must be exactly 8 digits.");
            string email = GetValidInput("Enter Student Email: ", Validator.IsValidEmail, "Invalid email address.");
            string departmentCode = GetValidInput("Enter Department Code: ", Validator.IsValidDepartmentCode, "Invalid department code. Must be exactly 6 characters (letters and numbers only).");

            using (var context = new StudentInfoContext())
            {
                AddStudent(context, name, surname, studentNumber, email, departmentCode);
                Console.WriteLine("Student added successfully.");
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Operation cancelled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
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

    static void AddDepartment()
    {
        try
        {
            string name = GetValidInput("Enter Department Name: ", Validator.IsValidDepartmentName, "Invalid department name. Name must be 3-100 characters long and contain only letters, numbers, and spaces.");
            string code = GetValidInput("Enter Department Code: ", Validator.IsValidDepartmentCode, "Invalid department code. Must be exactly 6 characters (letters and numbers only).");

            using (var context = new StudentInfoContext())
            {
                AddDepartment(context, code, name);
                Console.WriteLine("Department added successfully.");
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Operation cancelled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    /// <summary>
    /// Adds a new department to the system.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="code">The unique code for the department.</param>
    /// <param name="name">The name of the department.</param>
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

    static void AddLecture()
    {
        try
        {
            string name = GetValidInput("Enter Lecture Name: ", Validator.IsValidLectureName, "Invalid lecture name. Name must be at least 5 characters long.");
            string time = GetValidInput("Enter Lecture Time (HH:MM): ", Validator.IsValidLectureTime, "Invalid lecture time. Time must be in HH:MM format and between 00:00 and 23:59.");
            string day = GetValidInput("Enter Lecture Day (Monday, Tuesday, Wednesday, Thursday, Friday): ", Validator.IsValidLectureDay, "Invalid lecture day. Day must be Monday, Tuesday, Wednesday, Thursday, or Friday.");

            using (var context = new StudentInfoContext())
            {
                AddLecture(context, name, time, day);
                Console.WriteLine("Lecture added successfully.");
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Operation cancelled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    /// <summary>
    /// Adds a new lecture to the system.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="name">The name of the lecture.</param>
    /// <param name="time">The time of the lecture.</param>
    /// <param name="day">The day of the lecture.</param>
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

    static void ViewAllDepartments()
    {
        using (var context = new StudentInfoContext())
        {
            var departments = from d in context.Departments
                              select d;

            foreach (var dept in departments)
            {
                Console.WriteLine($"Code: {dept.Code}, Name: {dept.Name}");
            }
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void ViewAllLectures()
    {
        using (var context = new StudentInfoContext())
        {
            var lectures = from l in context.Lectures
                           select l;

            foreach (var lecture in lectures)
            {
                Console.WriteLine($"Name: {lecture.Name}, Time: {lecture.Time}, Day: {lecture.Day}");
            }
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void ViewAllStudents()
    {
        using (var context = new StudentInfoContext())
        {
            var students = from s in context.Students
                           select s;

            foreach (var student in students)
            {
                Console.WriteLine($"Student Number: {student.StudentNumber}, Name: {student.Name} {student.Surname}, " +
                                  $"Email: {student.Email}, " +
                                  $"Department Code: {student.DepartmentCode}");
            }
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void AssignLectureToDepartment()
    {
        try
        {
            string lectureName = GetValidInput("Enter Lecture Name: ", Validator.IsValidLectureName, "Invalid lecture name. Name must be at least 5 characters long.");
            string departmentCode = GetValidInput("Enter Department Code: ", Validator.IsValidDepartmentCode, "Invalid department code. Must be exactly 6 characters (letters and numbers only).");

            using (var context = new StudentInfoContext())
            {
                AssignLectureToDepartment(context, lectureName, departmentCode);
                Console.WriteLine("Lecture assigned to department successfully.");
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Operation cancelled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    /// <summary>
    /// Assigns a lecture to a department.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="lectureName">The name of the lecture to assign.</param>
    /// <param name="departmentCode">The code of the department to assign the lecture to.</param>
    static void AssignLectureToDepartment(StudentInfoContext context, string lectureName, string departmentCode)
    {
        try
        {
            var lecture = context.Lectures.Find(lectureName);
            var department = context.Departments.Find(departmentCode);

            if (lecture == null || department == null)
                throw new EntityNotFoundException("Lecture or Department not found.");

            var startTime = TimeSpan.Parse(lecture.Time);
            var endTime = startTime.Add(TimeSpan.FromHours(1.5));

            if (Validator.IsLectureTimeOverlapping(context, departmentCode, lecture.Day, startTime, endTime))
                throw new ValidationException("This lecture time overlaps with an existing lecture in the department.");

            var existingAssignment = context.DepartmentLectures.FirstOrDefault(dl => dl.DepartmentCode == departmentCode && dl.LectureName == lectureName);
            if (existingAssignment != null)
                throw new EntityAlreadyExistsException("This lecture is already assigned to the department.");

            context.DepartmentLectures.Add(new DepartmentLecture { DepartmentCode = departmentCode, LectureName = lectureName });
            context.SaveChanges();
        }
        catch (StudentInfoSystemException ex)
        {
            // Log the exception
            Console.WriteLine($"Error assigning lecture to department: {ex.Message}");
            throw; // Re-throw to be handled by the UI layer
        }
    }
    /// <summary>
    /// Assigns a lecture to a student.
    /// </summary>
    static void AssignLectureToStudent()
    {
        try
        {
            string studentNumber = GetValidInput("Enter Student Number: ", Validator.IsValidStudentNumber, "Invalid student number. Must be exactly 8 digits.");
            string lectureName = GetValidInput("Enter Lecture Name: ", Validator.IsValidLectureName, "Invalid lecture name. Name must be at least 5 characters long.");

            using (var context = new StudentInfoContext())
            {
                var student = context.Students.Find(studentNumber);
                var lecture = context.Lectures.Find(lectureName);

                if (student != null && lecture != null)
                {
                    context.StudentLectures.Add(new StudentLecture { StudentNumber = studentNumber, LectureName = lectureName });
                    context.SaveChanges();
                    Console.WriteLine("Lecture assigned to student successfully.");
                }
                else
                {
                    Console.WriteLine("Student or Lecture not found.");
                }
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Operation cancelled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    /// <summary>
    /// Transfers a student to a new department.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="studentNumber">The student's unique number.</param>
    /// <param name="newDepartmentCode">The code of the new department.</param>
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

    static void TransferStudent()
    {
        try
        {
            string studentNumber = GetValidInput("Enter Student Number: ", Validator.IsValidStudentNumber, "Invalid student number. Must be exactly 8 digits.");
            string newDepartmentCode = GetValidInput("Enter New Department Code: ", Validator.IsValidDepartmentCode, "Invalid department code. Must be exactly 6 characters (letters and numbers only).");

            using (var context = new StudentInfoContext())
            {
                TransferStudent(context, studentNumber, newDepartmentCode);
                Console.WriteLine("Student transferred to new department successfully.");
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Operation cancelled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    /// <summary>
    /// Displays all students in a specific department.
    /// </summary>  
    static void ViewStudentsInDepartment()
    {
        try
        {
            string departmentCode = GetValidInput("Enter Department Code: ", Validator.IsValidDepartmentCode, "Invalid department code. Must be exactly 6 characters (letters and numbers only).");

            using (var context = new StudentInfoContext())
            {
                var students = from s in context.Students
                               where s.DepartmentCode == departmentCode
                               select s;

                foreach (var student in students)
                {
                    Console.WriteLine($"Student Number: {student.StudentNumber}, Name: {student.Name} {student.Surname}");
                }
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Operation cancelled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    /// <summary>
    /// Displays all lectures in a specific department.
    /// </summary>
    static void ViewLecturesInDepartment()
    {
        try
        {
            string departmentCode = GetValidInput("Enter Department Code: ", Validator.IsValidDepartmentCode, "Invalid department code. Must be exactly 6 characters (letters and numbers only).");

            using (var context = new StudentInfoContext())
            {
                var lectures = from dl in context.DepartmentLectures
                               join l in context.Lectures on dl.LectureName equals l.Name
                               where dl.DepartmentCode == departmentCode
                               select l;

                foreach (var lecture in lectures)
                {
                    Console.WriteLine($"Name: {lecture.Name}, Time: {lecture.Time}, Day: {lecture.Day}");
                }
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Operation cancelled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    /// <summary>
    /// Displays all lectures for a specific student.
    /// </summary>
    static void ViewLecturesForStudent()
    {
        try
        {
            string studentNumber = GetValidInput("Enter Student Number: ", Validator.IsValidStudentNumber, "Invalid student number. Must be exactly 8 digits.");

            using (var context = new StudentInfoContext())
            {
                var lectures = from sl in context.StudentLectures
                               join l in context.Lectures on sl.LectureName equals l.Name
                               where sl.StudentNumber == studentNumber
                               select l;

                foreach (var lecture in lectures)
                {
                    Console.WriteLine($"Name: {lecture.Name}, Time: {lecture.Time}, Day: {lecture.Day}");
                }
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Operation cancelled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public static void AddDepartmentWithExistingLectures(StudentInfoContext context, string code, string name, List<string> lectureNames)
    {
        // Add the department
        AddDepartment(context, code, name);

        // Assign existing lectures to the department
        foreach (var lectureName in lectureNames)
        {
            var lecture = context.Lectures.Find(lectureName);
            if (lecture != null)
            {
                context.DepartmentLectures.Add(new DepartmentLecture { DepartmentCode = code, LectureName = lectureName });
            }
            else
            {
                throw new EntityNotFoundException($"Lecture '{lectureName}' not found in the database.");
            }
        }

        context.SaveChanges();
    }

    static void AddDepartmentWithExistingLectures()
    {
        try
        {
            string name = GetValidInput("Enter Department Name: ", Validator.IsValidDepartmentName, "Invalid department name. Name must be 3-100 characters long and contain only letters, numbers, and spaces.");
            string code = GetValidInput("Enter Department Code: ", Validator.IsValidDepartmentCode, "Invalid department code. Must be exactly 6 characters (letters and numbers only).");

            List<string> lectureNames = new List<string>();
            while (true)
            {
                string lectureName = GetValidInput("Enter Lecture Name (or press Enter to finish): ", Validator.IsValidLectureName, "Invalid lecture name. Name must be at least 5 characters long.");
                if (string.IsNullOrWhiteSpace(lectureName))
                    break;
                lectureNames.Add(lectureName);
            }

            using (var context = new StudentInfoContext())
            {
                AddDepartmentWithExistingLectures(context, code, name, lectureNames);
                Console.WriteLine("Department added successfully with existing lectures.");
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Operation cancelled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static string GetValidInput(string prompt, Func<string, bool> validator, string errorMessage)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (input?.ToLower() == "q")
            {
                throw new OperationCanceledException("User cancelled the operation.");
            }

            if (validator(input))
            {
                return input;
            }

            Console.WriteLine(errorMessage);
            Console.WriteLine("Press 'Q' to quit or any other key to try again.");
            if (Console.ReadKey().Key == ConsoleKey.Q)
            {
                throw new OperationCanceledException("User cancelled the operation.");
            }
            Console.WriteLine();
        }
    }
}