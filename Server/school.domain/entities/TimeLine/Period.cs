namespace school.domain.entities;

public class Period
{
  public int Id { get; private set; }
  public string Title { get; set; } = string.Empty;
  public DateOnly Beginning { get; private set; }
  public DateOnly Ending { get; private set; }
  public float Percentage { get; private set; }

  public Period(string title, DateOnly beginning, DateOnly ending, float percentage)
  {
    if (percentage < 0 || percentage > 1)
      throw new Exception("Fournissez un coefficient qui aie du sens s'il vous plait");
    if (beginning.CompareTo(ending) >= 0)
      throw new Exception("La periode ne peut pas terminer avant d'avoir commence");
    Title = title;
    Beginning = beginning;
    Ending = ending;
    Percentage = percentage;
  }

  private Period() { }

  public void SetPercentage(float percentage)
  {
    if (percentage < 0 || percentage > 1)
      throw new Exception("fournissez un coefficient qui aie du sens s'il vous plait");
    Percentage = percentage;
  }

  public void SetEnding(DateOnly ending)
  {
    if (Beginning.CompareTo(ending) >= 0)
      throw new Exception("La periode ne peut pas terminer avant d'avoir commence");
    Ending = ending;
  }
}
