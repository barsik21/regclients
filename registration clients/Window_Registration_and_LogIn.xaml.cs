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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace registration_clients
{
    public class Client
    {
        public string[] name = new string[3];
        public static int Amount;
        public static void Resolution(Client[] clients) //объявляем экземпляры класса
        {
            for (int i = 0; i < clients.Length; i++)
            {
                clients[i] = new Client();
            }
        }
    }
    public partial class MainWindow : Window
    {
        Client[] clients = new Client[99];
        Registration_UsersEntities context = new Registration_UsersEntities();
        CollectionViewSource clientsViewSourse;
        

        public MainWindow()
        {
            InitializeComponent();
            Client.Resolution(clients); //вызываем объявление всех экземпляров
            clientsViewSourse = ((CollectionViewSource)(FindResource("clientsViewSource")));
            DataContext = this;
        }

        private void LogIn_button(object sender, RoutedEventArgs e)
        {
            if(UserNumberPhone.Text != String.Empty && Password.Text != String.Empty)
            {
                frame.Navigate(new Hello_User_());
            }
            else
            {
                MessageBox.Show("Заполните все необходимые данные!");
            }
        }
        private void frame_Navigated(object sender, NavigationEventArgs e)
        {

        }
        private void WindowRegistration(object sender, RoutedEventArgs e)
        {
            Input.Visibility = Visibility.Collapsed;
            InputNewUser.Visibility = Visibility.Visible;
        }

        private void GetRegistr(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text != String.Empty && surNameBox.Text != String.Empty && PatronymicBox.Text != String.Empty)
            {
                clients[Client.Amount].name[0] = NameBox.Text;
                clients[Client.Amount].name[1] = surNameBox.Text;
                clients[Client.Amount].name[2] = PatronymicBox.Text;
                Client.Amount++;
                InputNewUser.Visibility = Visibility.Collapsed;
                frame.Navigate(new Hello_User_());
            }
            else
            {
                MessageBox.Show("Заполните все необходимые данные!");
            }
        }
        private void Telephone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
            if (TelephoneBox.Name != null)
            {
                IsEnabled = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource clientsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientsViewSource")));
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            // clientsViewSource.Source = [универсальный источник данных]
            context.Clients.Load();
            clientsViewSourse.Source = context.Clients.Local;
        }
    }
}
