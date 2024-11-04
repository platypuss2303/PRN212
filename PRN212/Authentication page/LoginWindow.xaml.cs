using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PRN212.BLL.Services;
using PRN212.DAL.Models;
using PRN212.Home;
using PRN212.Themes;
using System.Windows;
using System.Windows.Input;

namespace PRN212.Authentication_page
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private UserService _service = new();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(password.Password) && password.Password.Length > 0)
                PasswordTextBox.Visibility = Visibility.Collapsed;
            else
                PasswordTextBox.Visibility = Visibility.Visible;
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            password.Focus();
        }

        private void Login_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(EmailAddressTextBox.Text.IsNullOrEmpty() || PasswordTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Invalid email or password", "Wrong", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            User? account = _service.GetOne(EmailAddressTextBox.Text, PasswordTextBox.Text);
            HomeWindow h = new();
            h.CurrentUser = account;
            h.Show();
            this.Hide();
        }

        

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            email.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow r1 = new RegisterWindow();
            this.Close();
            r1.Show();
        }


    }
}
