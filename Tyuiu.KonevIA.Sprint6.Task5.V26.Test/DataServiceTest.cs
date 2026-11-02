using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.KonevIA.Sprint6.Task5.V26.Lib;
namespace Tyuiu.KonevIA.Sprint6.Task5.V26.Test;
[TestClass]
public class DataServiceTest
{
    private static void Check(string text, double[] expected)
    {
        string path=Path.GetTempFileName();
        try
        {
            File.WriteAllText(path,text);
            CollectionAssert.AreEqual(expected,new DataService().LoadFromDataFile(path));
        }
        finally { File.Delete(path); }
    }
    [TestMethod]
    public void SelectsMultiplesOfFive() => Check("5\n-10\n0\n2.5\n15\n5.0001",new double[]{5,-10,0,15});
    [TestMethod]
    public void SupportsCommaAndWhitespace() => Check(" 10,000; -5,0\t3,25\r\n20.0 ",new double[]{10,-5,20});
    [TestMethod]
    public void NoMatchesAndEmptyFile()
    {
        Check("1 2 3",Array.Empty<double>());
        Check("",Array.Empty<double>());
    }
}
