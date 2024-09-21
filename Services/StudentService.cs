using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeAcademy14.Services
{
    public class StudentService
    {
        private readonly StudentInfoContext _context;

        public StudentService(StudentInfoContext context)
        {
            _context = context;
        }

        public void AddStudent(string name, string surname, string studentNumber, string email, string departmentCode)
        {
            // Move the AddStudent method implementation here
        }

        public void AssignLectureToStudent(string studentNumber, string lectureName)
        {
            // Move the AssignLectureToStudent method implementation here
        }

        public void TransferStudent(string studentNumber, string newDepartmentCode)
        {
            // Move the TransferStudent method implementation here
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public IEnumerable<Lecture> GetLecturesForStudent(string studentNumber)
        {
            return _context.StudentLectures
                .Where(sl => sl.StudentNumber == studentNumber)
                .Join(_context.Lectures,
                    sl => sl.LectureName,
                    l => l.Name,
                    (sl, l) => l)
                .ToList();
        }
    }
}