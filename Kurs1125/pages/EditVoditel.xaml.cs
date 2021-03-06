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

namespace Kurs1125.pages
{
    /// <summary>
    /// Логика взаимодействия для EditVoditel.xaml
    /// </summary>
    public partial class EditVoditel : Window
    {
        public EditVoditel(CurrentPageControl currentPageControl)
        {
            InitializeComponent();
            DataContext = new EditVoditelVM(currentPageControl);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
