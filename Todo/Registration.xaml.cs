using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Todo.Repository;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Todo
{
    
    public partial class Registration : Window
    {
        private UserRepository _userRepository;
        public Registration()
        {
            InitializeComponent();
            _userRepository = new UserRepository();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Manager.CurrectWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var user = _userRepository.Register(Name.Text, post.Text, Password.Text, PasswordConfirmation.Text);
            if (user == null)
                return;
            else
            {
                MessageBox.Show("Пользователь успешно зарегестрирован!");
                var login = new Login();
                login.Show();
                Close();
            }
        }

        private void ValidateRegistration(Registration registration)
        {
            Validator.Errors.Clear();
            Validator.ValidateName(registration.Name.Text);
            Validator.ValidateEmail(registration.post.Text);
            Validator.ValidatePassword(registration.Password.Text);
            Validator.PasswordsEquality(registration.Password.Text, registration.PasswordConfirmation.Text);
        }
    }
}
