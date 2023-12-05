namespace BLL;
public interface IEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public abstract class Entity:IEntity
{
    protected string firstName;
    protected string lastName;
    public string FirstName { get => firstName; set => firstName = value; }
    public string LastName { get => lastName; set => lastName = value; }
    protected Entity(string FirstNameInput, string LastNameInput)
    {
        firstName = FirstNameInput;
        lastName = LastNameInput;
    }
}

public class Student : Entity, IStudy
{
    private int course;
    private string studentCard;
    private string birthDate;

    public int Course
    {
        get => course;
        set => course = value;
    }
    public string StudentCard
    {
        get => studentCard;
        set => studentCard = value;
    }
    public string BirthDate
    {
        get => birthDate;
        set => birthDate = value;
    }

    public Student(string FirstName, string LastName, int Course, string StudentCatd, string BirthDate) : 
        base(FirstName, LastName)
    {
        course = Course;
        studentCard = StudentCatd;
        birthDate = BirthDate;
    }
    public override string ToString()
    {
        return "EntityType Student\n" + 
               "{FirstName: '" + firstName + "'\n" +
               "LastName: '" + lastName + "'\n" +
               "Course: '" + course + "'\n" +
               "StudentCard: '" + studentCard + "'\n" +
               "BirthDate: '" + birthDate + "'};\n";
    }

    public string Study()
    {
        Random rnd = new Random();
        int mark = rnd.Next(60, 100);
        return firstName + " " + lastName + " studied and got " + mark + " on test";
    }
}
public class Baker : Entity, IBake
{
    public Baker(string FirstName, string LastName):base(FirstName, LastName){}
    public override string ToString()
    {
        return "EntityType Baker\n" + 
               "{FirstName: '" + firstName + "'\n" +
               "LastName: '" + lastName + "'};\n";
    }
    public string Bake()
    {
        return firstName + " "+ lastName + " baked bread";
    }
}
public class Entrepreneur : Entity, IWork
{
    public Entrepreneur(string FirstName, string LastName):base(FirstName, LastName){}
    public override string ToString()
    {
        return "EntityType Entrepreneur\n" + 
               "{FirstName: '" + firstName + "'\n" +
               "LastName: '" + lastName + "'};\n";
    }
    public string Work()
    {
        Random rnd = new Random();
        int money = rnd.Next(1, 100);
        return firstName + " " + lastName + " earned $" + money + "000";
    }
}