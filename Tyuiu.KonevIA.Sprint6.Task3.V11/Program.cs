namespace Tyuiu.KonevIA.Sprint6.Task3.V11;
internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FormMain());
    }
}



