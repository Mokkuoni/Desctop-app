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
using Todo.XXX;
using System.Collections.ObjectModel;
using Todo.Entities;

namespace Todo.View
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private ObservableCollection<TasksCategory> _tasksCategory;
        private List<SolidColorBrush> _colors;
        private HistoryPage _historyPage;

        public ObservableCollection<TaskModel> Tasks { get; set; }
        public MainPage(string userName)
        {
            InitializeComponent();
            UserNameTextBlock.Text = userName;
            _historyPage = new HistoryPage(UserNameTextBlock.Text);

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

            Tasks = new ObservableCollection<TaskModel>();
            TasksList.ItemsSource = Tasks;
        }
        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var task = (TaskModel)TasksList.SelectedItem;
            Tasks.Remove(task);
        }

        private void DoneButton_OnClick(object sender, RoutedEventArgs e)
        {
            var task = (TaskModel)TasksList.SelectedItem;
            Tasks.Remove(task);
            task.IsDone = true;
            task.CheckboxColor = new SolidColorBrush(Colors.Red);
            Tasks.Add(task);
            _historyPage.Tasks.Add(task);
            TaskFullContent.Visibility = Visibility.Hidden;
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

        private void AddTaskButton_Click(object sender, RoutedEventArgs e) => Manager.MainFrame?.Navigate(new AddTaskPage(UserNameTextBlock.Text));

        private void HistoryButton_Click(object sender, RoutedEventArgs e) => Manager.MainFrame?.Navigate(_historyPage);
    }
}
