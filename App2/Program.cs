using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    class Program
    {
        static void Main(string[] args)
        {
            Pathfinder pathfinderFile = new Pathfinder(new FileLogWritter());
            Pathfinder pathfinderConsole = new Pathfinder(new ConsoleLogWritter());
            Pathfinder pathfinderFileToFriday = new Pathfinder(new SecureLogWritter(new FileLogWritter(), new Day(DayOfWeek.Friday)));
            Pathfinder pathfinderConsoleToFriday = new Pathfinder(new SecureLogWritter(new ConsoleLogWritter(), new Day(DayOfWeek.Friday)));
            Pathfinder pathfinderSeveralLogs = new Pathfinder(new SeveralLogsWritter(new ConsoleLogWritter(), new SecureLogWritter(new FileLogWritter(), new Day(DayOfWeek.Friday))));

            pathfinderFile.Find();
            pathfinderConsole.Find();
            pathfinderFileToFriday.Find();
            pathfinderConsoleToFriday.Find();
            pathfinderSeveralLogs.Find();
        }

        class Pathfinder
        {
            private readonly ILogger _logger;

            public Pathfinder(ILogger logger)
            {
                _logger = logger;
            }

            public void Find()
            {
                _logger.WriteError("Сообщение");
            }
        }

        class Day
        {
            private DayOfWeek _day;

            public Day(DayOfWeek day)
            {
                _day = day;
            }

            public bool IsMatch()
            {
                if (DateTime.Now.DayOfWeek == _day)
                    return true;

                return false;
            }
        }

        class SeveralLogsWritter : ILogger
        {
            private ILogger[] _loggers;

            public SeveralLogsWritter(params ILogger[] loggers)
            {
                _loggers = loggers;
            }

            public void WriteError(string message)
            {
                foreach (var logger in _loggers)
                {
                    logger.WriteError(message);
                }
            }
        }

        class ConsoleLogWritter : ILogger
        {
            public void WriteError(string message)
            {
                Console.WriteLine(message);
            }
        }

        class SecureLogWritter : ILogger
        {
            private ILogger _logger;
            private Day _day;

            public SecureLogWritter(ILogger logger, Day day)
            {
                _logger = logger;
                _day = day;
            }

            public void WriteError(string message)
            {
                if (_day.IsMatch())
                    _logger.WriteError(message);
            }
        }

        class FileLogWritter : ILogger
        {
            public void WriteError(string message)
            {
                File.WriteAllText("log.txt", message);
            }
        }

        static class File
        {
            public static void WriteAllText(string log, string message)
            {
                Console.WriteLine(log);
                Console.WriteLine(message);
            }
        }

        public interface ILogger
        {
            void WriteError(string message);
        }
    }
}