namespace school.domain.entities;

public class Exam
{
  public int Id { get; private set; }
  public DateOnly ExamDate { get; private set; }
  public float Percentage { get; private set; }

  public Exam(DateOnly examDate, float percentage)
  {
    if (percentage == 0)
      throw new Exception("Entrez le pourcentage de votre controle pour la période en cours");
    ExamDate = examDate;
    Percentage = percentage;
  }

  private Exam() { }

  public void SetExamDate(DateOnly examDate)
  {
    ExamDate = examDate;
  }

  public void SetPercentage(float percentage)
  {
    if (percentage > 1 || percentage < 0)
      throw new Exception("Veuillez rentrer un pourcentage valide");

    Percentage = percentage;
  }
}