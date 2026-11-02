using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.KonevIA.Sprint6.Task3.V11.Lib;
namespace Tyuiu.KonevIA.Sprint6.Task3.V11.Test;
[TestClass]
public class DataServiceTest
{
    [TestMethod]
    public void GivenMatrix()
    {
        int[,] source = { {27,-15,14,2,27}, {-8,14,-10,33,0}, {1,7,-11,-11,23}, {-13,-20,15,-16,34}, {-3,1,-1,5,1} };
        int[,] expected = { {-13,-15,14,2,27}, {-8,14,-10,33,0}, {-3,7,-11,-11,23}, {1,-20,15,-16,34}, {27,1,-1,5,1} };
        CollectionAssert.AreEqual(expected, new DataService().Calculate(source));
    }
    [TestMethod]
    public void DuplicateValuesAndRectangularMatrix()
    {
        int[,] source = { {2,8}, {-1,7}, {2,6} };
        int[,] expected = { {-1,8}, {2,7}, {2,6} };
        CollectionAssert.AreEqual(expected, new DataService().Calculate(source));
    }
    [TestMethod]
    public void EmptyMatrix() => Assert.AreEqual(0, new DataService().Calculate(new int[0,0]).Length);
}
