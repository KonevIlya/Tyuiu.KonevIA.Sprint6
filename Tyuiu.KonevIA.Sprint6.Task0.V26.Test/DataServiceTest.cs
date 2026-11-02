using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.KonevIA.Sprint6.Task0.V26.Lib;
namespace Tyuiu.KonevIA.Sprint6.Task0.V26.Test;
[TestClass]
public class DataServiceTest
{
    [TestMethod]
    public void GivenValue() => Assert.AreEqual(0.769, new DataService().Calculate(3));
    [TestMethod]
    public void OtherValues()
    {
        var service = new DataService();
        Assert.AreEqual(0.25, service.Calculate(0));
        Assert.AreEqual(2.0, service.Calculate(-1));
    }
}
