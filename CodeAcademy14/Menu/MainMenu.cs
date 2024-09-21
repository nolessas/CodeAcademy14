public static class MainMenu
{
    public static void Run()
    {
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
                    DepartmentMenu.Run();
                    break;
                case "2":
                    LectureMenu.Run();
                    break;
                case "3":
                    StudentMenu.Run();
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
}
