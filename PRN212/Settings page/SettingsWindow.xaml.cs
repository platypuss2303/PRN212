using Microsoft.Win32;
using PRN212.Authentication_page;
using PRN212.BLL.Services;
using PRN212.Calendar_Page;
using PRN212.Customize_Page;
using PRN212.DAL.Models;
using PRN212.Help_page;
using PRN212.Home;
using PRN212.Tasks_page;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PRN212.Settings_page
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private UserService _service;

        public User CurrentUser { get; set; }
        public SettingsWindow()
        {
            InitializeComponent();

             UsernameTextBlock.Text = CurrentUser.Username;
            EmailTextBlock.Text = CurrentUser.Email;
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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_primeironome.Text) ||
       string.IsNullOrWhiteSpace(tb_email.Text) ||
       string.IsNullOrWhiteSpace(tb_passwordNova.Password) ||
       string.IsNullOrWhiteSpace(tb_password.Password))
            {
                MessageBox.Show("Vui lòng điền đầy đủ các trường trước khi lưu các thay đổi.");
                return;
            }

            try
            {
                _service = new UserService();

                // Tìm người dùng hiện tại
                User user = _service.GetUserByUsername(CurrentUser.Username);

                // Nếu người dùng được tìm thấy, kiểm tra mật khẩu cũ
                if (user != null)
                {
                    if (user.Password != tb_password.Password)
                    {
                        MessageBox.Show("Old password is wrong");
                        return;
                    }

                    user.Username = tb_primeironome.Text;
                    user.Email = tb_email.Text;
                    user.Password = tb_passwordNova.Password;

                    // Cập nhật thông tin người dùng
                    _service.UpdateUser(user);

                    // Cập nhật các thuộc tính của lớp CurrentUser
                    CurrentUser.Username = tb_primeironome.Text;
                    CurrentUser.Email = tb_email.Text;

                    // Hiển thị thông báo thành công
                    MessageBox.Show("Done");

                    // Mở trang cài đặt và đóng cửa sổ hiện tại
                    SettingsWindow mainWindow = new SettingsWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error: {ex.Message}");
            }

           
        }
        private void EndSession_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow mainWindow = new LoginWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ChangeImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.bmp)|*.png;*.jpeg;*.jpg;*.bmp|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                userImage.Source = new BitmapImage(fileUri);

                // Mantém a dimensão da imagem
                userImage.Width = 95;
                userImage.Height = 101;
            }
        }
    }
}
