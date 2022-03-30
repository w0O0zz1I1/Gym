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
        }
        /// <summary>
        /// При клике на кнопку "поиск" открывается страница карточка клиента
        /// т.к. это тестовая ветка для разработки UI решили реализовать так
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClientCard clientCard = new ClientCard();
            clientCard.Show();
        }

        /// <summary>
        /// При клике на + открывается окно добавления менеджера причина такая же
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddManager addManager = new AddManager();
            addManager.Show();
        }
       
    }
}
