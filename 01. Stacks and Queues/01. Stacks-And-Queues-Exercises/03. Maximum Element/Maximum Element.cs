namespace _03.Maximum_Element
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaximumElement
    {
        private static Stack<int> _mainStack = new Stack<int>();
        private static Stack<int> _trackStack = new Stack<int>();   
        
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            _trackStack.Push(int.MinValue);


            for (var i = 0; i < n; i++)
            {
                var query = Console.ReadLine();
                ProcessQuery(query);
            }
        }

        private static void ProcessQuery(string query)  
        {
            var tokens = query
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var queryTyppe = tokens[0];
            int queryBody = 0;

            if (queryTyppe == 1)
            {
                queryBody = tokens[1];
            }

            switch (queryTyppe)
            {
                case 1:
                    Insert(queryBody);
                    break;
                case 2:
                    Remove();
                    break;
                case 3:
                    Console.WriteLine(GetMax());
                    break;
            }
        }

        private static void Insert(int element)
        {
            var currentMax = _trackStack.Peek();

            if (element >= currentMax)
            {
                _trackStack.Push(element);
            }
            
            _mainStack.Push(element);
        }

        private static int Remove()
        {
            var removedElement = _mainStack.Pop();

            if (removedElement == _trackStack.Peek())
            {
                _trackStack.Pop();
            }

            return removedElement;
        }

        public static int GetMax()
        {
            return _trackStack.Peek();
        }
    }
}