namespace school.domain.entities;

public class Notes
{
  public int Id { get; private set; }
  public Student Student { get; private set; }
  public Exam Exam { get; private set; }
  public float Note { get; private set; }

  public Notes(Student student, Exam exam, float note)
  {
    if (student is null)
      throw new Exception("Veuillez preciser l'etudiant pour lequel vous entrez la note");
    if (exam is null)
      throw new Exception("La note est pour un examen specifique");
    Student = student;
    Exam = exam;
    Note = note;
  }

  public void SetNote(int note)
  {
    Note = note;
  }
}
