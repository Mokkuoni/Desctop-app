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
using Todo.Entities;
using Todo.XXX;
using System.Collections.ObjectModel;

namespace Todo.View
{
    /// <summary>
    /// Логика взаимодействия для HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : Page
    {
        private readonly ObservableCollection<TasksCategory> _tasksCategory;
        private readonly List<SolidColorBrush> _colors;
        public ObservableCollection<TaskModel> Tasks;
        public HistoryPage(string userName)
        {
            Tasks = new();
            InitializeComponent();
            UserNameTextBlock.Text = userName;

            _colors = new List<SolidColorBrush>
            {
                new SolidColorBrush(Colors.Orange),
                new SolidColorBrush(Colors.Green),
                new SolidColorBrush(Colors.Blue),
                new SolidColorBrush(Colors.Purple)
            };

            _tasksCategory = new ObservableCollection<TasksCategory>
            {
                new TasksCategory {Title = "Дом", TextColor = _colors[1]},
                new TasksCategory {Title = "Работа", TextColor = _colors[0]},
                new TasksCategory {Title = "Учёба", TextColor = _colors[2]},
                new TasksCategory {Title = "Отдых", TextColor = _colors[3]},
            };
            MenuList.ItemsSource = _tasksCategory;
            TasksList.ItemsSource = Tasks;
        }
        private void TasksList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TasksList.SelectedItem is TaskModel task)
            {
                TitleTextBlock.Text = task.Title;
                TimeTextBlock.Text = task.TaskDateTime.TimeOfDay.ToString();
                DateTextBlock.Text = task.TaskDateTime.Date.ToString();
                ContentTextBlock.Text = task.TaskText;
                TaskFullContent.Visibility = Visibility.Visible;
            }
            else
                TaskFullContent.Visibility = Visibility.Hidden;
        }

        private void TasksButton_Click(object sender, RoutedEventArgs e) => Manager.MainFrame?.Navigate(new MainPage(UserNameTextBlock.Text));
    }
}
