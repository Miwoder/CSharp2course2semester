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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.Collections.ObjectModel;

namespace WpfApp1   
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public MainWindow()
        {
            InitializeComponent();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "select * from Person order by id";

                Persons.Clear();
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Person person = new Person { id = reader.GetInt32(0), login = reader.GetString(1), password = reader.GetString(2) };

                        Persons.Add(person);
                        PersonsG.Items.Add(person);
                    }
                }
                reader.Close();
                connection.Close();
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql2 = "select * from PersonInfo order by Nick";

                Persons.Clear();
                connection.Open();
                SqlCommand command2 = new SqlCommand(sql2, connection);

                SqlDataReader reader = command2.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //PersonInfo personInfo = new PersonInfo { id = reader.GetInt32(0), name = reader.GetString(1), surname = reader.GetString(2), age = reader.GetInt32(3) };
                        PersonInfo personInfo = new PersonInfo { name = reader.GetString(0), surname = reader.GetString(1), age = reader.GetInt32(2) };

                        PersonsInfoG.Items.Add(personInfo);
                    }
                }
                reader.Close();
                connection.Close();
            }

        }
        

        private void CreateUserBT(object sender, RoutedEventArgs e)
        {
            try
            {
                string sqlExpression = "INSERT INTO Person (login, password) VALUES ('" + LoginBox.Text + "', '" + PassBox.Text + "')";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    MessageBox.Show("Добавлено объектов: " + number);
                }
            }           
            catch(Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void CreatePersonInfoBT(object sender, RoutedEventArgs e)
        {
            //string sqlExpression = "INSERT INTO PersonInfo (Name, Surname, age) VALUES ('" + NameBox.Text + "', '" + SurnameBox.Text + "', '" + AgeBox.Text + "')";
            try { 
            string sqlExpression = "INSERT INTO PersonInfo (Nick, Surname, age) VALUES ('" + NameBox.Text + "', '" + SurnameBox.Text + "', '" + AgeBox.Text + "')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                MessageBox.Show("Добавлено объектов: " + number);
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        DataSet myDataSet;
        public ObservableCollection<Person> Persons { get; set; } = new ObservableCollection<Person>();

        private void RefreshBT(object sender, RoutedEventArgs e)
        {
            
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void DelIdBT(object sender, RoutedEventArgs e)
        {
            try
            {
                string sqlExpression = "Use Laba; Delete from Person Where login='" + DelIDBox.Text + "'; DELETE FROM PersonInfo Where Nick='" + DelIDBox.Text + "'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    MessageBox.Show("Удалено объектов: " + number);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void UpdatePersonInfoId(object sender, RoutedEventArgs e)
        {
            string sqlExpression = "Use Laba; Update PersonInfo Set Surname='" + UpdateSurname.Text + "' , age='" + UpdateAge.Text + "'  Where Nick='" + UpdateName.Text + "'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                MessageBox.Show("Изменено объектов: " + number);
            }
        }

        private void TranBT(object sender, RoutedEventArgs e)
        {
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    SqlTransaction transaction = connection.BeginTransaction();

            //    SqlCommand command = connection.CreateCommand();
            //    command.Transaction = transaction;

            //    try
            //    {
            //        // выполняем две отдельные команды
            //        command.CommandText = "INSERT INTO PersonInfo (Nick, Surname, age) VALUES ('AAA', 'AAAS', '11')";
            //        command.ExecuteNonQuery();
            //        command.CommandText = "INSERT INTO PersonInfo (Nick, Surname, age) VALUES ('BBB', 'BBBS', '22')";
            //        command.ExecuteNonQuery();

            //        // подтверждаем транзакцию
            //        transaction.Commit();

            //    }
            //    catch (Exception ex)
            //    {
            //        transaction.Rollback();
            //    }
            //}
            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd1 = new SqlCommand(
    "INSERT INTO PersonInfo (Nick, Surname, age) VALUES ('ААААААА', 'AAAS', '11')", con);

            SqlCommand cmd2 = new SqlCommand(
    "INSERT INTO PersonInfo (Nick, Surname, age) VALUES ('ВВВВВВВ', 'AAASЫ', '11')", con);
            SqlTransaction transaction = null;

            try
            {
                // Открыть соединение и создать транзакцию
                con.Open();
                transaction = con.BeginTransaction();

                // Включить в транзакцию две команды
                cmd1.Transaction = transaction;
                cmd2.Transaction = transaction;

                // Выполнить обе команды
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

                // Зафиксировать транзакцию
                transaction.Commit();
            }
            catch
            {
                // В случае ошибки отменить транзакцию
                transaction.Rollback();
            }
            finally
            {
                // В любом случае закрыть соединение с базой данных
                con.Close();
            }
        }
    }
}
