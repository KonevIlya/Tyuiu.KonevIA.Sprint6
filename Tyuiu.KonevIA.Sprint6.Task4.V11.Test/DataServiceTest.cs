using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.KonevIA.Sprint6.Task4.V11.Lib;
namespace Tyuiu.KonevIA.Sprint6.Task4.V11.Test;
[TestClass]
public class DataServiceTest
{
    [TestMethod]
    public void RangeAndDivisionByZero()
    {
        double[] values = new DataService().GetMassFunction(-5, 5);
        Assert.AreEqual(11, values.Length);
        Assert.AreEqual(1.0, values[5]);
        Assert.AreEqual(0.0, values[6]);
        Assert.AreEqual(20.36, values[0]);
        Assert.AreEqual(-19.6, values[10]);
    }
    [TestMethod]
    public void SinglePoint() => CollectionAssert.AreEqual(new[] { 0.0 }, new DataService().GetMassFunction(1, 1));
}
