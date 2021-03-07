using System;

namespace ova.Net.common.Console.Colors
{
    public static class Settings
    {
        public static void ResetColors() { CurrentColors = SavedColors; }
        public static void SaveColors() { SavedColors = CurrentColors; }
        public static void SetAndSaveColors(BiColor colors)
        {
            SavedColors = colors;
            ResetColors();
        }
        public static void SetColor(ConsoleColor color, bool @isforegroundcolor = true)
        {
            BiColor colors = CurrentColors;
            if (isforegroundcolor) { colors.ForegroundColor = color; } else { colors.BackgroundColor = color; }
            CurrentColors = colors;
        }
        public static void SaveColor(ConsoleColor color, bool @isforegroundcolor = true)
        {
            BiColor colors = SavedColors;
            if (isforegroundcolor) { colors.ForegroundColor = color; } else { colors.BackgroundColor = color; }
            SavedColors = colors;
        }
        public static void SetAndSaveColor(ConsoleColor color, bool @isforegroundcolor = true)
        {
            SetColor(color, isforegroundcolor);
            SaveColor(color, isforegroundcolor);
        }

        #region properties
        private static BiColor savedcolors = new BiColor {
            BackgroundColor=System.Console.BackgroundColor,
            ForegroundColor=System.Console.ForegroundColor 
        };
        public static BiColor CurrentColors
        {
            get => new BiColor { BackgroundColor = System.Console.BackgroundColor, ForegroundColor = System.Console.ForegroundColor };
            set
            {
                System.Console.BackgroundColor = value.BackgroundColor;
                System.Console.ForegroundColor = value.ForegroundColor;
            }
        }
        public static BiColor SavedColors
        {
            get => new BiColor { BackgroundColor = savedcolors.BackgroundColor, ForegroundColor = savedcolors.ForegroundColor };
            set
            {
                savedcolors.BackgroundColor = value.BackgroundColor;
                savedcolors.ForegroundColor = value.ForegroundColor;
            }
        }
        #endregion 
    }
}

