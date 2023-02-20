namespace school.domain.entities;

public class Student
{
  public int Id { get; private set; }
  public string FirstName { get; set; }
  public string? MiddleName { get; set; }
  public string LastName { get; private set; }
  public DateOnly BirthDate { get; init; } // We'll think about it later if we can modify the birthdate
  public string BirthPlace { get; set; } = string.Empty; // We'll do a class for localisation after
  public DateOnly CreatedAt { get; init; }
  public string CreatedBy { get; init; } = string.Empty;
  public DateOnly ModifyAt { get; private set; }
  public string ModifyBy { get; private set; } = string.Empty;

  public Student(string firstName, string? middleName, string lastName, DateOnly birthDate, string birthPlace, string createdBy)
  {
    if (String.IsNullOrEmpty(firstName))
      throw new Exception("Vous devriez fournir le prenom de l'eleve a inscrire");
    if (String.IsNullOrEmpty(lastName))
      throw new Exception("Vous devriez fournir le nom de famille de l'eleve");
    FirstName = firstName;
    MiddleName = middleName;
    LastName = lastName;
    BirthDate = birthDate;
    BirthPlace = birthPlace;
    CreatedAt = DateOnly.FromDateTime(DateTime.Now);
    CreatedBy = createdBy;
  }

  private Student()
  {
    if (String.IsNullOrEmpty(FirstName))
      throw new Exception("Vous devriez fournir le prenom de l'eleve a inscrire");
    if (String.IsNullOrEmpty(LastName))
      throw new Exception("Vous devriez fournir le nom de famille de l'eleve");
  }
}
