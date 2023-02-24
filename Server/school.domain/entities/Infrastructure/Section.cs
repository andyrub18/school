namespace school.domain.entities;

///<summary>
///A group of classRoom to classify them. The list of properties will be added soon
///</summary>
public class Section
{
  public int Id { get; private set; }
  public string Name { get; private set; } = string.Empty;
  public HashSet<ClassRoom> Classes { get; private set; } = new();

  ///<summary>Create a new instance of section</summary>
  ///<param name="name">The name of the section</param>
  ///<param name="classes">The classes of the section. Might add some classrooms later</param>
  ///<returns>A new instance of section</returns>
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
