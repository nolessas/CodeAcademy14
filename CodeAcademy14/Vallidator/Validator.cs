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
/// <summary>
/// Provides validation methods for various entities in the system.
/// </summary>
public static class Validator
{
    /// <summary>
    /// Validates if the given name is valid.
    /// </summary>
    /// <param name="name">The name to validate.</param>
    /// <returns>True if the name is valid; otherwise, false.</returns>
    public static bool IsValidName(string name)
    {
        return !string.IsNullOrWhiteSpace(name) &&
               name.Length >= 2 &&
               name.Length <= 50 &&
               name.All(char.IsLetter);
    }

    /// <summary>
    /// Validates if the given student number is valid.
    /// </summary>
    /// <param name="studentNumber">The student number to validate.</param>
    /// <returns>True if the student number is valid; otherwise, false.</returns>
    public static bool IsValidStudentNumber(string studentNumber)
    {
        return !string.IsNullOrWhiteSpace(studentNumber) && studentNumber.Length == 8 && studentNumber.All(char.IsDigit);
    }

    /// <summary>
    /// Validates if the given email is valid.
    /// </summary>
    /// <param name="email">The email to validate.</param>
    /// <returns>True if the email is valid; otherwise, false.</returns>
    public static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email && System.Text.RegularExpressions.Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Validates if the given department name is valid.
    /// </summary>
    /// <param name="name">The department name to validate.</param>
    /// <returns>True if the department name is valid; otherwise, false.</returns>
    public static bool IsValidDepartmentName(string name)
    {
        return !string.IsNullOrWhiteSpace(name) && name.Length >= 3 && name.Length <= 100 && name.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c));
    }

    /// <summary>
    /// Validates if the given department code is valid.
    /// </summary>
    /// <param name="code">The department code to validate.</param>
    /// <returns>True if the department code is valid; otherwise, false.</returns>
    public static bool IsValidDepartmentCode(string code)
    {
        return !string.IsNullOrWhiteSpace(code) && code.Length == 6 && code.All(c => char.IsLetterOrDigit(c));
    }

    /// <summary>
    /// Validates if the given lecture name is valid.
    /// </summary>
    /// <param name="name">The lecture name to validate.</param>
    /// <returns>True if the lecture name is valid; otherwise, false.</returns>
    public static bool IsValidLectureName(string name)
    {
        return !string.IsNullOrWhiteSpace(name) && name.Length >= 5;
    }

    /// <summary>
    /// Validates if the given lecture time is valid.
    /// </summary>
    /// <param name="time">The lecture time to validate.</param>
    /// <returns>True if the lecture time is valid; otherwise, false.</returns>
    public static bool IsValidLectureTime(string time)
    {
        return TimeSpan.TryParse(time, out var parsedTime) && parsedTime >= TimeSpan.Zero && parsedTime < TimeSpan.FromHours(24);
    }

    /// <summary>
    /// Validates if the given lecture day is valid.
    /// </summary>
    /// <param name="day">The lecture day to validate.</param>
    /// <returns>True if the lecture day is valid; otherwise, false.</returns>
    public static bool IsValidLectureDay(string day)
    {
        string[] validDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
        return validDays.Contains(day);
    }

    /// <summary>
    /// Validates if the given condition is true, and throws an exception with the specified error message if it is not.
    /// </summary>
    /// <param name="validationFunc">The validation function to check.</param>
    /// <param name="errorMessage">The error message to throw if the validation fails.</param>
    /// <returns>True if the validation is successful; otherwise, false.</returns>
    public static bool IsValid(Func<bool> validationFunc, string errorMessage)
    {
        if (!validationFunc())
        {
            Console.WriteLine(errorMessage);
            return false;
        }
        return true;
    }

    /// <summary>
    /// Checks if the given lecture time overlaps with existing lectures.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="day">The day of the lecture.</param>
    /// <param name="startTime">The start time of the lecture.</param>
    /// <param name="endTime">The end time of the lecture.</param>
    /// <returns>True if there's an overlap; otherwise, false.</returns>
    public static bool IsLectureTimeOverlapping(StudentInfoContext context, string departmentCode, string day, TimeSpan startTime, TimeSpan endTime)
    {
        var departmentLectures = context.DepartmentLectures
            .Where(dl => dl.DepartmentCode == departmentCode)
            .Select(dl => dl.LectureName)
            .ToList();

        return context.Lectures.Any(l =>
            departmentLectures.Contains(l.Name) &&
            l.Day == day &&
            TimeSpan.Parse(l.Time) < endTime &&
            TimeSpan.Parse(l.Time).Add(TimeSpan.FromHours(1.5)) > startTime);
    }

    /// <summary>
    /// Validates if the given student number is unique in the database.
    /// </summary>
    public static bool IsUniqueStudentNumber(StudentInfoContext context, string studentNumber)
    {
        return !context.Students.Any(s => s.StudentNumber == studentNumber);
    }

    /// <summary>
    /// Validates if the given department code is unique in the database.
    /// </summary>
    public static bool IsUniqueDepartmentCode(StudentInfoContext context, string departmentCode)
    {
        return !context.Departments.Any(d => d.Code == departmentCode);
    }

    /// <summary>
    /// Validates if the given lecture name is unique in the database.
    /// </summary>
    public static bool IsUniqueLectureName(StudentInfoContext context, string lectureName)
    {
        return !context.Lectures.Any(l => l.Name == lectureName);
    }

    /// <summary>
    /// Validates if the given lecture time is within realistic intervals.
    /// </summary>
    public static bool IsRealisticLectureTime(string time)
    {
        if (TimeSpan.TryParse(time, out var parsedTime))
        {
            // Assuming lectures are between 8:00 AM and 10:00 PM
            return parsedTime >= TimeSpan.FromHours(8) && parsedTime <= TimeSpan.FromHours(22);
        }
        return false;
    }
}
