namespace school.domain.entities;

public class Teacher
{
  public int Id { get; private set; }
  public string FirstName { get; set; }
  public string? MiddleName { get; set; }
  public string LastName { get; set; }
  public HashSet<ClassSubject> Subjects { get; private set; } = new();
}
