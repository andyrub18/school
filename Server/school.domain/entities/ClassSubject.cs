namespace school.domain.entities;

public class ClassSubject
{
  public int Id { get; private set; }
  public string Title { get; set; }

  // A way to group the class subjects. for example, Algebra and geometry: maths. Might need a class later
  public string? Category { get; set; }

}
