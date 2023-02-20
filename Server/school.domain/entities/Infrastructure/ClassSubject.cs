namespace school.domain.entities;

public class ClassSubject
{
  public int Id { get; private set; }
  public string Title { get; set; } = string.Empty;
  public int MaxCredit { get; private set; }
  public List<SubjectEvaluation> Evaluations { get; private set; } = new();

  // We introduced a tight coupling between classSubject and classRoom. Might need to change this later on
  public ClassRoom ClassRoom { get; private set; }

  public ClassSubject(string title, int maxCredit, ClassRoom classRoom)
  {
    if (classRoom is null)
      throw new Exception("la salle de classe n'a pas ete precise");
    if (maxCredit <= 0)
      throw new Exception("non mais serieusement?");
    Title = title;
    MaxCredit = maxCredit;
    ClassRoom = classRoom;
  }

  private ClassSubject()
  {
    if (ClassRoom is null) throw new Exception("Cette matiere est pour quelle classe exactement?");
  }

  public void AddEvaluation(SubjectEvaluation evaluation)
  {
    var somme = Evaluations.Sum(x => x.Period.Percentage);
    if (evaluation.Period.Percentage + somme > 1)
      throw new Exception("vous devriez verifier les coefficients de vos periode pour cette annee");
    Evaluations.Add(evaluation);
  }
}
