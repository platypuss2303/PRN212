using Newtonsoft.Json;
using PRN212.BLL.Services;
using PRN212.DAL.Models;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace PRN212.Authentication_page
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private UserService _service = new();

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(password.Password) && password.Password.Length > 0)
                textPassword.Visibility = Visibility.Collapsed;
            else
                textPassword.Visibility = Visibility.Visible;
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            password.Focus();
        }

        private void Registar_Btn_Click(object sender, RoutedEventArgs e)
        {
            // Get the values from the input fields
            string usernameInput = username.Text.Trim();
            string emailInput = email.Text.Trim();
            string passwordInput = password.Password;

            // Validate the email format
            if (!IsValidEmail(emailInput))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Check if the username or password fields are empty
            if (string.IsNullOrEmpty(usernameInput) || string.IsNullOrEmpty(passwordInput))
            {
                MessageBox.Show("Username and password cannot be empty.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Create a new user object
            var newUser = new User
            {
                Id = Guid.NewGuid(), 
                Username = usernameInput,
                Email = emailInput,
                Theme = "Default", 
            };

            // Hash the password before storing it
            //newUser.SetPassword(passwordInput);

            bool isRegistered = _service.CheckUserExist(newUser);

            if (isRegistered)
            {
                MessageBox.Show("Registration successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoginWindow loginWindow = new LoginWindow();
                this.Close();
                loginWindow.Show();
            }
            else
            {
                MessageBox.Show("Registration failed. Username or email may already be in use.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            email.Focus();
        }

        private void txtUsername_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(username.Text) && username.Text.Length > 0)
                textUsername.Visibility = Visibility.Collapsed;
            else
                textUsername.Visibility = Visibility.Visible;
        }

        private void textUsername_MouseDown(object sender, MouseButtonEventArgs e)
        {
            username.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow l1 = new LoginWindow();
            this.Close();
            l1.Show();
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
    }
}
