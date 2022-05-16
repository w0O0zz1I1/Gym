using Service;
using System.Windows;

namespace Gym.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientCard.xaml
    /// </summary>
    public partial class ClientCard : Window
    {
        public ClientCard()
        {
            InitializeComponent();
            ClientName.Content = $"Абонемент {GlobalContainer.Surname} {GlobalContainer.Name}";
            DgridClients.ItemsSource = SubscriptionService.GetByClientId(GlobalContainer.Id);
            AddSubscription.IsEnabled = false;
        }

        private void AddVisit_Click(object sender, RoutedEventArgs e)
        {
            var result = SubscriptionService.AddVisit(GlobalContainer.Id);
            if (result != null)
            {
                DgridClients.ItemsSource = result;
            }
        }

        private void AddSubscription_Click(object sender, RoutedEventArgs e)
        {
            var price = SubscriptionService.CheckPrice(Price.Text);
            var workOutsAmount = SubscriptionService.CheckWorkOutsAmount(WorkOutsAmount.Text);
            if (price == null || workOutsAmount == null)
            {
                MessageBox.Show("Не все поля заполнены верно");
                return;
            }

            var result = SubscriptionService.AddSubscription(GlobalContainer.Id, (decimal)price, (int)workOutsAmount);
            if (result != null)
            {
                DgridClients.ItemsSource = result;
            }
        }

        private void Price_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(WorkOutsAmount?.Text)  is false && AddSubscription != null)
            {
                AddSubscription.IsEnabled = true;
            }
        }

        private void WorkOutsAmount_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(Price?.Text) is false && AddSubscription != null)
            {
                AddSubscription.IsEnabled = true;
            }
        }
    }
}
