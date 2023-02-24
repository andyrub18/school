using school.domain.entities;

namespace school.test.evaluation;

public class EvaluationTest
{
  private readonly ClassRoom classroom;
  private readonly Random random;

  // Let's build a classroom in the constructor with some students to test
  public EvaluationTest()
  {
    random = new Random();
    classroom = new ClassRoom("4AF", 4);
    // 1) let's fake our students
    for (var i = 0; i < 20; i++)
    {
      classroom.Students.Add(new Student(Faker.Name.First(), Faker.Name.Middle(), Faker.Name.Last(), new DateOnly(random.Next(2002, 2004), random.Next(1, 12), random.Next(1, 27)), "Port-au-Prince", "Andy"));
    }

    // 2) Let's fake our subjects
    classroom.AddSubject(new ClassSubject("Mathematiques 4AF", 20, classroom));
    classroom.AddSubject(new ClassSubject("Francais 4AF", 20, classroom));
    classroom.AddSubject(new ClassSubject("anglais 4AF", 10, classroom));
    classroom.AddSubject(new ClassSubject("catechese 4AF", 10, classroom));
  }

  private SubjectEvaluation createSubjectEvaluationAndAddNote(Period period, ClassSubject subject)
  {
    var evaluation = new SubjectEvaluation(period, subject);

    for (var i = 0; i < 3; i++)
    {
      evaluation.AddExam(new Exam(new DateOnly(2022, random.Next(1, 3), random.Next(1, 27)), 10, 0.3));
    }

    // 4) Let's give each students note
    foreach (var exam in evaluation.Exams)
    {
      foreach (var student in classroom.Students)
      {
        exam.AddNote(student, random.NextDouble() * exam.MaxCredit);
      }
    }

    return evaluation;
  }

  [Fact]
  public void SubjectEvaluation_SubjectMeanForPeriod_returnsdouble()
  {
    //Arrange
    // 1) Let's make a period
    var period = new Period("1er semestre", new DateOnly(2022, 1, 1), new DateOnly(2022, 3, 27), 0.3);

    // 3) Let's make an evaluation and his exams
    var evaluation = createSubjectEvaluationAndAddNote(period, classroom.Subjects.ToList()[random.Next(0, 3)]);

    //Act
    var resultStudent = evaluation.MeanForStudentPerPeriod(classroom.Students.ToList()[random.Next(1, 20)]);
    var resultClass = evaluation.MeanForClassPerPeriod();

    //Assert
    resultStudent.Should().BePositive();
    resultStudent.Should().BeLessThanOrEqualTo(1);
    resultClass.Should().BePositive();
    resultClass.Should().BeLessThanOrEqualTo(1);
  }

  [Fact]
  public void ClassRoom_GeneralMeanForPeriod_ReturnsDouble()
  {
    // Arrange
    // 1) Let's make a period
    var period = new Period("1er semestre", new DateOnly(2022, 1, 1), new DateOnly(2022, 3, 27), 0.3);

    // 2) Let's make the evaluations and their exams
    foreach (var subject in classroom.Subjects)
    {
      subject.AddEvaluation(createSubjectEvaluationAndAddNote(period, subject));
    }

    // Act
    var resultStudent = classroom.GetStudentScoreForPeriod(classroom.Students.ToList()[random.Next(1, 20)], period);
    var resultClass = classroom.GetClassScoreForPeriod(period);

    // Assert
    resultStudent.Should().BePositive();
    resultStudent.Should().BeLessThanOrEqualTo(1);
    resultClass.Should().BePositive();
    resultClass.Should().BeLessThanOrEqualTo(1);
  }

  [Fact]
  public void ClassRoom_GeneralMeanForSchoolYear_ReturnsDouble()
  {
    // Arrange

    // Act

    // Assert
  }
}
