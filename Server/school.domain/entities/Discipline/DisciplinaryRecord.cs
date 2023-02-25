namespace school.domain.entities.Discipline;

public class DisciplinaryRecord
{
  public int Id { get; private set; }
  public DateOnly RecordDate { get; private set; }
  public DisciplinaryRecordType Type { get; private set; }
  public string? OtherType { get; private set; }
  public string Remark { get; private set; } = string.Empty;

  public DisciplinaryRecord(DisciplinaryRecordType type, string? otherType, string remark)
  {
    if (type == DisciplinaryRecordType.Other && String.IsNullOrEmpty(otherType))
      throw new Exception("Precisez la nature de vorre record");
    RecordDate = DateOnly.FromDateTime(DateTime.Now);
    Type = type;
    OtherType = otherType;
    Remark = remark;
  }

  private DisciplinaryRecord() { }

  public void setRemark(string remark)
  {
    Remark = remark;
  }

  public void setType(DisciplinaryRecordType type)
  {
    Type = type;
  }

  public void setOtherType(string otherType)
  {
    if (Type != DisciplinaryRecordType.Other)
      throw new Exception("Vous ne pouvez pas mettre un type personnalisé");
    OtherType = otherType;
  }
}

public enum DisciplinaryRecordType
{
  Abscent,
  Late,
  LackScholarMaterial,
  Fight,
  Other
}