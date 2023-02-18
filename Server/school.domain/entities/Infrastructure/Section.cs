namespace school.domain.entities;

// A group of classRoom to classify them. the list of properties will be added soon
public class Section
{
  public int Id { get; private set; }
  public HashSet<ClassRoom> Classes { get; private set; } = new();

  public Section(HashSet<ClassRoom> classes)
  {
    Classes = classes;
  }

  private Section() { }

  public void AddClass(ClassRoom classRoom)
  {
    Classes.Add(classRoom);
  }

  public void RemoveClass(ClassRoom classRoom)
  {
    Classes.Remove(classRoom);
  }
}
