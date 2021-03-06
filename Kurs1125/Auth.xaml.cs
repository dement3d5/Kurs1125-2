using Kurs1125.Tools;
using Kurs1125.ViewModels;
using MySql.Data.MySqlClient;
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
        private CurrentPageControl currentPageControl;

        public Auth()
        {
            InitializeComponent();
 

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var loginUser = TextBox_login.Text;
            var passUser = TextBox_password.Text;
            var db = MySqlDB.GetDB();
            bool enter = false;
            if (db.OpenConnection())
            {
                string querystring = $"select id, login, password from dispet where login ='{loginUser}' and password = '{passUser}'";
                using (MySqlCommand command = new MySqlCommand(querystring, MySqlDB.GetDB().GetConnection()))
                {
                    using (var dr = command.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            enter = dr.GetInt32("id") != 0;
                        }
                    }
                }
                db.CloseConnection();
            }
            if (enter)
            {
                MessageBox.Show("вы успешно вошли!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow main = new MainWindow();
                this.Close();
                main.Show();
                
            }
            else
                MessageBox.Show("Такого аккаунта не существет!", "Аккаунта не существет!!", MessageBoxButton.OK, MessageBoxImage.Warning);
            

        }


        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Regauth i = new Regauth(currentPageControl);
            this.Close();
            i.Show();
           



        }
    }
}