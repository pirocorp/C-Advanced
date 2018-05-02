namespace BashSoft
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class RepositoryFilters
    {
        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int studentsToTake)
        {
            wantedFilter = wantedFilter.ToLower();

            if (wantedFilter == "excellent")
            {
                FilterAndTake(wantedData, ExcellentFilter, studentsToTake);
            }
            else if (wantedFilter == "average")
            {
                FilterAndTake(wantedData, AverageFilter, studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                FilterAndTake(wantedData, PoorFilter, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter);
            }
        }

        private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter,
            int studentsToTake)
        {
            var counterForPrinted = 0;

            foreach (var student_points in wantedData)
            {
                if (counterForPrinted == studentsToTake)
                {
                    break;
                }

                var averageMark = Average(student_points.Value);

                if (givenFilter(averageMark))
                {
                    OutputWriter.DisplayStudent(student_points);
                    counterForPrinted++;
                }
            }
        }

        private static bool ExcellentFilter(double mark)
        {
            return mark >= 5.0;
        }

        private static bool AverageFilter(double mark)
        {
            return mark < 5.0 && mark >= 3.5;
        }

        private static bool PoorFilter(double mark)
        {
            return mark < 3.5;
        }

        private static double Average(List<int> scoresOnTasks)
        {
            var totalScore = 0.0;

            foreach (var score in scoresOnTasks)
            {
                totalScore += score;
            }

            var percentageOfAll = totalScore / (scoresOnTasks.Count * 100);
            var mark = percentageOfAll * 4 + 2;

            return mark;
        }
    }
}
