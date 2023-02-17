namespace school.domain.entities;

public class ClassRoom
{
  public int Id { get; private set; }
  public string ClassName { get; private set; } = string.Empty;
  public HashSet<ClassSubject> Subjects { get; private set; } = new();
  public HashSet<Student> Students { get; private set; } = new();
}
