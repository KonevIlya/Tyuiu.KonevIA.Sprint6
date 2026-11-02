using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.KonevIA.Sprint6.Task7.V13.Lib;
namespace Tyuiu.KonevIA.Sprint6.Task7.V13.Test;
[TestClass]
public class DataServiceTest
{
    [TestMethod]
    public void ChangesOnlyPositiveEvenValuesInSixthColumn()
    {
        string path=Path.GetTempFileName();
        try
        {
            File.WriteAllText(path,"2;2;2;2;2;4;2\n1;1;1;1;1;-2;1\n0;0;0;0;0;0;0\n3;3;3;3;3;3;3");
            int[,] expected={{2,2,2,2,2,111,2},{1,1,1,1,1,-2,1},{0,0,0,0,0,0,0},{3,3,3,3,3,3,3}};
            CollectionAssert.AreEqual(expected,new DataService().GetMatrix(path));
            CollectionAssert.AreEqual(expected,new DataService().ReadMatrix(path));
        }
        finally { File.Delete(path); }
    }
    [TestMethod]
    public void SavesCsvAndReadsItBack()
    {
        string path=Path.GetTempFileName();
        try
        {
            var service=new DataService();
            int[,] matrix={{1,2,3,4,5,111},{-1,-2,-3,-4,-5,-6}};
            service.SaveMatrix(path,matrix);
            CollectionAssert.AreEqual(matrix,service.LoadMatrix(path));
            StringAssert.StartsWith(File.ReadAllText(path),"1;2;3;4;5;111");
        }
        finally { File.Delete(path); }
    }
    [TestMethod]
    public void SupportsCommaDelimitedCsv()
    {
        string path=Path.GetTempFileName();
        try
        {
            File.WriteAllText(path,"1,2,3,4,5,6");
            Assert.AreEqual(111,new DataService().GetMatrix(path)[0,5]);
        }
        finally { File.Delete(path); }
    }
}

