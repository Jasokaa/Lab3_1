namespace DAL;

public abstract class DBMethods
{
    private static readonly string FileStreamPath = "D:/NAU/OOP/Lab.3.1/DB.txt";
    public static string ReaderOfAllFile()
    {
        using (StreamReader file = new StreamReader(FileStreamPath, System.Text.Encoding.Default))
        {
            return file.ReadToEnd();
        }
    }
    public static void Cleaner()
    {
       File.WriteAllText(FileStreamPath, string.Empty);
    }
    public static void Writer(string text)
    {
        using (StreamWriter file = new StreamWriter(FileStreamPath, true, System.Text.Encoding.Default))
        {
            file.Write(text);
        }
    }
    
}