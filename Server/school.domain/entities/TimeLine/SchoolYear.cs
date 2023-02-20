namespace school.domain.entities;

public class SchoolYear
{
  public DateOnly BeginningDate { get; private set; }
  public DateOnly EndDate { get; private set; }
  public List<Period> Periods { get; private set; } = new();

  public SchoolYear(DateOnly beginningDate, DateOnly endDate)
  {
    if (beginningDate.CompareTo(endDate) >= 0)
      throw new Exception("Entrez des dates qui ont du sens s'il vous plait");

    BeginningDate = beginningDate;
    EndDate = endDate;
  }

  private SchoolYear() { }

  public void AddPeriod(Period period)
  {
    var totalCoefficient = Periods.Sum(x => x.Percentage);
    if (totalCoefficient + period.Percentage > 1)
      throw new Exception("La somme des coefficients est superieur a 100%, vous devriez reverifier les pourcentages de vos periodes");
    Periods.Add(period);
  }

  public void SetEndDate(DateOnly endDate)
  {
    if (BeginningDate.CompareTo(endDate) >= 0)
      throw new Exception("Entrez des dates qui ont du sens s'il vous plait");
    EndDate = endDate;
  }
}
