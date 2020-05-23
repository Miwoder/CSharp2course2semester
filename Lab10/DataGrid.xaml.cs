﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Globalization;
using System.Threading;
using Laba7_8.Models;
using Laba7_8.Services;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Laba7_8
{
    /// <summary>
    /// Логика взаимодействия для DataGrid.xaml
    /// </summary>
    public partial class DataGrid : Window
    {
        public bool IsSorted;
        private readonly string Path = $"{Environment.CurrentDirectory}\\TodoDataList.json";
        private ObservableCollection<TodoModel> TodoModelList;
        private JsonSerializer jsonSerializer;
        readonly ResourceDictionary dict1;
        readonly ResourceDictionary dict2;
        private TodoModel tempModel;
        private Stack<TodoModel> UndoStk;
        private Stack<TodoModel> RedoStk;
        public DataGrid()
        {
            dict1 = new ResourceDictionary() { Source = new Uri("Styles/BlueStyle.xaml", UriKind.Relative) };
            dict2 = new ResourceDictionary() { Source = new Uri("Styles/PurpuleStyle.xaml", UriKind.Relative) };
            Resources.MergedDictionaries.Add(dict1);
            UndoStk = new Stack<TodoModel>();
            RedoStk = new Stack<TodoModel>();
            InitializeComponent();
            IsSorted = false;
            jsonSerializer = new JsonSerializer(Path);
            try
            {
                TodoModelList = jsonSerializer.Deserialize();
                ListView.Items.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            ListView.ItemsSource = TodoModelList;
            TodoModelList.CollectionChanged += TodoModelList_ListChanged;
        }
        private bool PriorityFilter(object item)
        {
            if (String.IsNullOrEmpty(Prioritytxt.Text))
                return true;
            else
                return ((item as TodoModel).Priority.IndexOf(Prioritytxt.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private bool NameFilter(object item)
        {
            if (String.IsNullOrEmpty(Nametxt.Text))
                return true;
            else
                return ((item as TodoModel).Name.IndexOf(Nametxt.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private bool DescFilter(object item)
        {
            if (String.IsNullOrEmpty(Descriptiontxt.Text))
                return true;
            else
                return ((item as TodoModel).Description.IndexOf(Descriptiontxt.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void PriorityFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListView.ItemsSource);
            view.Filter = PriorityFilter;
            CollectionViewSource.GetDefaultView(ListView.ItemsSource).Refresh();
        }
        private void NameFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListView.ItemsSource);
            view.Filter = NameFilter;
            CollectionViewSource.GetDefaultView(ListView.ItemsSource).Refresh();
        }
        private void DescFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListView.ItemsSource);
            view.Filter = DescFilter;
            CollectionViewSource.GetDefaultView(ListView.ItemsSource).Refresh();
        }

        private void TodoModelList_ListChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Replace)
            {
                try
                {
                    jsonSerializer.Serialize(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }
        private void BlueStyle(object sender, ExecutedRoutedEventArgs e)
        {
            Resources.MergedDictionaries.Remove(dict2);
            Resources.MergedDictionaries.Add(dict1);
        }
        private void PurpuleStyle(object sender, ExecutedRoutedEventArgs e)
        {
            Resources.MergedDictionaries.Remove(dict1);
            Resources.MergedDictionaries.Add(dict2);
        }
        private bool result = false;
        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (!Name.Text.Trim().Equals(string.Empty) && !Description.Text.Trim().Equals(string.Empty) && !Status.Text.Trim().Equals(string.Empty) && !Priority.Text.Trim().Equals(string.Empty))
            {
                tempModel = new TodoModel() { Status = Status.Text, Priority = Priority.Text, Name = Name.Text, Description = Description.Text };
                UndoStk.Push(tempModel);
                TodoModelList.Add(tempModel);
            }
            Name.Text = "";
            Description.Text = "";
            Status.Text = "";
            Priority.Text = "";
            ListView.Items.Refresh();
            result = true;
        }
        private void DeleteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (ListView.SelectedItem != null)
            {
                MessageBoxResult del = MessageBox.Show("Delete this item?", "Delete?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (del == MessageBoxResult.Yes)
                {
                    tempModel = ListView.SelectedItem as TodoModel;
                    UndoStk.Push(tempModel);
                    TodoModelList.Remove(ListView.SelectedItem as TodoModel);
                }
                ListView.Items.Refresh();
            }
            result = false;
        }
        private void ReplaceCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (ListView.SelectedItem != null)
            {
                EditWindow editWindow = new EditWindow(ListView.SelectedItem as TodoModel, TodoModelList, this.Resources);
                editWindow.Owner = this;
                editWindow.ShowDialog();
            }
        }


        private void Creation_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListView.ItemsSource);
            if (IsSorted)
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription("CreationDate", ListSortDirection.Ascending));
            }
            else
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription("CreationDate", ListSortDirection.Descending));
            }
            IsSorted = !IsSorted;
        }

        private void Priority_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListView.ItemsSource);
            if (IsSorted)
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription("Priority", ListSortDirection.Ascending));
            }
            else
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription("Priority", ListSortDirection.Descending));
            }
            IsSorted = !IsSorted;
        }

        private void Status_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListView.ItemsSource);
            if (IsSorted)
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription("Status", ListSortDirection.Ascending));
            }
            else
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription("Status", ListSortDirection.Descending));
            }
            IsSorted = !IsSorted;
        }

        private void Name_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListView.ItemsSource);
            if (IsSorted)
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            }
            else
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Descending));
            }
            IsSorted = !IsSorted;
        }

        private void Desc_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListView.ItemsSource);
            if (IsSorted)
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription("Description", ListSortDirection.Ascending));
            }
            else
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription("Description", ListSortDirection.Descending));
            }
            IsSorted = !IsSorted;
        }
        bool secret = false;
        private void CustomControl_Click(object sender, RoutedEventArgs e)
        {
            if(secret)
            {
                SecretLabel.Content = "";
            }
            else
            {
                SecretLabel.Content = "-------------------->";
            }
            secret = !secret;
        }

        private void Undo_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            RedoItem.IsEnabled = true;
            if(result)
            {
                if (UndoStk.Count > 0)
                {
                    RedoStk.Push(UndoStk.Peek());
                    TodoModelList.Remove(UndoStk.Pop());
                }
                ListView.Items.Refresh();
            }
            else
            {
                if (UndoStk.Count > 0)
                {
                    RedoStk.Push(UndoStk.Peek());
                    TodoModelList.Add(UndoStk.Pop());
                }
                ListView.Items.Refresh();

            }
        }
        private void Redo_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (result)
            {
                if (RedoStk.Count > 0)
                {
                    TodoModelList.Add(RedoStk.Pop());
                }
                ListView.Items.Refresh();
            }
            else
            {
                if (RedoStk.Count > 0)
                {
                    TodoModelList.Remove(RedoStk.Pop());
                }
                ListView.Items.Refresh();

            }
        }
    }
}
