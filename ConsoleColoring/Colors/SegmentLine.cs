using System;
using static ova.Net.common.Console.Colors.Settings;

namespace ova.Net.common.Console.Colors 
{
    public static class SegmentLine
    {
        public static void WriteSegment(string label) { System.Console.Write(label); }
        public static void WriteSegment(string label, BiColor colors)
        {
            SaveColors();
            CurrentColors = colors;
            WriteSegment(label);
            ResetColors();
        }
        public static void WriteSegment(string label, ConsoleColor color, bool @isforeground = true)
        {
            SaveColors();
            SetColor(color, isforeground);
            WriteSegment(label);
            ResetColors();
        }
        public static void WriteSegment(string label, ConsoleColor foregroundcolor, ConsoleColor backgroundcolor)
        {
            SaveColors();
            CurrentColors = new BiColor { BackgroundColor=backgroundcolor, ForegroundColor=foregroundcolor };
            WriteSegment(label);
            ResetColors();
        }
        public static void WriteLineSegment(string label) { System.Console.WriteLine(label); }
        public static void WriteLineSegment(string label, BiColor colors)
        {
            WriteSegment(label, colors);
            System.Console.WriteLine();
        }
        public static void WriteLineSegment(string label, ConsoleColor color, bool @isforeground = true)
        {
            WriteSegment(label, color, isforeground);
            System.Console.WriteLine();
        }
        public static void WriteLineSegment(string label, ConsoleColor foregroundcolor, ConsoleColor backgroundcolor)
        {
            WriteSegment (label, foregroundcolor, backgroundcolor);
            System.Console.WriteLine();
        }



        //Public ColorsDictionary As New Dictionary(Of LogLevel, ConsoleColor)

        //Public Async Sub ColorsDictionaryCreate()
        //    ColorsDictionary.Clear()
        //    With ColorsDictionary
        //        .Add(LogLevel.Trace, ConsoleColor.Gray)
        //        .Add(LogLevel.Debug, ConsoleColor.Cyan)
        //        .Add(LogLevel.Information, ConsoleColor.White)
        //        .Add(LogLevel.Warning, ConsoleColor.Blue)
        //        .Add(LogLevel.Error, ConsoleColor.Yellow)
        //        .Add(LogLevel.Critical, ConsoleColor.Red)
        //        .Add(LogLevel.None, ConsoleColor.Gray)
        //    End With
        //    Await ColorSettingSaveAsync()
        //    Await ColorSettingReadAsync()
        //End Sub
    }
}

