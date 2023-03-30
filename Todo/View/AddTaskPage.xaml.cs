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


namespace Todo.View
{
    /// <summary>
    /// Логика взаимодействия для AddTaskPage.xaml
    /// </summary>
    public partial class AddTaskPage : Page
    {
        private readonly string _userName;
        public AddTaskPage(string userName)
        {
            InitializeComponent();
            _userName = userName;
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var messageBoxResult = MessageBox.Show("Вы действительно хотите отменить действия?", "Отмена действий", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var inheritResult = MessageBox.Show("Назад?", "Возврат на предыдущую страницу", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (inheritResult == MessageBoxResult.Yes)
                    Manager.MainFrame?.GoBack();
            }
            else
            {
                NameTask.Text = "";
                DateTaskPicker.Text = "";
                TaskTimePicker.Text = "";
                Content.Text = "";
                Category.Text = "";
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTask.Text) || string.IsNullOrEmpty(DateTaskPicker.Text) || string.IsNullOrEmpty(TaskTimePicker.Text) || string.IsNullOrEmpty(Content.Text) || string.IsNullOrEmpty(Category.Text))
            {
                MessageBox.Show("Все поля обязательны для заполнения", "Предупреждение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var task = new TaskModel()
            {
                Title = NameTask.Text,
                TaskDateTime = DateTime.Parse(DateTaskPicker.Text),
                DisplayTime = DateTime.Parse(TaskTimePicker.Text).ToString("hh:mm tt"),
                TaskText = Content.Text,
            };
            task.TaskDateTime.Add(DateTime.Parse(TaskTimePicker.Text).TimeOfDay);
            var main = new MainPage(_userName);
            main.Tasks.Add(task);
            Manager.MainFrame?.Navigate(main);
        }
    }
}
