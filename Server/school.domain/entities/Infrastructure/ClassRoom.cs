namespace school.domain.entities;

public class ClassRoom
{
  public int Id { get; private set; }
  public string ClassName { get; private set; } = string.Empty;
  public HashSet<ClassSubject> Subjects { get; private set; } = new();
  public HashSet<Student> Students { get; private set; } = new();

  public ClassRoom(string className, HashSet<ClassSubject> subjects)
  {
    ClassName = className;
    Subjects = subjects;
  }

  private ClassRoom() { }

  public void AddSubject(ClassSubject subject)
  {
    Subjects.Add(subject);
  }

  public void RemoveSubject(ClassSubject subject)
  {
    Subjects.Add(subject);
  }

  public void AddStudent(Student student)
  {
    // TODO: Add logic to add a student
    Students.Add(student);
  }

  public void RemoveStudent(Student student)
  {
    // TODO: Add logic to remove a student
    Students.Remove(student);
  }
}
