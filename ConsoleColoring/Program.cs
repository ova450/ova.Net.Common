
using ova.Net.common.Console.Colors;
using static ova.Net.common.Console.Colors.SegmentLine;

namespace ova.Net.common.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("1/ Hello, World!");
            WriteSegment("2/ Hello, ");
            WriteSegment("World!", System.ConsoleColor.Yellow);
            System.Console.WriteLine();
            WriteSegment("3/ Hello, World!", System.ConsoleColor.DarkCyan, false);
            System.Console.WriteLine();
            WriteSegment("4/ Hello, World!", new BiColor { BackgroundColor = System.ConsoleColor.DarkGreen, ForegroundColor = System.ConsoleColor.Yellow });
            System.Console.WriteLine();
            WriteSegment("5/ Hello, World!",  System.ConsoleColor.DarkMagenta,  System.ConsoleColor.Cyan );
            System.Console.WriteLine();
            WriteSegment("6/ Hello, ");
            WriteLineSegment("World!", System.ConsoleColor.Yellow);
            WriteLineSegment("7/ Hello, World!", System.ConsoleColor.DarkCyan, false);
            WriteLineSegment("8/ Hello, World!", new BiColor { BackgroundColor = System.ConsoleColor.DarkGreen, ForegroundColor = System.ConsoleColor.Yellow });
            WriteLineSegment("9/ Hello, World!", System.ConsoleColor.DarkMagenta, System.ConsoleColor.Cyan);
        }
    }
}

