using PRN212.Calendar_Page;
using PRN212.Customize_Page;
using PRN212.Home;
using PRN212.Settings_page;
using PRN212.DAL.Models;
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
using Microsoft.IdentityModel.Tokens;

namespace PRN212.Help_page
{
    /// <summary>
    /// Interaction logic for HelperWindow.xaml
    /// </summary>
    public partial class HelperWindow : Window
    {
       public User CurrentUser { get; set; }
        public HelperWindow()
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tb_email.Text.IsNullOrEmpty() || tb_mensagem.Text.IsNullOrEmpty() || tb_primeironome.Text.IsNullOrEmpty() || tb_ultimonome.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Please fill all the fields","",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Message sent successfully","",MessageBoxButton.OK,MessageBoxImage.Information);
                tb_ultimonome.Text = "";
                tb_primeironome.Text = "";
                tb_email.Text = "";
                tb_mensagem.Text = "";

            }
        }
    }
}
