using System;
using CodeAcademy14.Services;

namespace CodeAcademy14.UI
{
    public class DepartmentMenu
    {
        private readonly DepartmentService _departmentService;

        public DepartmentMenu(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public void Show()
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

        // Implement the methods for each menu option here
    }
}