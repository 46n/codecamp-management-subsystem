using APUCC_Project.Forms.Common;

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
            //Application.Run(new LectureShellForm());
            //Application.Run(new StudentShellForm(1));
            //Application.Run(new TrainerShellForm());
            //Application.Run(new AdminShellForm());
            Application.Run(new LoginForm());
        }
    }
}