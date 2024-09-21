using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeAcademy14.Services
{
    public class DepartmentService
    {
        private readonly StudentInfoContext _context;

        public DepartmentService(StudentInfoContext context)
        {
            _context = context;
        }

        public void AddDepartment(string code, string name)
        {
            // Move the AddDepartment method implementation here
        }

        public void AddDepartmentWithExistingLectures(string code, string name, List<string> lectureNames)
        {
            // Move the AddDepartmentWithExistingLectures method implementation here
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

        public IEnumerable<Student> GetStudentsInDepartment(string departmentCode)
        {
            return _context.Students.Where(s => s.DepartmentCode == departmentCode).ToList();
        }

        public IEnumerable<Lecture> GetLecturesInDepartment(string departmentCode)
        {
            return _context.DepartmentLectures
                .Where(dl => dl.DepartmentCode == departmentCode)
                .Join(_context.Lectures,
                    dl => dl.LectureName,
                    l => l.Name,
                    (dl, l) => l)
                .ToList();
        }
    }
}