using System.Windows;

namespace PRN212.Themes
{
    public static class ThemeManager
    {
        public static void ChangeTheme(string theme)
        {
            Application.Current.Resources.MergedDictionaries.Clear();

            var resourceDictionary = new ResourceDictionary { Source = new Uri(theme, UriKind.Relative) };
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }
    }
}
