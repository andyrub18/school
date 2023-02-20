namespace school.domain.entities;

public class ClassRoom
{
  public int Id { get; private set; }
  public string ClassName { get; private set; } = string.Empty;
  public HashSet<ClassSubject> Subjects { get; private set; } = new();
  public HashSet<Student> Students { get; private set; } = new();

  public ClassRoom(string className)
  {
    ClassName = className;
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

  public void TransfertStudent(Student student, ClassRoom classRoom)
  {
    RemoveStudent(student);
    classRoom.AddStudent(student);
  }

  private List<SubjectEvaluation> GetEvaluationsPerPeriod(Period period)
  {
    var evaluations = new List<SubjectEvaluation>();
    Subjects.ToList().ForEach(x =>
    {
      foreach (var eval in x.Evaluations)
      {
        if (eval.Period.Equals(period))
          evaluations.Add(eval);
      }
    });
    return evaluations;
  }

  public double GetStudentScoreForPeriod(Student student, Period period)
  {
    if (!Students.Contains(student))
      throw new Exception("Votre eleve ne fait pas partie de cette classe");
    var total = Subjects.Sum(x => x.MaxCredit);
    var evaluations = GetEvaluationsPerPeriod(period);
    var somme = evaluations.Sum(x => x.GetStudentNote(student));
    return somme / total;
  }

  public double GetClassScoreForPeriod(Period period)
  {
    var evaluations = GetEvaluationsPerPeriod(period);
    var somme = evaluations.Sum(x => x.MeanForClassPerPeriod());
    return somme / Subjects.Count;
  }

  public double GetYearlyMeanForStudent(Student student, SchoolYear year)
  {
    return year.Periods.Sum(x => x.Percentage * GetStudentScoreForPeriod(student, x));
  }
}
