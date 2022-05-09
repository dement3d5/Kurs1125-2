using Kurs1125.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Kurs1125.pages
{
    /// <summary>
    /// Логика взаимодействия для ViewZakazi.xaml
    /// </summary>
    public partial class ViewZakazi : Window
    {
        public ViewZakazi()
        {
            InitializeComponent();
            //        Items = createZakazi();
            //        DataContext = this;
        }
            //    }
            //    public event PropertyChangedEventHandler PropertyChanged;
            //    public void Signal([CallerMemberName] string property = null)
            //    {
            //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
            //    }
            //    public ObservableCollection<ViewZakazi> createZakazi()
            //    {
            //        string query = "INSERT * FROM zakazi";
            //        ObservableCollection<ViewZakazi> result = new ObservableCollection<ViewZakazi>();
            //        var MySqlDB = SqlModel.GetDB();
            //        if (MySqlDB.OpenConnection())
            //        {
            //            using (MySqlCommand mc = new MySqlCommand(query, MySqlDB.conn))
            //            using (MySqlDataReader dr = mc.ExecuteReader())
            //            {
            //                while (dr.Read())
            //                {
            //                    result.Add(new ViewZakazi
            //                    {
            //                        dtincome = dr.GetDateTime("dtincome"),
            //                        dtdestination = dr.GetDateTime("dtdestination"),
            //                        pod = dr.GetString("place of departure"),
            //                        destination = dr.GetString("destination"),
            //                        price = dr.GetString("price")

            //                    });

            //                }

            //            }
            //            MySqlDB.CloseConnection();   

            //        }
            //        return result;


            //    }


            private void Button_Clik_4(object sender, RoutedEventArgs e)
            {
                EditZakazi z = new EditZakazi();
                z.Show();
            }

       





    }

}
