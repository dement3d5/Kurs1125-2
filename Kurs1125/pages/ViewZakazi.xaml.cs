using Kurs1125.DTO;
using Kurs1125.Model;
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
            DataContext = new ViewZakaziVM();

        }

      
        private void Button_Clik_4(object sender, RoutedEventArgs e)
        {
            EditZakazi z = new EditZakazi();
            z.Show();
        }




    }
}

