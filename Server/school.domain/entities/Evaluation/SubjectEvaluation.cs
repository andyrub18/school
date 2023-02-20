namespace school.domain.entities;

public class SubjectEvaluation
{
  public ClassSubject Subject { get; private set; }
  public List<Exam> Exams { get; private set; } = new();
  public Period Period { get; init; }

  public SubjectEvaluation(Period period, ClassSubject subject)
  {
    if (Period is null)
      throw new Exception("Preciser la periode de vos tests");
    if (subject is null)
      throw new Exception("Les evaluation pour une periode se font pour une matiere bien definie");
    Subject = subject;
    Period = period;
  }

  public void AddExam(Exam exam)
  {
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

    return notes.Sum(x => x);
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
