namespace school.domain.entities;

public class Teacher
{
  public int Id { get; private set; }
  public string FirstName { get; set; }
  public string? MiddleName { get; set; }
  public string LastName { get; set; }
  public List<string> Qualifications { get; private set; }
  public HashSet<ClassSubject> Subjects { get; private set; } = new();

  ///<summary>Create a new teacher instance</summary>
  ///<param name="qualifications">A list of the qualifications of the teacher</param>
  ///<returns>A new teacher object</returns>
  public Teacher(string firstName, string? middleName, string lastName, List<string> qualifications)
  {
    if (String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName))
      throw new Exception("Tu dois fournir le nom complet du professeur");
    if (qualifications.Count == 0)
      throw new Exception("votre prof doit avoir au moins une qualifications");
    FirstName = firstName;
    MiddleName = middleName;
    LastName = lastName;
    Qualifications = qualifications;
  }

  private Teacher()
  {
    if (String.IsNullOrEmpty(FirstName) || String.IsNullOrEmpty(LastName))
      throw new Exception("Ce professeur n'a pas de nom complet");
    if (Qualifications is null || Qualifications.Count == 0)
      throw new Exception("Ce prof n'a pas de qualifications enregistres");
  }

  public void AddQualifications(string qualification)
  {
    Qualifications.Add(qualification);
  }

  public void AddClassSubject(ClassSubject subject)
  {
    Subjects.Add(subject);
  }

  public void RemoveClassSubject(ClassSubject subject)
  {
    Subjects.Remove(subject);
  }
}
