public static class StudentMenu
{
    public static void Run()
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

    static void AddStudent()
    {
        try
        {
            string name = InputValidator.GetValidInput("Enter Student Name: ", Validator.IsValidName, "Invalid name. Name must be 2-50 characters long and contain only letters.");
            string surname = InputValidator.GetValidInput("Enter Student Surname: ", Validator.IsValidName, "Invalid surname. Surname must be 2-50 characters long and contain only letters.");
            string studentNumber = InputValidator.GetValidInput("Enter Student Number: ", Validator.IsValidStudentNumber, "Invalid student number. Must be exactly 8 digits.");
            string email = InputValidator.GetValidInput("Enter Student Email: ", Validator.IsValidEmail, "Invalid email address.");
            string departmentCode = InputValidator.GetValidInput("Enter Department Code: ", Validator.IsValidDepartmentCode, "Invalid department code. Must be exactly 6 characters (letters and numbers only).");

            using (var context = new StudentInfoContext())
            {
                Program.AddStudent(context, name, surname, studentNumber, email, departmentCode);
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

    static void AssignLectureToStudent()
    {
        try
        {
            string studentNumber = InputValidator.GetValidInput("Enter Student Number: ", Validator.IsValidStudentNumber, "Invalid student number. Must be exactly 8 digits.");
            string lectureName = InputValidator.GetValidInput("Enter Lecture Name: ", Validator.IsValidLectureName, "Invalid lecture name. Name must be at least 5 characters long.");

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

    static void TransferStudent()
    {
        try
        {
            string studentNumber = InputValidator.GetValidInput("Enter Student Number: ", Validator.IsValidStudentNumber, "Invalid student number. Must be exactly 8 digits.");
            string newDepartmentCode = InputValidator.GetValidInput("Enter New Department Code: ", Validator.IsValidDepartmentCode, "Invalid department code. Must be exactly 6 characters (letters and numbers only).");

            using (var context = new StudentInfoContext())
            {
                Program.TransferStudent(context, studentNumber, newDepartmentCode);
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

    static void ViewLecturesForStudent()
    {
        try
        {
            string studentNumber = InputValidator.GetValidInput("Enter Student Number: ", Validator.IsValidStudentNumber, "Invalid student number. Must be exactly 8 digits.");

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
}
