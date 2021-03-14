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

namespace registration_clients
{
    /// <summary>
    /// Логика взаимодействия для Hello_User_.xaml
    /// </summary>
    public partial class Hello_User_ : Page
    {

        Registration_UsersEntities context = new Registration_UsersEntities();
        CollectionViewSource scheduleViewSourse;
        public Hello_User_()
        {
            InitializeComponent();
        }
    }
}
