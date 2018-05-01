namespace BashSoft
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class CommandInterpreter
    {
        private const string endCommand = "quit";

        public static void StartReadingCommands()
        {
            var input = Console.ReadLine().Trim();

            while (input != endCommand)
            {
                OutputWriter.WriteMessage($"{SessionData.currentPath}>");
                input = Console.ReadLine().Trim();
            }
        }
    }
}
