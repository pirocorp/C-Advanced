namespace BashSoft
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class RepositorySorters
    {
        public static void OrderAndTake(Dictionary<string, List<int>> wantedData, string comparison, int studentsToTake)
        {
            
        }

        private static void OrderAndTake(Dictionary<string, List<int>> wantedData, int studentToTake,
            Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> comparisonFunc)
        {

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
    }
}
