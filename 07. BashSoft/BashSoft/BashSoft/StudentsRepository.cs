namespace BashSoft
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class StudentsRepository
    {
        public static bool isDataInitialized = false;

        //Dictionary<course_name, Dictionary<user_name, Scores_On_tasks>>>
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        public static void InitializeData()
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData();
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataAlreadyInitializedException);
            }
        }

        private static void ReadData()
        {
            var input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                var tokens = input.Split(' ');
                var course = tokens[0];
                var student = tokens[1];
                var mark = int.Parse(tokens[2]);

                //Check if the course exist and if dont initialize it
                if (!studentsByCourse.ContainsKey(course))
                {
                    studentsByCourse[course] = new Dictionary<string, List<int>>();
                }

                //Check if the student exist and if dont initialize it
                if (!studentsByCourse[course].ContainsKey(student))
                {
                    studentsByCourse[course][student] = new List<int>();
                }

                //ADD the mark
                studentsByCourse[course][student].Add(mark);
                input = Console.ReadLine();
            }

            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read!");
        }

        private static bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                if (studentsByCourse.ContainsKey(courseName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            return false;
        }

        private static bool IsQueryForStudentPossible(string courseName, string studentUserName)
        {
            if (IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }

            return false;
        }

        public static void GetStudentsScoreFromCourse(string courseName, string username)
        {
            if (IsQueryForStudentPossible(courseName, username))
            {
                var studentScores = studentsByCourse[courseName][username];

                OutputWriter.DisplayStudent(new KeyValuePair<string, List<int>>(username, studentScores));
            }
        }

        public static void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}");

                foreach (var studentMarksEntry in studentsByCourse[courseName])
                {
                    OutputWriter.DisplayStudent(studentMarksEntry);
                }
            }
        }
    }
}
