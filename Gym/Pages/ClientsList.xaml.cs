using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Service;

namespace Gym.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientsList.xaml
    /// </summary>
    public partial class ClientsList : Window
    {
        public ClientsList()
        {
            InitializeComponent();
            if (GlobalContainer.Role.Equals("Admin")){
                AddManager.Visibility = Visibility.Visible;
            }
            DgridClients.ItemsSource = ClientService.GetAllClients();
        }
  
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string str = FindTextBox.Text.Trim();
            List<Client> clients = ClientService.FindClients(str);
            if(clients.Count == 0)
            {
                MessageBox.Show("Клиент не найден");
                return;
            }
            else
            {
                DgridClients.ItemsSource = clients;
            }
        }

      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddManager addManager = new AddManager();
            addManager.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var clients = DgridClients.SelectedItems.Cast<Client>().ToList();
            if (ClientService.DeleteClients(clients))
            {
                MessageBox.Show("Клиент удален");
            }
            else
            {
                MessageBox.Show("Клиент не  удален");
            }
            DgridClients.ItemsSource = ClientService.GetAllClients();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {   
            string firstName = FirstNameTextBox.Text.Trim();
            string lastName = lastNameTextBox.Text.Trim();
            string patranymic = PatranymicTextBox.Text.Trim();
            string phone = PhoneTextBox.Text.Trim();

            if (ClientService.CheckInputs(firstName, lastName, patranymic, phone))
            {
                if (ClientService.AddClient(firstName, lastName, patranymic, phone))
                {
                    DgridClients.ItemsSource = ClientService.GetAllClients();
                    MessageBox.Show("Клиент добавлен");
                }
                else
                {
                    MessageBox.Show("Клиент не добавлен");
                }
            }
            else
            {
                MessageBox.Show("Не валидные данные");
            }
            
        }

        private void DgridClients_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var client = (Client)DgridClients.CurrentItem;
            if (string.IsNullOrEmpty(client?.FirstName) || string.IsNullOrEmpty(client?.LastName) || string.IsNullOrEmpty(client?.Phone))
                return;

            GlobalContainer.Id = client.Id;
            GlobalContainer.Lastname = client.LastName;
            GlobalContainer.Name = client.FirstName;
            GlobalContainer.Surname = client.Patranymic;

            ClientCard clientCard = new ClientCard();
            clientCard.Title = "Карточка клиента";
            clientCard.Show();
            Close();
        }
    }
}
