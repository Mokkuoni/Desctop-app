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
using Todo.Entities;

namespace Todo
{
    /// <summary>
    /// Логика взаимодействия для AddTasks.xaml
    /// </summary>
    public partial class AddTasks : Window
    {
        private string _userName;
        public AddTasks()
        {
            InitializeComponent();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            var task = new TaskModel()
            {
                Title = NameTask.Text,
                TaskDateTime = DateTime.Parse(DateTaskPicker.Text),
                TaskText = Content.Text,
            };
            //task.TaskDateTime.Add(DateTime.Parse(TaskTimePicker.Text).TimeOfDay);
            var main = new Main(_userName);
            main._tasks.Add(task);
            main.Show();
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
