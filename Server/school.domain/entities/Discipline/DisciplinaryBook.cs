namespace school.domain.entities;

public class DisciplinaryBook
{
  public int Id { get; private set; }
  public Period Period { get; init; }
  public Assistant Assistant { get; init; }
  public List<DisciplinaryRecord> Records { get; private set; } = new();
  public Dictionary<Student, double> PeriodicDisciplinaryNote { get; private set; } = new();

  public DisciplinaryBook(Period period, Assistant assistant)
  {
    if (period is null)
      throw new Exception("Entrez la période du livre disciplinaire");
    if (assistant is null)
      throw new Exception("Entrez le nom de l'assistant proprietaire du livre disciplinaire");
    Period = period;
    Assistant = assistant;
  }

  private DisciplinaryBook()
  {
    if (Period is null)
      throw new Exception("Entrez la période du livre disciplinaire");
    if (Assistant is null)
      throw new Exception("Entrez le nom de l'assistant proprietaire du livre disciplinaire");
  }

  public void AddRecord(DisciplinaryRecord record)
  {
    Records.Add(record);
  }

  public void AddNote(Student student, double note)
  {
    if (note < 0 || note > 10)
      throw new Exception("Donner une note de conduite sur 10 svp");
    PeriodicDisciplinaryNote.Add(student, note);
  }
}
