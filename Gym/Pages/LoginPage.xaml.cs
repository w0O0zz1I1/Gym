using System.Windows;
using Gym.Pages;
using Service;

namespace Gym
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();
            if (Autorization.Login(login, password))
            {
                ClientsList clientsList = new ClientsList();
                clientsList.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Пользователь не найден, неверный логин или пароль");
            }
        }
    }
}
