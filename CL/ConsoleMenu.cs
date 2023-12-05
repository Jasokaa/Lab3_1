using BLL;
using DAL;
namespace CL;
public abstract class ConsoleMenu
{
    public static string commands()
    {
        System.Console.Clear();
        string commandsSTR = "To choose command write:\n" +
                          "1 - add student\n" +
                          "2 - add baker\n" +
                          "3 - add entrepreneur\n" +
                          "4 - show database\n" +
                          "5 - delete someone\n" + 
                          "6 - calculate the number and show 4th-year students born in the spring\n" +
                          "7 - delete all from database\n" +
                          "8 - entities actions\n" +
                          "EXIT - stop program\n";
        System.Console.Write(commandsSTR);
        return $"{Console.ReadLine()}";
    }

    public static int userInput(string input)
    {
        try
        {
            switch (input)
            {
                case "1":
                {
                    addStudent();
                    return 0;
                }
                case "2":
                {
                    addBaker();
                    return 0;
                }
                case "3":
                {
                    addEntrepreneur();
                    return 0;
                }
                case "4":
                {
                    showDatabase();
                    return 0;
                }
                case "5":
                {
                    deleteSomeone();
                    return 0;
                }
                case "6":
                {
                    calculate();
                    return 0;
                }
                case "7":
                {
                    deleteAll();
                    return 0;
                }
                case "8":
                {
                    actions();
                    return 0;
                }
                case "EXIT":
                {
                    return 1;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return 0;
    }

    private static void addStudent()
    {
        System.Console.Clear();
        string firstName = CheckInput.InputName("firstName");
        string lastName = CheckInput.InputName("lastName");
        int course = CheckInput.InputCourse();
        string sCard = CheckInput.InputStudentCard();
        string bDate = CheckInput.InputBirthDate();
        Student student = new Student(firstName, lastName, course, sCard, bDate);
        DBMethods.Writer(student.ToString());
    }

    private static void addBaker()
    {
        System.Console.Clear();
        string firstName = CheckInput.InputName("firstName");
        string lastName = CheckInput.InputName("lastName");
        Baker baker = new Baker(firstName, lastName);
        DBMethods.Writer(baker.ToString());
    }

    private static void addEntrepreneur()
    {
        System.Console.Clear();
        string firstName = CheckInput.InputName("firstName");
        string lastName = CheckInput.InputName("lastName");
        Entrepreneur entrepreneur = new Entrepreneur(firstName, lastName);
        DBMethods.Writer(entrepreneur.ToString());
    }

    private static void showDatabase()
    {
        System.Console.Clear();
        ActionsWithEntities.ListOfEntities(0);
        System.Console.ReadLine();
    }

    private static void deleteSomeone()
    {
        System.Console.Clear();
        ActionsWithEntities.ListOfEntities(1);
        while (true)
        {
            try
            {
                string input = Console.ReadLine();
                ActionsWithEntities.DeleteEntity(int.Parse(input));
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR! Uncorrect input.");
            }
        }
        
    }

    private static void calculate()
    {
        System.Console.Clear();
        ActionsWithEntities.SearchStudent();
        System.Console.ReadLine();
    }

    private static void deleteAll()                                                                                                                                                                                 
    {
        System.Console.Clear();
        DBMethods.Cleaner();
        Console.WriteLine("Now DB file is empty");
        System.Console.ReadLine();
    }

    private static void actions()
    {
        System.Console.Clear();
        ActionsWithEntities.ListOfEntities(2);
        while (true)
        {
            try
            {
                string input = Console.ReadLine();
                string[] info = ActionsWithEntities.RecreateFromDB(int.Parse(input));
                if (info[0] == "Student")
                {
                    Student student = new Student(info[1], info[2], int.Parse(info[3]), info[4], info[5]);
                    System.Console.WriteLine(student.Study());
                    System.Console.ReadLine();
                    break;
                }

                if (info[0] == "Baker")
                {
                    Baker baker = new Baker(info[1], info[2]);
                    System.Console.WriteLine(baker.Bake());
                    System.Console.ReadLine();
                    break;
                }

                if (info[0] == "Entrepreneur")
                {
                    Entrepreneur entrepreneur = new Entrepreneur(info[1], info[2]);
                    System.Console.WriteLine(entrepreneur.Work());
                    System.Console.ReadLine();
                    break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR! Uncorrect input.");
            }
            
        }
    }
}