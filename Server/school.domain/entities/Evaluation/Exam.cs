namespace school.domain.entities;

public class Exam
{
  public int Id { get; private set; }
  public DateOnly ExamDate { get; private set; }
  public int MaxCredit { get; private set; }
  public double Percentage { get; private set; }
  public int? Bonus { get; private set; }
  public Dictionary<Student, double> Notes { get; private set; } = new();

  ///<summary>Create a new instance of exam</summary>
  ///<param name="examDate">The date of the exam</param>
  ///<param name="maxCredit">The maximum note a student can have on the exam</param>
  ///<param name="percentage">The percentage of the exam for the period</param>
  ///<returns>A new exam</returns>
  public Exam(DateOnly examDate, int maxCredit, double percentage)
  {
    if (maxCredit <= 0)
      throw new Exception("Entrez une note maximale valide votre test");
    if (percentage < 0)
      throw new Exception("Entrez un pourcentage valide pour votre test");
    ExamDate = examDate;
    MaxCredit = maxCredit;
  }

  private Exam() { }

  ///<summary>Set a date for this particular exam</summary>
  /// <param name="examDate">The date for the exam</param>
  public void SetExamDate(DateOnly examDate)
  {
    ExamDate = examDate;
  }

  //TODO: Gerer les constantes donnees par les profs
  public void SetBonus(int bonus)
  {
    Bonus = bonus;
  }

  ///<summary>To add a note for a student after correction </summary>
  ///<param name="student">The student we add the note for</param>
  ///<param name="note">The note we assign to the student</param>
  ///<exception>Can't assign a note greater than maxCredit</exception>
  public void AddNote(Student student, double note)
  {
    if (note > MaxCredit)
      throw new Exception("L'étudiant a une note supérieur à la note maximale");
    // TODO: Gérer le cas des notes négatives après
    if (note < 0)
      note = 0;
    Notes.Add(student, note);
  }
}