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

namespace Todo.View
{
    /// <summary>
    /// Логика взаимодействия для MainEmptyPage.xaml
    /// </summary>
    public partial class MainEmptyPage : Page
    {
        public MainEmptyPage(string userName)
        {
            InitializeComponent();
            username.Text = userName;
        }
        private void CreateTask_Click(object sender, RoutedEventArgs e) => Manager.MainFrame?.Navigate(new AddTaskPage(username.Text));
    }
}
