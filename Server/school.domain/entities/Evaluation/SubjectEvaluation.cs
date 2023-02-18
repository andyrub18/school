namespace school.domain.entities.Evaluation;

public class SubjectEvaluation
{
  public ClassSubject Subject { get; private set; }
  public List<Exam> Exams { get; private set; } = new();
  public Period Period { get; init; }

  public SubjectEvaluation(Period period, ClassSubject subject)
  {
    if (Period is null)
      throw new Exception("Preciser la periode de votre etape");
    if (subject is null)
      throw new Exception("Les evaluation pour une periode se font pour une matiere bien definie");
    Subject = subject;
    Period = period;
  }

  public void AddExam(Exam exam)
  {
    var sommeCoefficient = Exams.Sum(x => x.Percentage);
    if (sommeCoefficient + exam.Percentage > 1)
      throw new Exception("La somme des coefficients des examens pour cette periode n'est pas coherente");
    Exams.Add(exam);
  }
}
