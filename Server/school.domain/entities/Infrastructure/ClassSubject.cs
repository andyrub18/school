namespace school.domain.entities;

public class ClassSubject
{
  public int Id { get; private set; }
  public string Title { get; set; } = string.Empty;

  // A way to group the class subjects. for example, Algebra and geometry: maths. Might need a class later
  public string? Category { get; set; }

  public ClassSubject(string title, string category)
  {
    Title = title;
    Category = category;
  }

  private ClassSubject() { }
}
