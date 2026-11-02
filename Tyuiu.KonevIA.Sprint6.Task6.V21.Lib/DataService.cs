using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.KonevIA.Sprint6.Task6.V21.Lib;
public class DataService : ISprint6Task6V21
{
    public string CollectTextFromFile(string path)
    {
        string[] words = File.ReadAllText(path).Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
        return string.Join(" ", words.Where(word => word.Contains('g')));
    }
}
