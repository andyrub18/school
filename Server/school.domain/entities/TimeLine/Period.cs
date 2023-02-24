namespace school.domain.entities;

public class Period
{
  public int Id { get; private set; }
  public string Title { get; set; } = string.Empty;
  public DateOnly Beginning { get; private set; }
  public DateOnly Ending { get; private set; }
  public double Percentage { get; private set; }

  ///<summary>Create a new instance of a period</summary>
  ///<param name="title">The title of the period</param>
  ///<param name="beginning">The beginning date of the school period</param>
  ///<param name="ending">The ending date of the school period</param>
  ///<param name="percentage">The percentage of the period. The coefficients we use for compute the final score</param>
  ///<returns>A new instance of period</returns>
  public Period(string title, DateOnly beginning, DateOnly ending, double percentage)
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

  ///<summary>Update the percentage of the school period</summary>
  ///<param name="percentage">The new percentage</param>
  public void SetPercentage(double percentage)
  {
    if (percentage < 0 || percentage > 1)
      throw new Exception("fournissez un coefficient qui aie du sens s'il vous plait");
    Percentage = percentage;
  }

  ///<summary>Update the beginning date of a period</summary>
  ///<param name="beginning">The new period beginning date</param>
  public void SetBeginning(DateOnly beginning)
  {
    if (Ending.CompareTo(beginning) <= 0)
      throw new Exception("La periode ne peut pas terminer avant d'avoir commence");
    Beginning = beginning;
  }

  ///<summary>Update the ending date of a period</summary>
  ///<param name="ending">The new period ending date</param>
  public void SetEnding(DateOnly ending)
  {
    if (Beginning.CompareTo(ending) >= 0)
      throw new Exception("La periode ne peut pas terminer avant d'avoir commence");
    Ending = ending;
  }
}
