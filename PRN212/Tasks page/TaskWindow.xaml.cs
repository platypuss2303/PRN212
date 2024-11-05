using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PRN212.DAL.Models;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using PRN212.Calendar_Page;
using PRN212.Customize_Page;
using PRN212.Help_page;
using PRN212.Home;
using PRN212.Settings_page;
using PRN212.BLL.Services;

namespace PRN212.Tasks_page
{
    /// <summary>
    /// Interaction logic for TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
       private TaskService? _service = new();
        public User CurrentUser { get; set; }
        public TaskWindow()
        {
            InitializeComponent();
            UsernameTextBlock.Text = "Username: " + CurrentUser.Username;
            EmailTextBlock.Text = "Email: " + CurrentUser.Email;
            TaskConcludeListbox.ItemsSource = _service.GetTaskById(CurrentUser.Id);

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
    }
}
