using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.KonevIA.Sprint6.Task2.V4.Lib;
namespace Tyuiu.KonevIA.Sprint6.Task2.V4.Test;
[TestClass]
public class DataServiceTest
{
    [TestMethod]
    public void GivenRange()
    {
        double[] values = new DataService().GetMassFunction(-5, 5);
        Assert.AreEqual(11, values.Length);
        Assert.AreEqual(3.25, values[5]);
        Assert.AreEqual(-2.16, values[4]);
        Assert.AreEqual(-12.35, values[1]);
    }
    [TestMethod]
    public void SinglePoint() => CollectionAssert.AreEqual(new[] { 3.25 }, new DataService().GetMassFunction(0, 0));
    [TestMethod]
    public void ReversedRange() => Assert.ThrowsException<ArgumentException>(() => new DataService().GetMassFunction(2, 1));
}

