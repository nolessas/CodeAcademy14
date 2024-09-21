public static class DepartmentMenu
{
    public static void Run()
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

    static void AddDepartment()
    {
        try
        {
            string name = InputValidator.GetValidInput("Enter Department Name: ", Validator.IsValidDepartmentName, "Invalid department name. Name must be 3-100 characters long and contain only letters, numbers, and spaces.");
            string code = InputValidator.GetValidInput("Enter Department Code: ", Validator.IsValidDepartmentCode, "Invalid department code. Must be exactly 6 characters (letters and numbers only).");

            using (var context = new StudentInfoContext())
            {
                Program.AddDepartment(context, code, name);
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

    static void AddDepartmentWithExistingLectures()
    {
        try
        {
            string name = InputValidator.GetValidInput("Enter Department Name: ", Validator.IsValidDepartmentName, "Invalid department name. Name must be 3-100 characters long and contain only letters, numbers, and spaces.");
            string code = InputValidator.GetValidInput("Enter Department Code: ", Validator.IsValidDepartmentCode, "Invalid department code. Must be exactly 6 characters (letters and numbers only).");

            Console.WriteLine("Enter lecture names (separated by commas) to add to the department:");
            string lecturesInput = Console.ReadLine();
            List<string> lectureNames = lecturesInput.Split(',').Select(s => s.Trim()).ToList();

            using (var context = new StudentInfoContext())
            {
                Program.AddDepartmentWithExistingLectures(context, code, name, lectureNames);
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

    static void ViewStudentsInDepartment()
    {
        try
        {
            string departmentCode = InputValidator.GetValidInput("Enter Department Code: ", Validator.IsValidDepartmentCode, "Invalid department code. Must be exactly 6 characters (letters and numbers only).");

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

    static void ViewLecturesInDepartment()
    {
        try
        {
            string departmentCode = InputValidator.GetValidInput("Enter Department Code: ", Validator.IsValidDepartmentCode, "Invalid department code. Must be exactly 6 characters (letters and numbers only).");

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
}
