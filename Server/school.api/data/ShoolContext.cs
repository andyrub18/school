using Microsoft.EntityFrameworkCore;
using school.domain.entities;

namespace school.data.Context;

public class SchoolContext : DbContext
{
  public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
  {
  }

  #region Users
  public DbSet<Student>? Students { get; set; }
  public DbSet<Teacher>? Teachers { get; set; }
  public DbSet<Assistant>? Assistants { get; set; }
  #endregion

  #region Timeline
  public DbSet<SchoolYear>? SchoolYears { get; set; }
  public DbSet<Period>? Periods { get; set; }
  #endregion

  #region Infrastructure
  public DbSet<ClassRoom>? ClassRooms { get; set; }
  public DbSet<ClassSubject>? ClassSubjects { get; set; }
  public DbSet<Section>? Sections { get; set; }
  #endregion

  #region Evaluation
  public DbSet<Exam>? Exams { get; set; }
  public DbSet<SubjectEvaluation>? SubjectEvaluations { get; set; }
  #endregion

  #region Discipline
  public DbSet<DisciplinaryRecord>? DisciplinaryRecords { get; set; }
  public DbSet<DisciplinaryBook>? DisciplinaryBooks { get; set; }
  #endregion

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Student>().ToTable("Student");
    modelBuilder.Entity<Teacher>().ToTable("Teacher");
  }
}