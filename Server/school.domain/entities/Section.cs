namespace school.domain.entities;

// A group of classRoom to classify them. the list of properties will be added soon
public class Section
{
  public int Id { get; private set; }
  public HashSet<ClassRoom> Classes { get; private set; } = new();
}
