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
using System.Reflection;
using System.Resources;
using WpfApp1.services;
using WpfApp1.model;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Task = WpfApp1.model.Task;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Task> TaskList;
        private readonly string Path = $"{Environment.CurrentDirectory}\\TaskList.json";
        private JsonSerializer jsonSerializer;
        public bool IsSorted;

        public MainWindow()
        {
            InitializeComponent();
            ENGBT.Background = Brushes.Aqua;

            this.Cursor = new Cursor(@"C:\Users\bestb\OneDrive\Рабочий стол\ООП\7_8.WPF\additionals\1.0.1\standby-blue.ani");


            jsonSerializer = new JsonSerializer(Path);
            try
            {
                TaskList = jsonSerializer.Deserialize();
                lv.Items.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            lv.ItemsSource = TaskList;
            TaskList.CollectionChanged += TaskList_ListChanged;
        }


        //Memory
        private void TaskList_ListChanged(object sender, NotifyCollectionChangedEventArgs e)
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

        


        
        /// Date
        public void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = calendar1.SelectedDate;
        }



        /// Languages
        private void ENGBT_Click(object sender, RoutedEventArgs e)
        {
            this.Resources = new ResourceDictionary() { Source = new Uri(@"C:\Users\bestb\OneDrive\Рабочий стол\ООП\7_8.WPF\WpfApp1\Lang\langENG.xaml") };
            RUSBT.Background = Brushes.WhiteSmoke;
            ENGBT.Background = Brushes.Aqua;

        }

        private void RUSBT_Click(object sender, RoutedEventArgs e)
        {
            this.Resources = new ResourceDictionary() { Source = new Uri(@"C:\Users\bestb\OneDrive\Рабочий стол\ООП\7_8.WPF\WpfApp1\Lang\langRU.xaml") };
            RUSBT.Background = Brushes.Aqua;
            ENGBT.Background = Brushes.WhiteSmoke;
        }


        /// Add new task
        private void AddTask_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (!NameTB.Text.Trim().Equals(string.Empty) && !DescrTB.Text.Trim().Equals(string.Empty) && !StatusTB.Text.Trim().Equals(string.Empty) &&
                !PriorityTB.Text.Trim().Equals(string.Empty))
            {
                TaskList.Add(new model.Task()
                {
                    Status = StatusTB.Text,
                    Priority = PriorityTB.Text,
                    Name = NameTB.Text,
                    Description = DescrTB.Text,
                    CreationDate = calendar1.SelectedDate
                });
            }
            else
                MessageBox.Show("Заполните все поля!");
            NameTB.Text = "";
            DescrTB.Text = "";
            StatusTB.Text = "";
            PriorityTB.Text = "";
            lv.Items.Refresh();

        } 

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        { }


        private void EditTask_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (lv.SelectedItem != null)
            {
                EditWindow editWindow = new EditWindow(lv.SelectedItem as Task, TaskList);
                editWindow.Owner = this;
                editWindow.ShowDialog();
            }
        }

        private void DeleteTask_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (lv.SelectedItem != null)
            {
                MessageBoxResult del = MessageBox.Show("Delete this item?", "Delete?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (del == MessageBoxResult.Yes)
                {
                    TaskList.Remove(lv.SelectedItem as Task);
                }
                lv.Items.Refresh();
            }
        }



        /////////// Sort by...
        private void Name_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lv.ItemsSource);
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
        private void Priority_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lv.ItemsSource);
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
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lv.ItemsSource);
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

        private void Date_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lv.ItemsSource);
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

        private void Description_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lv.ItemsSource);
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

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
    }
}
