using Kurs1125.DTO;
using Kurs1125.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

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
            //Items = createZakazi();
            //DataContext = this;
            DataContext = new ViewZakaziVM();
        }



        private void Button_Clik_4(object sender, RoutedEventArgs e)
        {
            EditZakazi z = new EditZakazi();
            z.Show();
        }



        //public ObservableCollection<ViewZakazi> createZakazi()
        //{
        //    string query = "INSERT * FROM zakazi";
        //    ObservableCollection<ViewZakazi> result = new ObservableCollection<ViewZakazi>();
        //    var mySqlDB = MySqlDB.GetDB();
        //    if (mySqlDB.OpenConnection())
        //    {
        //        using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.conn))
        //        using (MySqlDataReader dr = mc.ExecuteReader())
        //        {
        //            while (dr.Read())
        //            {
        //                result.Add(new Zakazi{
        //                {
        //                    Dtincome = dr.GetDateTime("dtincome"),
        //                    Dtdestination = dr.GetDateTime("dtdestination"),
        //                    Pod = dr.GetString("place of departure"),
        //                    Destination = dr.GetString("destination"),
        //                    Price = dr.GetString("price")

        //                });

        //            }

        //        }
        //        mySqlDB.CloseConnection();

        //    }
        //    return result;



        //}

    }


}

