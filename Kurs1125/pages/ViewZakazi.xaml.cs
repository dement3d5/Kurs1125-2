using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        }

       

    private void Button_Clik_4(object sender, RoutedEventArgs e)
        {
            EditZakazi z = new EditZakazi();
            z.Show();
        }


      
    }

}
