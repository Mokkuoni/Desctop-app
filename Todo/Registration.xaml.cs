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

namespace Todo
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Manager.CurrectWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ValidateRegistration(this);
            if (Validator.Errors.Any())
                MessageBox.Show(string.Join(Environment.NewLine, Validator.Errors));
            else
            {
                var MainEmpty = new MainEmpty();
                MainEmpty.Show();
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
