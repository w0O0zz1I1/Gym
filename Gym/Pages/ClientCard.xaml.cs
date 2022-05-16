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
            ClientName.Content = $"Абонемент {GlobalContainer.Surname} {GlobalContainer.Name} {GlobalContainer.Patronymic}";
        }
    }
}
