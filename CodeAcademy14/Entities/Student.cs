using System.ComponentModel.DataAnnotations;
/// <summary>
/// Represents a student in the educational institution.
/// </summary>
public class Student
{
    [Key]
    public string StudentNumber { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string DepartmentCode { get; set; }
    public Department Department { get; set; }
}
