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
