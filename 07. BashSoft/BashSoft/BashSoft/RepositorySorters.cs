namespace BashSoft
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class RepositorySorters
    {
        public static void OrderAndTake(Dictionary<string, List<int>> wantedData, string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();

            if (comparison == "ascending")
            {
                OrderAndTake(wantedData, studentsToTake, CompareInOrder);
            }
            else if (comparison == "descending")
            {
                OrderAndTake(wantedData, studentsToTake, CompareDescendingOrder);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        private static void OrderAndTake(Dictionary<string, List<int>> wantedData, int studentToTake,
            Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> comparisonFunc)
        {
            var studentsSorted = GetSortedStudents(wantedData, studentToTake, comparisonFunc);

            foreach (var student in studentsSorted)
            {
                OutputWriter.DisplayStudent(student);
            }
        }

        private static int CompareInOrder(KeyValuePair<string, List<int>> firstValue,
            KeyValuePair<string, List<int>> secondValue)
        {
            var totalScoreOfFirst = 0;

            foreach (var mark in firstValue.Value)
            {
                totalScoreOfFirst += mark;
            }

            var totalScoreOfSecond = 0;

            foreach (var mark in secondValue.Value)
            {
                totalScoreOfSecond += mark;
            }

            return totalScoreOfSecond.CompareTo(totalScoreOfFirst);
        }

        private static int CompareDescendingOrder(KeyValuePair<string, List<int>> firstValue,
            KeyValuePair<string, List<int>> secondValue)
        {
            var totalScoreOfFirst = 0;

            foreach (var mark in firstValue.Value)
            {
                totalScoreOfFirst += mark;
            }

            var totalScoreOfSecond = 0;

            foreach (var mark in secondValue.Value)
            {
                totalScoreOfSecond += mark;
            }

            return totalScoreOfFirst.CompareTo(totalScoreOfSecond);
        }

        private static Dictionary<string, List<int>> GetSortedStudents(Dictionary<string, List<int>> wantedData,
            int studentToTake,
            Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> comparisonFunc)
        {
            var studentsTaken = 0;
            var studentsSorted = new Dictionary<string, List<int>>();
            var nextInOrder = new KeyValuePair<string, List<int>>();

            var isSorted = false;

            while (studentsTaken < studentToTake)
            {
                isSorted = true;

                foreach (var student_score in wantedData)
                {
                    if (!string.IsNullOrEmpty(nextInOrder.Key))
                    {
                        var comparisonResult = comparisonFunc(student_score, nextInOrder);

                        if (comparisonResult >= 0 && !studentsSorted.ContainsKey(student_score.Key))
                        {
                            nextInOrder = student_score;
                            isSorted = false;
                        }
                    }
                    else
                    {
                        if (!studentsSorted.ContainsKey(student_score.Key))
                        {
                            nextInOrder = student_score;
                            isSorted = false;
                        }
                    }
                }

                if (!isSorted)
                {
                    studentsSorted.Add(nextInOrder.Key, nextInOrder.Value);
                    studentsTaken++;
                    nextInOrder = new KeyValuePair<string, List<int>>();
                }
            }

            return studentsSorted;
        }
    }
}
