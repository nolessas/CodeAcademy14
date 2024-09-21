using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeAcademy14.Services
{
    public class LectureService
    {
        private readonly StudentInfoContext _context;

        public LectureService(StudentInfoContext context)
        {
            _context = context;
        }

        public void AddLecture(string name, string time, string day)
        {
            // Move the AddLecture method implementation here
        }

        public void AssignLectureToDepartment(string lectureName, string departmentCode)
        {
            // Move the AssignLectureToDepartment method implementation here
        }

        public IEnumerable<Lecture> GetAllLectures()
        {
            return _context.Lectures.ToList();
        }
    }
}