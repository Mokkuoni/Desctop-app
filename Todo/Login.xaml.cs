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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            Manager.CurrectWindow = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Registration = new Registration();
            Registration.Show();
            this.Visibility = Visibility.Collapsed;
            Manager.CurrectWindow.Hide();
            Manager.CurrectWindow.Show();
            Manager.CurrectWindow.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
