public class StudentService
{
    private readonly StudentInfoContext _context;

    public StudentService(StudentInfoContext context)
    {
        _context = context;
    }

    public bool TransferStudent(string studentNumber, string newDepartmentCode)
    {
        var student = _context.Students.FirstOrDefault(s => s.StudentNumber == studentNumber);
        var newDepartment = _context.Departments.FirstOrDefault(d => d.Code == newDepartmentCode);

        if (student == null || newDepartment == null)
        {
            return false;
        }

        student.DepartmentCode = newDepartmentCode;
        _context.SaveChanges();
        return true;
    }

    public List<Student> GetStudentsInDepartment(string departmentCode)
    {
        return _context.Students.Where(s => s.DepartmentCode == departmentCode).ToList();
    }

    public List<Lecture> GetLecturesInDepartment(string departmentCode)
    {
        return _context.DepartmentLectures
            .Where(dl => dl.DepartmentCode == departmentCode)
            .Select(dl => dl.Lecture)
            .ToList();
    }

    public List<Lecture> GetLecturesForStudent(string studentNumber)
    {
        return _context.StudentLectures
            .Where(sl => sl.StudentNumber == studentNumber)
            .Select(sl => sl.Lecture)
            .ToList();
    }
}
