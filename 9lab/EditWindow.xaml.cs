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
using Task = WpfApp1.model.Task;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        ObservableCollection<Task> collection;
        //TodoModel newmodel;
        private DateTime? TempDate;
        private string TempStatus;
        private string TempPriority;
        private string TempName;
        private string TempDescription;
        public EditWindow(Task item, ObservableCollection<Task> col)
        {
            InitializeComponent();
            collection = col;
            DataContext = item;
            TempDate = item.CreationDate;
            TempStatus = item.Status;
            TempPriority = item.Priority;
            TempName = item.Name;
            TempDescription = item.Description;

            NameTB.Text = item.Name;
            DescrTB.Text = item.Description;
            PriorityTB.Text = item.Priority;
            StatusTB.Text = item.Status;
            calendar1.SelectedDate = item.CreationDate;
            collection.Remove(item);
        }

        private void Edit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (NameTB.Text.Trim().Equals(string.Empty) && DescrTB.Text.Trim().Equals(string.Empty) && StatusTB.Text.Trim().Equals(string.Empty) &&
                PriorityTB.Text.Trim().Equals(string.Empty))
                MessageBox.Show("Заполните все поля!");
            else
            {
                DialogResult = true;
                collection.Add(new Task() { CreationDate = calendar1.SelectedDate, Status = StatusTB.Text, Priority = PriorityTB.Text, Name = NameTB.Text, Description = DescrTB.Text });
                Close();
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            bool result = DialogResult ?? false;
            if (!result)
            {
                collection.Add(new Task() { CreationDate = TempDate, Status = TempStatus, Priority = TempPriority, Name = TempName, Description = TempDescription });
            }
        }

        private void ComboBox_SelectionChanged(object sender, RoutedEventArgs e) { }
    }
}
