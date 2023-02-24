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
  }

  [Fact]
  public void SubjectEvaluation_SubjectMeanForPeriod_returnsdouble()
  {
    //Arrange
    // 1) Let's create our exams and add note for each student
    var exams = new List<Exam>()
    {
      new Exam(new DateOnly(2022, random.Next(1, 3), random.Next(1, 27)), 10, 0.3),
      new Exam(new DateOnly(2022, random.Next(1, 3), random.Next(1, 27)), 10, 0.3),
      new Exam(new DateOnly(2022, random.Next(1, 3), random.Next(1, 27)), 10, 0.4)
    };

    // 2) Let's give each students note
    foreach (var exam in exams)
    {
      foreach (var student in classroom.Students)
      {
        exam.AddNote(student, random.NextDouble() * exam.MaxCredit);
      }
    }

    // 3) Let's make a classSubject
    var subject = new ClassSubject("Mathematiques 4AF", 20, classroom);

    // 4) Let's make a period
    var period = new Period("1er semestre", new DateOnly(2022, 1, 1), new DateOnly(2022, 3, 27), 0.3);

    // 5) Let's make the evaluation
    var evaluation = new SubjectEvaluation(period, subject);
    foreach (var exam in exams)
    {
      evaluation.AddExam(exam);
    }

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

    // Act

    // Assert
  }

  [Fact]
  public void ClassRoom_GeneralMeanForSchoolYear_ReturnsDouble()
  {
    // Arrange

    // Act

    // Assert
  }
}
