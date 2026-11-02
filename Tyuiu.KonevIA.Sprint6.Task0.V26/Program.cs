namespace Tyuiu.KonevIA.Sprint6.Task0.V26;
internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FormMain());
    }
}
