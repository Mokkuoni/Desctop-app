﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Todo.XXX;
using Todo.Entities;
using System.Collections.ObjectModel;

namespace Todo
{
    public partial class Main : Window
    {
        private ObservableCollection<TasksCategory> _tasksCategory;
        private List<SolidColorBrush> _colors;
        private History _history;
        public ObservableCollection<TaskModel> _tasks { get; set; }
        

        public Main(string userName)
        {
            InitializeComponent();
            Manager.CurrectWindow = this;
            UserNameTextBlock.Text = userName;
            _history = new History(UserNameTextBlock.Text);

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

            _tasks = new ObservableCollection<TaskModel>();
            TasksList.ItemsSource = _tasks;
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var task = (TaskModel)TasksList.SelectedItem;
            _tasks.Remove(task);
        }

        private void DoneButton_OnClick(object sender, RoutedEventArgs e)
        {
            var task = (TaskModel)TasksList.SelectedItem;
            _tasks.Remove(task);
            task.IsDone = true;
            task.CheckboxColor = new SolidColorBrush(Colors.Red);
            _tasks.Add(task);
            _history.Tasks.Add(task);
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

        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            _history.Show();
            Manager.CurrectWindow.Hide();
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            var addTasks = new AddTasks();
            addTasks.Show();
            Manager.CurrectWindow.Hide();
        }

    }
}

