namespace BashSoft
{
    using System;
    using System.IO;

    public class BashSoftProgram
    {
        public static void Main()
        {
            //IOManager.TraverseDirectory(@"D:\source\repos\C-Advanced\07. BashSoft\BashSoft\BashSoft");  
            StudentsRepository.InitializeData();
            StudentsRepository.GetStudentsScoreFromCourse("Unity", "Ivan");
        }
    }
}
