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
    public partial class MainEmpty : Window
    {
        private string userName;
        public MainEmpty(string Name)
        {
            InitializeComponent();
            userName = Name;
            username.Text = userName;
        }

        private void Go_Click(object sender, RoutedEventArgs e)
        {
            Manager.CurrectWindow.Close();
            var addTasks = new AddTasks();
            addTasks.Show();
        }
    }
}
