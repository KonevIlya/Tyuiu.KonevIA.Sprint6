using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.KonevIA.Sprint6.Task6.V21.Lib;
namespace Tyuiu.KonevIA.Sprint6.Task6.V21.Test;
[TestClass]
public class DataServiceTest
{
    private static void Check(string text, string expected)
    {
        string path=Path.GetTempFileName();
        try
        {
            File.WriteAllText(path,text);
            Assert.AreEqual(expected,new DataService().CollectTextFromFile(path));
        }
        finally { File.Delete(path); }
    }
    [TestMethod]
    public void SelectsWordsContainingLowercaseG() => Check("dog cat green egg GOLF гусь", "dog green egg");
    [TestMethod]
    public void HandlesWhitespaceAndKeepsWordOrder() => Check("  big\tcat\r\ngreen dog\n", "big green dog");
    [TestMethod]
    public void EmptyAndNoMatches()
    {
        Check("", "");
        Check("cat sun", "");
    }
}
