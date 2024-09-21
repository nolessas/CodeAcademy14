using System.ComponentModel.DataAnnotations.Schema;

public class StudentLecture
{
    public string StudentNumber { get; set; }
    [ForeignKey("StudentNumber")]
    public Student Student { get; set; }

    public string LectureName { get; set; }
    [ForeignKey("LectureName")]
    public Lecture Lecture { get; set; }
}
