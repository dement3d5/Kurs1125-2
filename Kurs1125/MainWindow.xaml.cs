using Kurs1125.pages;
using MySql.Data.MySqlClient;
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
using System.Windows.Navigation;
using Kurs1125.ViewModel;
using Kurs1125.Tools;
using System.ComponentModel;

namespace Kurs1125
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CurrentPageControl currentPageControl;

        public MainWindow()
        {
            InitializeComponent();

            MySqlConnection connection = MySqlDB.GetDB().GetConnection();
            try
            {
                MessageBox.Show("Openning connection...");
                connection.Open();
                MessageBox.Show("connection sucsessfull.");
                connection.Close();
            }

            catch (Exception e)
            {
                MessageBox.Show("Error" + e.Message);
            }

            currentPageControl = new MainVM().Returrn_CurrentPageControl();




        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewZakazi v = new ViewZakazi();
            v.Show();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            EditVoditel o = new EditVoditel(currentPageControl);
            o.Show();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

 
       




    }
}
