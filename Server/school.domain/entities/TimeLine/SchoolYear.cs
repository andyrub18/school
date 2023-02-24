namespace school.domain.entities;

public class SchoolYear
{
  public DateOnly BeginningDate { get; private set; }
  public DateOnly EndDate { get; private set; }
  public List<Period> Periods { get; private set; } = new();

  ///<summary>Create a new instance of school year</summary>
  ///<param name="beginningDate">The beginning date of the school year</param>
  ///<param name="endDate">The end date of the school year</param>
  ///<returns>A new school year object</returns>
  public SchoolYear(DateOnly beginningDate, DateOnly endDate)
  {
    if (beginningDate.CompareTo(endDate) >= 0)
      throw new Exception("Entrez des dates qui ont du sens s'il vous plait");

    BeginningDate = beginningDate;
    EndDate = endDate;
  }

  private SchoolYear() { }

  ///<summary>Add a new period in the school year</summary>
  ///<param name="period">The period we want to add</param>
  public void AddPeriod(Period period)
  {
    var totalCoefficient = Periods.Sum(x => x.Percentage);
    if (totalCoefficient + period.Percentage > 1)
      throw new Exception("La somme des coefficients est superieur a 100%, vous devriez reverifier les pourcentages de vos periodes");
    Periods.Add(period);
  }

  ///<summary>Update the beginning date of a school year</summary>
  ///<param name="beginningDate">The new date we want to begin the school year</param>
  public void SetBeginningDate(DateOnly beginningDate)
  {
    if (EndDate.CompareTo(beginningDate) <= 0)
      throw new Exception("Entrez des dates qui ont du sens s'il vous plait");
    BeginningDate = beginningDate;
  }

  ///<summary>Update the end date of a school year</summary>
  ///<param name="endDate">The new date we want to end the school year</param>
  public void SetEndDate(DateOnly endDate)
  {
    if (BeginningDate.CompareTo(endDate) >= 0)
      throw new Exception("Entrez des dates qui ont du sens s'il vous plait");
    EndDate = endDate;
  }
}
