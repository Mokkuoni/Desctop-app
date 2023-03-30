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
using Todo.Repository;

namespace Todo.View
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private readonly UserRepository _userRepository;
        public LoginPage()
        {
            InitializeComponent();
            _userRepository = new UserRepository();
        }

        private void Registration_Click(object sender, RoutedEventArgs e) => Manager.MainFrame?.Navigate(new RegistrationPage());

        private void Sign_Click(object sender, RoutedEventArgs e)
        {
            var user = _userRepository.Authorize(Password.Text, post.Text);
            if (user == null)
            {
                MessageBox.Show("Данный пользователь не найден");
                return;
            }
            else
            {
                if (!user.Tasks.Any())
                    Manager.MainFrame?.Navigate(new MainEmptyPage(user.Name));
                else
                    Manager.MainFrame?.Navigate(new MainPage(user.Name));
            }
        }
    }
}
