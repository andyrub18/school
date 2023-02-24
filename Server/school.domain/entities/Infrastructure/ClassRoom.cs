namespace school.domain.entities;

public class ClassRoom
{
  public int Id { get; private set; }
  public string ClassName { get; private set; } = string.Empty;
  public int Level { get; private set; }
  public HashSet<ClassSubject> Subjects { get; private set; } = new();
  public HashSet<Student> Students { get; private set; } = new();

  ///<summary>Create a new instance of a classroom</summary>
  ///<param name="className">The name of the classroom</param>
  ///<param name="level">A number to order the classrooms</param>
  ///<returns>A new classroom</returns>
  public ClassRoom(string className, int level)
  {
    Level = level;
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

  ///<summary>Transfert a student from a classroom to another</summary>
  ///<param name="student">The student we want to transfert</param>
  ///<param name="classRoom">The class we want to transfert the student to</param>
  public void TransfertStudent(Student student, ClassRoom classRoom)
  {
    RemoveStudent(student);
    classRoom.AddStudent(student);
  }

  ///<summary>Get the evaluation for every subject in a classroom for a period</summary>
  ///<param name="period">The period of the evaluations</param>
  ///<returns>All the evaluations for the period for this classroom</returns>
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

  ///<summary>Get the percentage of a subject according to the all the subjects</summary>
  ///<param name="subject">The subject of interest we want the percentage for</param>
  ///<returns>The percentage of the subject</returns>
  public double GetSubjectPercentage(ClassSubject subject)
  {
    if (!Subjects.Contains(subject))
      throw new Exception("Cette matiere n'est pas dispensee dans cette classe");
    return subject.MaxCredit / Subjects.Sum(x => x.MaxCredit);
  }

  ///<summary>Get the percentage of all the subjects</summary>
  ///<returns>A key-value structure that associate a subject with his percentage</returns>
  public Dictionary<ClassSubject, double> GetAllSubjectsPercentage()
  {
    var subjectsPercentages = new Dictionary<ClassSubject, double>();
    foreach (var subject in Subjects)
    {
      subjectsPercentages.Add(subject, GetSubjectPercentage(subject));
    }
    return subjectsPercentages;
  }

  ///<summary>Get the student score (in percentage) for an entire period</summary>
  ///<returns>The score of the student for the period</returns>
  public double GetStudentScoreForPeriod(Student student, Period period)
  {
    if (!Students.Contains(student))
      throw new Exception("Votre eleve ne fait pas partie de cette classe");
    var total = Subjects.Sum(x => x.MaxCredit);
    var evaluations = GetEvaluationsPerPeriod(period);
    var somme = evaluations.Sum(x => x.GetStudentNote(student));
    return somme / total;
  }

  ///<summary>Get the class score (in percentage) for an entire period</summary>
  ///<returns>The score of the classroom for the period</returns>
  public double GetClassScoreForPeriod(Period period)
  {
    var evaluations = GetEvaluationsPerPeriod(period);
    var somme = evaluations.Sum(x => x.MeanForClassPerPeriod());
    return somme / Subjects.Count;
  }

  ///<summary>Get the student score (in percentage) for an entire school year</summary>
  ///<returns>The score of the student for the school year</returns>
  public double GetYearlyMeanForStudent(Student student, SchoolYear year)
  {
    return year.Periods.Sum(x => x.Percentage * GetStudentScoreForPeriod(student, x));
  }
}
