using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

namespace SQLWPF
{
    /// <summary>
    /// Interaction logic for ModeratorWindow.xaml
    /// </summary>
    public partial class ModeratorWindow : Window
    {
        private int offsetNumber = 0;
        private int currentPage = 1;
        public ModeratorWindow()
        {
            InitializeComponent();
            UpdateTablesCombo();
            UpdateTableView();
        }

        private int getNumberOfRows()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["mmorpgdb"].ConnectionString))
            {
                int count = 0;
                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = $"SELECT COUNT(*) FROM [{(string)TablesCombo.SelectedValue}]"
                };
                connection.Open();
                count = (int)command.ExecuteScalar();
                connection.Close();
                return count;
            }
        }

        private void UpdateTableView()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["mmorpgdb"].ConnectionString);
            connection.Open();
            
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = $"SELECT * FROM [{(string)TablesCombo.SelectedValue}] order by 1 OFFSET {offsetNumber} rows fetch next 5 rows only"
            };
            TablesView.ItemsSource = command.ExecuteReader();
         
            TableName.Text = (string)TablesCombo.SelectedValue;
        }

        /// <summary>
        /// Updating list of tables names in ComboBox "TablesCombo"
        /// </summary>
        private void UpdateTablesCombo()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["mmorpgdb"].ConnectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException)
                {
                    return;
                }
                string get_all_tables_sql = @"select TABLE_NAME from INFORMATION_SCHEMA.VIEWS";
                SqlCommand command = new SqlCommand(get_all_tables_sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TablesCombo.Items.Add((string)reader[0]);
                }
                TablesCombo.SelectedValue = TablesCombo.Items[0];
                connection.Close();
            }
        }

        private void BanUser()
        {

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["mmorpgdb"].ConnectionString))
            {
                try
                {
                    connection.Open();

                }
                catch (SqlException)
                {
                    return;
                }

                try
                {

                    var selectedCellInfo = TablesView.SelectedCells[0];
                    var selectedCellValue = (selectedCellInfo.Column.GetCellContent(selectedCellInfo.Item) as TextBlock).Text;

                    SqlCommand banSelectedUser = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = $"UPDATE Accounts SET isBanned = 'true' where id = {Int32.Parse(selectedCellValue)}"
                    };
                    if ((string)TablesCombo.SelectedValue == "Accounts view")
                    {
                        banSelectedUser.ExecuteNonQuery();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    return;
                }
                catch (FormatException)
                {
                    return;
                }

                connection.Close();
            }
        }
        private void UnBanUser()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["mmorpgdb"].ConnectionString))
            {
                try
                {
                    connection.Open();

                }
                catch (SqlException)
                {
                    return;
                }

                try
                {

                    var selectedCellInfo = TablesView.SelectedCells[0];
                    var selectedCellValue = (selectedCellInfo.Column.GetCellContent(selectedCellInfo.Item) as TextBlock).Text;

                    SqlCommand UnBanSelectedUser = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = $"UPDATE Accounts SET isBanned = NULL where id = {Int32.Parse(selectedCellValue)}"
                    };
                    if ((string)TablesCombo.SelectedValue == "Accounts view")
                    {
                        UnBanSelectedUser.ExecuteNonQuery();
                    }


                }
                catch (ArgumentOutOfRangeException)
                {
                    return;
                }
                catch (FormatException)
                {
                    return;
                }

                connection.Close();
            }

        }

        /// <summary>
        /// Change DataGrid "TablesView" ItemsSource when changing selected table name in ComboBox "TablesCombo"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TablesCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            offsetNumber = 0;
            currentPage = 1;
            CurrentPageLabel.Content = currentPage.ToString();
            UpdateTableView();
        }

        private void BanButton_Click(object sender, RoutedEventArgs e)
        {
            BanUser();
            UpdateTableView();
        }

        private void UnbanButton_Click(object sender, RoutedEventArgs e)
        {
            UnBanUser();
            UpdateTableView();
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            if (offsetNumber < getNumberOfRows() - 5)
            {
                offsetNumber += 5;
                currentPage += 1;
                CurrentPageLabel.Content = (currentPage).ToString();
            }
            UpdateTableView();
        }

        private void PrevPage_Click(object sender, RoutedEventArgs e)
        {
            if (offsetNumber > 0)
            {
                offsetNumber -= 5;
                currentPage -= 1;
                CurrentPageLabel.Content = (currentPage).ToString();
            }
            UpdateTableView();
        }
    }
}
