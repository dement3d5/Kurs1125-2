using Kurs1125.Tools;
using Kurs1125.ViewModels;
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

namespace Kurs1125
{
    /// <summary>
    /// Interaction logic for Regauth.xaml
    /// </summary>
    public partial class Regauth : Window
    {
        public Regauth(CurrentPageControl currentPageControl)
        {
            InitializeComponent();
            DataContext = new RegVM(currentPageControl);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            this.Close();
            auth.Show();
        }
    }

}
