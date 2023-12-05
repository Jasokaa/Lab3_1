using DAL;
using System.Text.RegularExpressions;
namespace BLL;

public abstract class ActionsWithEntities
{
    public static void ListOfEntities(int number)
    {
        string entity = DBMethods.ReaderOfAllFile();
        string[] entities = entity.Split(";\n");
        for (int i = 0; i < entities.Length - 1; i++)
        {
            if (number == 1)
            {
                Console.WriteLine("ENTER " + i + " to delete this entity:");
            }
            if (number == 2)
            {
                Console.WriteLine("ENTER " + i + " to watch actions of this entity:");
            }
            Console.WriteLine(entities[i] + ";");
        }
    }

    public static int GetSizeOfList()
    {
        string entity = DBMethods.ReaderOfAllFile();
        string[] entities = entity.Split(";\n");
        return entities.Length - 1;
    }

    public static void DeleteEntity(int index)
    {
        if (index > GetSizeOfList() - 1)
        {
            throw new Exception("Index out of range!");
        }
        try
        {
            string entity = DBMethods.ReaderOfAllFile();
            string[] entities = entity.Split(";\n");
            int sizeOfList = entities.Length - 2;
            string[] newList = new string[sizeOfList];
            for (int i = 0; i < entities.Length - 1; i++)
            {
                if (i < index)
                {
                    newList[i] = entities[i];
                }
    
                if (i > index)
                {
                    newList[i - 1] = entities[i];
                }
            }
            DBMethods.Cleaner();
            for (int i = 0; i < newList.Length; i++)
            {
                string text = newList[i] + ";\n";
                DBMethods.Writer(text);
            }
            Console.WriteLine("Entity with index " + index + " deleted.");
            Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Index out of range!");
        }
    }

    public static void SearchStudent()//Calculate the number of 4th-year students born in the spring.
    {
        string entity = DBMethods.ReaderOfAllFile();
        string[] entities = entity.Split(";\n");
        int number = 0;

        Regex regex1 = new Regex("EntityType Student");
        Regex regex2 = new Regex("Course: '4");
        Regex regex3 = new Regex(@"\d{2}\.03|04|05");
        
        System.Console.WriteLine("List of 4th-year students born in the spring:");
        for (int i = 0; i < entities.Length - 1; i++)
        {
            if (regex1.IsMatch(entities[i]) && regex2.IsMatch(entities[i]) && regex3.IsMatch(entities[i]))
            {
                System.Console.WriteLine(entities[i] + ";");
                number += 1;
            }
        }
        System.Console.WriteLine("4th-year students born in the spring: " + number);
    }

    public static string[] RecreateFromDB(int index)
    {
        if (index > GetSizeOfList() - 1)
        {
            throw new Exception("Index out of range!");
        }
        string entity = DBMethods.ReaderOfAllFile();
        string[] entities = entity.Split(";\n");
        string[] elements = entities[index].Split("\n");
        string[] classRow = elements[0].Split(" ");
        string[] firstNameRow = elements[1].Split("'");
        string[] lastNameRow = elements[2].Split("'");
        string[] array = {classRow[1], firstNameRow[1], lastNameRow[1] };
        if (classRow[1] == "Student")
        {
            string[] courseNameRow = elements[3].Split("'");
            string[] studentCardRow = elements[4].Split("'");
            string[] birthDateRow = elements[5].Split("'");
            string[] arrayS = {classRow[1], firstNameRow[1], lastNameRow[1],  courseNameRow[1], studentCardRow[1], birthDateRow[1]};
            return arrayS;
        }
        else
        {
            return array;
        }

    }
}