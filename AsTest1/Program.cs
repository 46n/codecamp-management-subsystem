using APUCC_Project.Forms.Trainer;

namespace APUCC_Project
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new StudentShellForm());
            Application.Run(new StudentShellForm());
            //Application.Run(new TrainerShellForm());
        }
    }
}