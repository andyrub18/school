namespace school.domain.entities;

// A group of classRoom to classify them. the list of properties will be added soon
public class Section
{
  public int Id { get; private set; }
  public string Name { get; private set; } = string.Empty;
  public HashSet<ClassRoom> Classes { get; private set; } = new();

  public Section(string name, HashSet<ClassRoom> classes)
  {
    Name = name;
    Classes = classes;
  }

  private Section() { }

  public void SetName(string name)
  {
    Name = name;
  }

  public void AddClass(ClassRoom classRoom)
  {
    Classes.Add(classRoom);
  }

  public void RemoveClass(ClassRoom classRoom)
  {
    Classes.Remove(classRoom);
  }
}
