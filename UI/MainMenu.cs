using System;
using CodeAcademy14.Services;

namespace CodeAcademy14.UI
{
    public class MainMenu
    {
        private readonly DepartmentService _departmentService;
        private readonly LectureService _lectureService;
        private readonly StudentService _studentService;
        private readonly DepartmentMenu _departmentMenu;
        private readonly LectureMenu _lectureMenu;
        private readonly StudentMenu _studentMenu;

        public MainMenu(DepartmentService departmentService, LectureService lectureService, StudentService studentService)
        {
            _departmentService = departmentService;
            _lectureService = lectureService;
            _studentService = studentService;
            _departmentMenu = new DepartmentMenu(_departmentService);
            _lectureMenu = new LectureMenu(_lectureService);
            _studentMenu = new StudentMenu(_studentService);
        }

        public void Show()
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
                        _departmentMenu.Show();
                        break;
                    case "2":
                        _lectureMenu.Show();
                        break;
                    case "3":
                        _studentMenu.Show();
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
}