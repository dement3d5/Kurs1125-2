using System;
using System.Collections.Generic;
using System.Data;
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

namespace Kurs1125
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var loginUser = TextBox_login.Text;
            var passUser = TextBox_password.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select login, password from mydb where login ='{loginUser}' and password = '{passUser}'";
            SqlCommand command = new SqlCommand(querystring, MySqlDB.GetDBConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                MessageBox.Show("вы успешно вошли!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow main = new MainWindow();
                this.Hide();
                main.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Такого аккаунта не существет!", "Аккаунта не существет!!", MessageBoxButton.OK, MessageBoxImage.Warning);

        }
    }
}
