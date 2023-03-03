
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
using Todo.Repository;

namespace Todo
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private UserRepository _userRepository;
        public Login()
        {
            InitializeComponent();
            Manager.CurrectWindow = this;
            _userRepository = new UserRepository();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Registration = new Registration();
            Registration.Show();
            this.Visibility = Visibility.Collapsed;
            Manager.CurrectWindow.Hide();
            Manager.CurrectWindow.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var user = _userRepository.Authorize(Password.Text, post.Text);
            if (user == null)
            {
                MessageBox.Show("Данный пользователь не найден");
                return;
            }
            else
            {
                ValidateLogin(this);
                if (Validator.Errors.Any())
                    MessageBox.Show(string.Join(Environment.NewLine, Validator.Errors));
                else
                {
                    var MainEmpty = new MainEmpty(Name);
                    MainEmpty.Show();
                    Manager.CurrectWindow.Hide();
                }
            }

        }

        private void ValidateLogin(Login login)
        {
            Validator.Errors.Clear();
            Validator.ValidateEmail(login.post.Text);
            Validator.ValidatePassword(login.Password.Text);
        }
        
    }
}
