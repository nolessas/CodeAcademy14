using Microsoft.EntityFrameworkCore;

public class StudentInfoContext : DbContext
{
    public StudentInfoContext(DbContextOptions<StudentInfoContext> options)
        : base(options)
    {
    }

    public StudentInfoContext()
    {
    }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Lecture> Lectures { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<DepartmentLecture> DepartmentLectures { get; set; }
    public DbSet<StudentLecture> StudentLectures { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=InfoStudentSystem5;Trusted_Connection=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasKey(s => s.StudentNumber);

        modelBuilder.Entity<Department>()
            .HasKey(d => d.Code);

        modelBuilder.Entity<Lecture>()
            .HasKey(l => l.Name);

        modelBuilder.Entity<DepartmentLecture>()
            .HasKey(dl => new { dl.DepartmentCode, dl.LectureName });

        modelBuilder.Entity<StudentLecture>()
            .HasKey(sl => new { sl.StudentNumber, sl.LectureName });

        modelBuilder.Entity<StudentLecture>()
            .HasOne(sl => sl.Student)
            .WithMany()
            .HasForeignKey(sl => sl.StudentNumber);

        modelBuilder.Entity<StudentLecture>()
            .HasOne(sl => sl.Lecture)
            .WithMany()
            .HasForeignKey(sl => sl.LectureName);
    }

    public void SeedData()
    {
        SeedDepartments();
        SeedLectures();
        SeedStudents();
        SeedDepartmentLectures();
        SeedStudentLectures();
    }

    private string GetInitialDataPath(string fileName)
    {
        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "InitialData", fileName);
    }

    private void SeedDepartments()
    {
        if (!Departments.Any())
        {
            var filePath = GetInitialDataPath("departments.csv");
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath).Skip(1);
                foreach (var line in lines)
                {
                    var values = line.Split('\t');
                    Departments.Add(new Department { Code = values[0], Name = values[1] });
                }
                SaveChanges();
            }
            else
            {
                Console.WriteLine($"File not found: {filePath}");
            }
        }
    }

    private void SeedLectures()
    {
        if (!Lectures.Any())
        {
            var filePath = GetInitialDataPath("lectures.csv");
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath).Skip(1);
                foreach (var line in lines)
                {
                    var values = line.Split('\t');
                    Lectures.Add(new Lecture { Name = values[0], Time = values[1], Day = values[2] });
                }
                SaveChanges();
            }
            else
            {
                Console.WriteLine($"File not found: {filePath}");
            }
        }
    }

    private void SeedStudents()
    {
        if (!Students.Any())
        {
            var filePath = GetInitialDataPath("students.csv");
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath).Skip(1);
                foreach (var line in lines)
                {
                    var values = line.Split('\t');
                    Students.Add(new Student
                    {
                        Name = values[0],
                        Surname = values[1],
                        StudentNumber = values[2],
                        Email = values[3],
                        DepartmentCode = values[4]
                    });
                }
                SaveChanges();
            }
            else
            {
                Console.WriteLine($"File not found: {filePath}");
            }
        }
    }

    private void SeedDepartmentLectures()
    {
        if (!DepartmentLectures.Any())
        {
            var filePath = GetInitialDataPath("department_lectures.csv");
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath).Skip(1);
                foreach (var line in lines)
                {
                    var values = line.Split('\t');
                    DepartmentLectures.Add(new DepartmentLecture
                    {
                        DepartmentCode = values[0],
                        LectureName = values[1]
                    });
                }
                SaveChanges();
            }
            else
            {
                Console.WriteLine($"File not found: {filePath}");
            }
        }
    }

    private void SeedStudentLectures()
    {
        if (!StudentLectures.Any())
        {
            var filePath = GetInitialDataPath("student_lectures.csv");
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath).Skip(1);
                foreach (var line in lines)
                {
                    var values = line.Split('\t');
                    StudentLectures.Add(new StudentLecture
                    {
                        StudentNumber = values[0],
                        LectureName = values[1]
                    });
                }
                SaveChanges();
            }
            else
            {
                Console.WriteLine($"File not found: {filePath}");
            }
        }
    }
}
