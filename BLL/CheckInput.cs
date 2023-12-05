using System.Text.RegularExpressions;
namespace BLL;
//готово
public abstract class CheckInput
{
    public static string InputName(string info)//firstName or lastName
    {
        Regex regex = new Regex(@"^[A-Z]{1}[a-z]+$");
        System.Console.WriteLine($"Enter {info}:");
        string data = System.Console.ReadLine();
        while (!regex.IsMatch(data))
        {
            System.Console.WriteLine("ERROR! Try again to write:");
            data = System.Console.ReadLine();
        }
        return data;
    }
    public static int InputCourse()
    {
        Regex regex = new Regex(@"^[1-6]$");
        System.Console.WriteLine($"Enter the course of the student:");
        string data = System.Console.ReadLine();
        while (!regex.IsMatch(data))
        {
            System.Console.WriteLine("ERROR! Try again to write:");
            data = System.Console.ReadLine();
        }
        return int.Parse(data);
    }

    public static string InputStudentCard()
    {
        Regex regex = new Regex(@"^KB\d{8}$");
        System.Console.WriteLine($"Enter StudentCard in format (KB12345678):");
        string data = System.Console.ReadLine();
        while (!regex.IsMatch(data))
        {
            System.Console.WriteLine("ERROR! Try again to write:");
            data = System.Console.ReadLine();
        }
        return data;
    }

    public static string InputBirthDate()
    {
        Regex regexDate = new Regex(@"^(0[1-9]|1[0-9]|2[0-9]|3[0-1])$");
        System.Console.WriteLine($"Enter day of BirthDate in format (01):");
        string date = System.Console.ReadLine();
        Regex regexMonth = new Regex(@"^(0[1-9]|1[0-2])$");
        System.Console.WriteLine($"Enter month of BirthDate in format (01):");
        string month = System.Console.ReadLine();
        Regex regexYear = new Regex(@"^\d{4}$");
        System.Console.WriteLine($"Enter year of BirthDate in format (0134):");
        string year = System.Console.ReadLine();
        
        if (!regexDate.IsMatch(date) || !regexMonth.IsMatch(month) || !regexYear.IsMatch(year))
        {
            System.Console.WriteLine("ERROR! Try again to write:");
            return InputBirthDate();
        }
        else
        {
            int intDate = int.Parse(date);
            int intMonth = int.Parse(month);
            if (!((intDate == 31 && (intMonth == 01 || intMonth == 03 || intMonth == 05 || intMonth == 07 || intMonth == 08  || intMonth == 10  || intMonth == 12))
                  || (intDate == 30 && intMonth != 02) || intDate < 30))
            {
                System.Console.WriteLine("ERROR! Try again to write:");
                return InputBirthDate();
            }
            else
            {
                return date + "." + month + "." + year;
            }
        }
    }
}