namespace BashSoft
{
    using System;
    using System.IO;

    public class BashSoftProgram
    {
        public static void Main()
        {
            //StudentsRepository.InitializeData();
            //StudentsRepository.GetStudentsScoreFromCourse("Unity", "Ivan");
            //IOManager.CreateDirectoryInCurrentFolder("Test");
            //IOManager.TraverseDirectory(1);
            TestIOManager();
            //IOManager.ChangeCurrentDirectoryAbsolute(@"C:\Windows");
            //IOManager.TraverseDirectory(20);
        }

        private static void TestIOManager()
        {
            var command = string.Empty;

            while (command != "end")
            {
                Console.WriteLine(IOManager.GetCurrentDirectoryPath());
                command = Console.ReadLine();

                switch (command)
                {
                    case "..":
                        IOManager.ChangeCurrentDirectoryRelative(command);
                        break;
                    case "dir":
                        IOManager.TraverseDirectory(1);
                        break;
                    default:
                        if (command != "end") IOManager.ChangeCurrentDirectoryRelative(command);
                        break;
                }
            }
        }
    }
}
