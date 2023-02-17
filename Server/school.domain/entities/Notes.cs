namespace school.domain.entities;

public class Notes
{
  public int Id { get; private set; }
  public Student Student { get; set; }
  public Exam Exam { get; set; }
  public float Note { get; set; }
}
