namespace Aetherial_Engine
{
    internal static class MainCode
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Engine());
        }
    }
}