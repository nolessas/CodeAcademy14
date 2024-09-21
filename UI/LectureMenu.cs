using System;
using CodeAcademy14.Services;

namespace CodeAcademy14.UI
{
    public class LectureMenu
    {
        private readonly LectureService _lectureService;

        public LectureMenu(LectureService lectureService)
        {
            _lectureService = lectureService;
        }

        public void Show()
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

        // Implement the methods for each menu option here
    }
}