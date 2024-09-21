public static class LectureMenu
{
    public static void Run()
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

    static void AddLecture()
    {
        try
        {
            string name = InputValidator.GetValidInput("Enter Lecture Name: ", Validator.IsValidLectureName, "Invalid lecture name. Name must be at least 5 characters long.");
            string time = InputValidator.GetValidInput("Enter Lecture Time (HH:MM): ", Validator.IsValidLectureTime, "Invalid lecture time. Time must be in HH:MM format and between 00:00 and 23:59.");
            string day = InputValidator.GetValidInput("Enter Lecture Day (Monday, Tuesday, Wednesday, Thursday, Friday): ", Validator.IsValidLectureDay, "Invalid lecture day. Day must be Monday, Tuesday, Wednesday, Thursday, or Friday.");

            using (var context = new StudentInfoContext())
            {
                Program.AddLecture(context, name, time, day);
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

    static void AssignLectureToDepartment()
    {
        try
        {
            string lectureName = InputValidator.GetValidInput("Enter Lecture Name: ", Validator.IsValidLectureName, "Invalid lecture name. Name must be at least 5 characters long.");
            string departmentCode = InputValidator.GetValidInput("Enter Department Code: ", Validator.IsValidDepartmentCode, "Invalid department code. Must be exactly 6 characters (letters and numbers only).");

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
}
