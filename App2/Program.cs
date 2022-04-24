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

        public class Pathfinder
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

        public class Day
        {
            private DayOfWeek _title;
            private bool _isMatch => DateTime.Now.DayOfWeek == _title;

            public bool IsMatch => _isMatch;

            public Day(DayOfWeek title)
            {
                _title = title;
            }
        }

        public class ConsoleLogWritter : ILogger
        {
            public void WriteError(string message)
            {
                Console.WriteLine(message);
            }
        }

        public class FileLogWritter : ILogger
        {
            public void WriteError(string message)
            {
                File.WriteAllText("log.txt", message);
            }
        }

        public static class File
        {
            public static void WriteAllText(string log, string message)
            {
                Console.WriteLine(log);
                Console.WriteLine(message);
            }
        }

        public class SeveralLogsWritter : ILogger
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

        public class SecureLogWritter : ILogger
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
                if (_day.IsMatch)
                    _logger.WriteError(message);
            }
        }

        public interface ILogger
        {
            void WriteError(string message);
        }
    }
}