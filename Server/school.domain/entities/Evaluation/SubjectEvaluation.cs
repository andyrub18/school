namespace school.domain.entities;

public class SubjectEvaluation
{
  public ClassSubject Subject { get; private set; }
  public List<Exam> Exams { get; private set; } = new();
  public Period Period { get; init; }

  ///<summary>Create a new instance of period evaluation for a subject</summary>
  ///<param name="period">The period of the evaluations</param>
  ///<param name="subject">The subject we will have evaluations for</param>
  ///<returns>A new period evaluation</returns>
  public SubjectEvaluation(Period period, ClassSubject subject)
  {
    if (period is null)
      throw new Exception("Preciser la periode de vos tests");
    if (subject is null)
      throw new Exception("Les evaluation pour une periode se font pour une matiere bien definie");
    Subject = subject;
    Period = period;
  }

  private SubjectEvaluation()
  {
    if (Period is null)
      throw new Exception("Preciser la periode de vos tests");
    if (Subject is null)
      throw new Exception("Les evaluation pour une periode se font pour une matiere bien definie");
  }

  ///<summary>Add an exam for this period evaluation</summary>
  ///<param name="exam">The exam we want to add for the period</param>
  ///<exception>The total percentage mustn't be greater than 100% when you add exams</exception>
  public void AddExam(Exam exam)
  {
    if (Exams.Sum(x => x.Percentage) + exam.Percentage > 1)
      throw new Exception("La somme des pourcentages a deja depasse 100%. Reverifiez les pourcentages de vos examens");
    Exams.Add(exam);
  }

  /// <summary>Compute the mean for a student on a period for a class subject</summary>
  /// <param name="student">The student we want to compute the mean for</param>
  /// <returns>The mean percentage of the max credit</returns>
  public double MeanForStudentPerPeriod(Student student)
  {
    if (!Subject.ClassRoom.Students.Contains(student))
      throw new Exception("Cet étudiant n'est pas dans la classe qui offre cette matiere");
    List<double> notes = new();
    Exams.ForEach(x =>
    {
      foreach (KeyValuePair<Student, double> kvp in x.Notes)
      {
        if (kvp.Key.Equals(student))
        {
          notes.Add(kvp.Value * (100 / x.MaxCredit) * x.Percentage);
        }
      }
    });

    return notes.Sum(x => x / 100);
  }

  /// <summary>Compute the mean for an entire class on a period for a class subject</summary>
  /// <returns>The mean (in percentage) for the class for the period for this subject</returns>
  public double MeanForClassPerPeriod()
  {
    var students = Subject.ClassRoom.Students;
    var nbrStudents = students.Count;
    var sommeNotes = students.Sum(x => MeanForStudentPerPeriod(x));
    return sommeNotes / nbrStudents;
  }

  /// <summary>Compute the note for a student on a period for a class subject</summary>
  /// <param name="student">The student we want to compute the mean for</param>
  /// <returns>The student note for the period for this subject</returns>
  public double GetStudentNote(Student student)
  {
    if (!Subject.ClassRoom.Students.Contains(student))
      throw new Exception("Cet étudiant n'est pas dans la classe qui offre cette matiere");
    return Subject.MaxCredit * MeanForStudentPerPeriod(student);
  }
}
