// this is my training work i want you create a plan of c# entity console app this is the guildines of the project :
/*

Here's a comprehensive summary of the student information system project based on all three images:
Project Overview: Student Information System
Entities:
1. Department: Has many students and many lectures.
Lecture: Belongs to many departments.
Student: Has many lectures, belongs to one department.
Functionalities:
Create a department and add students and lectures to it.
Add students/lectures to an existing department.
3. Create a lecture and assign it to a department.
Create a student, add them to an existing department, and assign existing lectures.
Transfer a student to another department.
Display all students in a department.
7. Display all lectures in a department.
Display all lectures for a specific student.
Data Validation:
Student name and surname: only letters, 2-50 characters.
Student number: unique, only numbers, exactly 8 characters.
Student email: must be in correct format.
Department name: 3-100 characters, can include letters and numbers.
Department code: unique, only letters and numbers, exactly 6 characters.
Lecture name: unique, at least 5 characters.
Lecture time: must match realistic time intervals.
Validation should be performed before entering data into the database.
Create at least 3 additional custom validations.
Grading Criteria (Total: 100 points + up to 10 bonus points):
Code Quality (30 points)
Clarity and Readability (10 points)
C# Coding Guidelines (10 points)
Error Handling (10 points)
2. Database Design and Integration (30 points)
Schema Design (10 points)
Data Management (10 points)
Database Connection (10 points)
Functionality (30 points)
Core Requirements (15 points)
Additional Features (10 points)
Error-Free Execution (5 points)
4. User Interface (10 points)
User-Friendly (5 points)
Navigation (5 points)
Additional Tasks (up to 10 bonus points)
Validator Tests (5 points)
Documentation (5 points)
Key Focus Areas:
Code organization, readability, and adherence to C# guidelines
Proper database design and integration
Implementation of core and additional functionalities
Robust error handling and data validation
User-friendly interface design and logical navigation
Comprehensive testing and documentation
Additional Notes:
Bonus points for adding lectures from an existing database when creating a department
Bonus points for changing a student's lectures when transferring to a new department
Emphasis on creating a well-structured, efficient, and user-friendly system that accurately manages the relationships between departments, lectures, and students in an educational setting.





Kai įrašomi departamentų duomenys iš departments.csv
- Sukurti du departamentai su kodais CS1234 ir MTH567
- Departamentų pavadinimai turi būti ComputerScience ir Mathematics
Kai įrašomi paskaitų duomenys iš lectures.csv, duomenys turi būti
- Sukurtos trys paskaitos: Algorithms, Calculus, DataStructures.
- Paskaitų laikai turi būti 10:00, 12:00, 14:00
Kai įrašomi studentų duomenys iš students.csv, duomenys turi būti:
- Sukurti du studentai: John Smith ir Alice Johnson.
Kai įrašomi departamentų ir paskaitų asociacijų duomenys iš department_lectures.csv, duomenys turi būti:
- Departamentas CS1234 turi būti susietas su paskaitomis Algorithms ir DataStructures.
- Departamentas MTH567 turi būti susietas su paskaitomis Calculus.
Kai įrašomi studentų ir paskaitų asociacijų duomenys iš student_lectures.csv, duomenys turi būti:
- Studentas 12345678 (John Smith) turi būti užregistruotas į paskaitas Algorithms ir DataStructures.
- Studentas 87654321 (Alice Johnson) turi būti užregistruotas į paskaitą Calculus.
 
Validaciju testai:
- Jei paduodami studento vardas "Jo1n" ir pavardė "Smith", tai gaunama klaida, nes vardas turi būti sudarytas tik iš raidžių.
- Jei paduodami studento vardas "J" ir pavardė "Smith", tai gaunama klaida, nes vardas turi būti ne trumpesnis kaip 2 simboliai.
- Jei paduodami studento vardas "JohnathonJohnathonJohnathonJohnathonJohnathon" (51 simbolis) ir pavardė "Smith", tai gaunama klaida, nes vardas turi būti ne ilgesnis kaip 50 simbolių.
- Jei paduodami studento vardas "John" ir pavardė "Sm!th", tai gaunama klaida, nes pavardė turi būti sudaryta tik iš raidžių.
- Jei paduodami studento numeris "1234567" (7 skaitmenys), tai gaunama klaida, nes numeris turi būti tiksliai 8 simbolių ilgio.
- Jei paduodami studento numeris "123456789" (9 skaitmenys), tai gaunama klaida, nes numeris turi būti tiksliai 8 simbolių ilgio.
- Jei paduodami studento numeris "1234ABCD", tai gaunama klaida, nes numeris turi būti sudarytas tik iš skaičių.
- Jei paduodami studento numeris "12345678", kuris jau egzistuoja duomenų bazėje, tai gaunama klaida dėl numerio unikalumo pažeidimo.
- Jei paduodami studento numeris "ABC" (3 simboliai), tai gaunama 2 klaidos, (1)numeris turi būti tiksliai 8 simbolių ilgio,  (2)numeris turi būti sudarytas tik iš skaičių.
- Jei paduodami studento el. paštas "john.smithexample.com" (trūksta @), tai gaunama klaida, nes el. paštas turi būti teisingo formato.
- Jei paduodami studento el. paštas "john.smith@" (trūksta domeno), tai gaunama klaida dėl netinkamo formato.
- Jei paduodami studento el. paštas "@example.com" (trūksta vietovardžio), tai gaunama klaida dėl netinkamo formato.
- Jei paduodami studento el. paštas "john.smith@example" (trūksta domeno pabaigos), tai gaunama klaida dėl netinkamo formato.
- Jei paduodami studento el. paštas "john.smith@example." (trūksta domeno pabaigos), tai gaunama klaida dėl netinkamo formato.
- Jei nepaduodamas studento el. paštas, tai gaunama klaida, nes el. paštas yra privalomas.
- Jei nepaduodamas studento Departamentas, tai gaunama klaida, nes Departamentas yra privalomas.
- Jei paduodami studento vardas tuščias """ arba null, tai gaunama klaida, nes vardas yra privalomas laukas.
- Jei paduodami paskaitos pavadinimas tuščias """ arba null, tai gaunama klaida, nes pavadinimas yra privalomas laukas.
- Jei paduodami du studentai su tuo pačiu el. pašto adresu "alice.johnson@example.com", tai gaunama klaida dėl el. pašto unikalumo pažeidimo.
 
- Jei paduodami departamento pavadinimas "CS" (2 simboliai), tai gaunama klaida, nes pavadinimas turi būti ne trumpesnis kaip 3 simboliai.
- Jei paduodami departamento pavadinimas "Computer Science & Engineering" (su specialiaisiais simboliais), tai gaunama klaida, nes pavadinime gali būti tik raidės ir skaičiai.
- Jei paduodami departamento kodas "CS12" (4 simboliai), tai gaunama klaida, nes kodas turi būti tiksliai 6 simbolių ilgio.
- Jei paduodami departamento kodas "CS123@", tai gaunama klaida, nes kode gali būti tik raidės ir skaičiai.
- Jei paduodami departamento kodas "CS1234" kuris jau egzistuoja duomenų bazėje, tai gaunama klaida dėl kodo unikalumo pažeidimo.
- Jei sukuriama paskaita su pavadinimu "DataStructures" ir priskiriama departamentui su kodu "MTH567", tai gaunama sėkmingas pridėjimas.
- Jei sukuriama paskaita su pavadinimu "DataStructures" ir priskiriama departamentui su kodu "CS1234", tai gaunama klaida dėl to kad tokia paskaita departamente jau yra.
 
- Jei paduodami paskaitos pavadinimas "Math" (4 simboliai), tai gaunama klaida, nes pavadinimas turi būti ne trumpesnis kaip 5 simboliai.
 
- Jei paduodami paskaitos laikas "25:00-26:30", tai gaunama klaida, nes pradžios ir pabaigos laikas turi būti tarp 00:00 ir 24:00.
- Jei paduodami paskaitos laikas "14:00-13:00", tai gaunama klaida, nes pabaigos laikas negali būti ankstesnis už pradžios laiką.
- Jei paduodami dvi paskaitos tame pačiame departamente su laikais "10:00-11:30" ir "11:00-12:30", tai gaunama įspėjimas arba klaida dėl laiko persidengimo.
- Jei paduodama paskaitos savaitės diena "Sunday", tai gaunama klaida, nes savaitės diena gali būti tik Monday, Tuesday, Wednesday, Thursday, Friday.
- Jei paskaitos savaitės diena yra null, tuomet paskaitos skaitomos kasdien nuo Monday iki Friday.
 
- Jei paduodami studentas su numeriu "12345679" priskiriamas departamentui su kodu "ENG999", kuris neegzistuoja, tai gaunama klaida dėl neegzistuojančio departamento.
- Jei paduodami studentas iš departamento "CS1234" priskiriamas paskaitai "Calculus", kuri nepriklauso jo departamentui, tai gaunama klaida.
 
- Jei paduodami studentas su numeriu "12345678" perkeliamas į departamentą su kodu "MTH567", tai gaunama sėkmingas perkėlimas, o jo paskaitos atnaujinamos pagal naują departamentą (jei toks funkcionalumas numatytas).
- Jei paduodami studentas su numeriu "12345678" perkeliamas į neegzistuojantį departamentą "ENG999", tai gaunama klaida dėl neegzistuojančio departamento.
*/

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
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=InfoStudentSystem3;Trusted_Connection=True;");
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
