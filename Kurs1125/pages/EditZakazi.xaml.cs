using Kurs1125.Tools;
using Kurs1125.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    /// Логика взаимодействия для EditZakazi.xaml
    /// </summary>
    public partial class EditZakazi : Window
    {
        private CurrentPageControl currentPage;

        public EditZakazi(CurrentPageControl currentPageControl)
        {
            InitializeComponent();
            DataContext = new EditZakaziVM(currentPageControl);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewZakazi j = new ViewZakazi(currentPage);
            j.Show();
            this.Close();
        }
    }


}

