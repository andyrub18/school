namespace school.domain.entities;

public class Exam
{
  public int Id { get; private set; }
  public DateOnly ExamDate { get; private set; }
  public int MaxCredit { get; private set; }
  public double Percentage { get; private set; }
  public int? Bonus { get; private set; }
  public Dictionary<Student, double> Notes { get; private set; } = new();

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

  public void SetExamDate(DateOnly examDate)
  {
    ExamDate = examDate;
  }

  public void SetBonus(int bonus)
  {
    Bonus = bonus;
  }

  public void AddNote(Student student, double note)
  {
    if (note > MaxCredit)
      throw new Exception("L'étudiant a une note supérieur à la limite de note, voulez vous donner un bonus?");
    // TODO: Gérer le cas des notes négatives après
    if (note < 0)
      note = 0;
    Notes.Add(student, note);
  }
}