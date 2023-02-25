namespace school.domain.entities.Users;

public class Assistant
{
  public int Id { get; private set; }
  public string FirstName { get; set; }
  public string? Middlename { get; set; }
  public string LastName { get; set; }
  public DateOnly BirthDate { get; init; } // We'll think about it later if we can modify the birthdate
  public string BirthPlace { get; set; } = string.Empty; // We'll do a class for localisation after
  public DateOnly EmploymentDate { get; private set; }

  public Assistant(string firstName, string? middleName, string lastName, DateOnly birthDate, string birthPlace)
  {
    if (String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName))
      throw new Exception("Vous devriez rentrer le nom complet de l'assistant");
    FirstName = firstName;
    Middlename = middleName;
    LastName = lastName;
    BirthDate = birthDate;
    EmploymentDate = DateOnly.FromDateTime(DateTime.Now);
  }

  private Assistant()
  {
    if (String.IsNullOrEmpty(FirstName) || String.IsNullOrEmpty(LastName))
      throw new Exception("Vous devriez rentrer le nom complet de l'assistant");
  }
}
