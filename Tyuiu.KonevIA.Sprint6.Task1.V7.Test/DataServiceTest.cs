using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.KonevIA.Sprint6.Task1.V7.Lib;
namespace Tyuiu.KonevIA.Sprint6.Task1.V7.Test;
[TestClass]
public class DataServiceTest
{
    [TestMethod]
    public void GivenRange()
    {
        double[] expected = { 7.76, 7.36, 7.26, 7.9, 15.88, 2, 4.35, 5.63, 6.49, 6.49, 6.32 };
        CollectionAssert.AreEqual(expected, new DataService().GetMassFunction(-5, 5));
    }
    [TestMethod]
    public void SinglePoint() => CollectionAssert.AreEqual(new[] { 2.0 }, new DataService().GetMassFunction(0, 0));
    [TestMethod]
    public void ReversedRange() => Assert.ThrowsException<ArgumentException>(() => new DataService().GetMassFunction(2, 1));
}
