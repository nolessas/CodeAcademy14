using System;
using CodeAcademy14.Services;

namespace CodeAcademy14.UI
{
    public class StudentMenu
    {
        private readonly StudentService _studentService;

        public StudentMenu(StudentService studentService)
        {
            _studentService = studentService;
        }

        public void Show()
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

        // Implement the methods for each menu option here
    }
}