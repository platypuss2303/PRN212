using PRN212.BLL.Services;
using PRN212.Calendar_Page;
using PRN212.DAL.Models;
using PRN212.Help_page;
using PRN212.Home;
using PRN212.Settings_page;
using PRN212.Tasks_page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PRN212.Customize_Page
{
    /// <summary>
    /// Interaction logic for CustomizeWindow.xaml
    /// </summary>
    public partial class CustomizeWindow : Window
    {
        private UserService? _service = new();
        public User CurrentUser { get; set; }
        public CustomizeWindow()
        {
            InitializeComponent();
            UsernameTextBlock.Text = "Username: " + CurrentUser.Username;
            EmailTextBlock.Text = "Email: " + CurrentUser.Email;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow home = new();
            home.Show();
            this.Close();
        }

        private void Calendar_Click(object sender, RoutedEventArgs e)
        {
            CalendarWindow calendarWindow = new();
            calendarWindow.Show();
            this.Close();
        }

        private void TaskWindow_Click(object sender, RoutedEventArgs e)
        {
            TaskWindow taskWindow = new();
            taskWindow.Show();
            this.Close();

        }

        private void Customize_Click(object sender, RoutedEventArgs e)
        {
            CustomizeWindow customizeWindow = new();
            customizeWindow.Show();
            this.Close();

        }

        private void SettingWindow_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new();
            settingsWindow.Show();
            this.Close();

        }

        private void HelpWindow_Click(object sender, RoutedEventArgs e)
        {
            HelperWindow helperWindow = new();
            helperWindow.Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void SaveUserTheme() 
        {
            if (_service.GetUserByEmail(CurrentUser.Email) != null)
            {
                _service.GetUserByEmail(CurrentUser.Email).Theme = CurrentUser.Theme;
                _service.UpdateUser(_service.GetUserByEmail(CurrentUser.Email));
            }
           
        }
        private void ChangeTheme(string theme )
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            var resourceDictionary = new ResourceDictionary { Source = new Uri(theme, UriKind.Relative) };
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);

        }

        private void DarkModeButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeTheme("Themes/Dark.xaml");
            CurrentUser.Theme = "Dark";
            SaveUserTheme();
            CustomizeWindow customizeWindow = new();
            customizeWindow.Show();
            this.Close();
        }

        private void LightModeButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeTheme("Themes/Light.xaml");
            CurrentUser.Theme = "Light";
            SaveUserTheme();
            CustomizeWindow customizeWindow = new();
            customizeWindow.Show();
            this.Close();
        }

        private void ColorDarkREDButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeTheme("Themes/DarkRED.xaml");
            CurrentUser.Theme = "DarkRED";
            SaveUserTheme();
            CustomizeWindow customizeWindow = new();
            customizeWindow.Show();
            this.Close();
        }

        private void ColorYELLOWButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeTheme("Themes/DarkYELLOW.xaml");
            CurrentUser.Theme = "DarkYELLOW";
            SaveUserTheme();
            CustomizeWindow customizeWindow = new();
            customizeWindow.Show();
            this.Close();
        }

        private void ColorORANGEButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeTheme("Themes/DarkORANGE.xaml");
            CurrentUser.Theme = "DarkORANGE";
            SaveUserTheme();
            CustomizeWindow customizeWindow = new();
            customizeWindow.Show();
            this.Close();
        }

        private void ColorPURPLEButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeTheme("Themes/DarkPURPLE.xaml");
            CurrentUser.Theme = "DarkPURPLE";
            SaveUserTheme();
            CustomizeWindow customizeWindow = new();
            customizeWindow.Show();
            this.Close();

        }

        private void ColorGREENButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeTheme("Themes/DarkGreen.xaml");
            CurrentUser.Theme = "DarkGreen";
            SaveUserTheme();
            CustomizeWindow customizeWindow = new();
            customizeWindow.Show();
            this.Close();
        }

        private void ColorLightREDButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeTheme("Themes/LightRED.xaml");
            CurrentUser.Theme = "LightRED";
            SaveUserTheme();
            CustomizeWindow customizeWindow = new();
            customizeWindow.Show();
            this.Close();
        }

        private void ColorLightYELLOWButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeTheme("Themes/LightYELLOW.xaml");
            CurrentUser.Theme = "LightYELLOW";
            SaveUserTheme();
            CustomizeWindow customizeWindow = new();
            customizeWindow.Show();
            this.Close();

        }

        private void ColorLightORANGEButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeTheme("Themes/LightORANGE.xaml");
            CurrentUser.Theme = "LightORANGE";
            SaveUserTheme();
            CustomizeWindow customizeWindow = new();
            customizeWindow.Show();
            this.Close();
        }

        private void ColorLightPURPLEButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeTheme("Themes/LightPURPLE.xaml");
            CurrentUser.Theme = "LightPURPLE";
            SaveUserTheme();
            CustomizeWindow customizeWindow = new();
            customizeWindow.Show();
            this.Close();
        }

        private void ColorLightGREENButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeTheme("Themes/LightGREEN.xaml");
            CurrentUser.Theme = "LightGREEN";
            SaveUserTheme();
            CustomizeWindow customizeWindow = new();
            customizeWindow.Show();
            this.Close();
        }
    }
}
