using Kurs1125.DTO;
using Kurs1125.Model;
using Kurs1125.Tools;
using Kurs1125.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs1125.ViewModels
{
    class ViewlZakaziVM : BaseVM
    {
        private List<Zakazi> zakazi;
        private int selectedIndex;
        private int viewRowsCount;
        private List<int> pageIndexes;

        public List<Zakazi> Zakazi

        {
            get => Zakazi;
            set
            {
                zakazi = value;
                Signal();
            }
        }
        public CommandVM ViewBack { get; set; }
        public CommandVM ViewForward { get; set; }
        public List<int> PageIndexes
        {
            get => pageIndexes;
            set
            {
                pageIndexes = value;
                Signal();
            }
        }
        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                selectedIndex = value;
                Zakazi = SqlModel.GetInstance().SelectZakaziDB((selectedIndex - 1));
                Signal();
            }
        }
        public int[] RowsCountVariants { get; set; }

        private object viewRowsCount1;

        public object GetViewRowsCount()
        {
            return viewRowsCount1;
        }

        public void SetViewRowsCount(object value)
        {
            viewRowsCount1 = value;
        }

        public int ViewRowsCount
        {
            get => viewRowsCount;
            set
            {
                viewRowsCount = value;
                InitPages();
                Signal();
            }
        }
        public ViewlZakaziVM()
        {
            RowsCountVariants = new int[] { 2, 5, 10 };
            ViewRowsCount = 5;

            ViewBack = new CommandVM(() =>
            {
                if (SelectedIndex > 1)
                    SelectedIndex--;
            });

            ViewForward = new CommandVM(() =>
            {
                if (SelectedIndex < PageIndexes.Last())
                    SelectedIndex++;
            });
        }
        private void InitPages()
        {
            var sqlModel = SqlModel.GetInstance();
            int pageCount = (sqlModel.GetNumRows(typeof(Zakazi)) / ViewRowsCount) + 1;
            PageIndexes = new List<int>(Enumerable.Range(1, pageCount));
            SelectedIndex = 1;
        }

    }
}
