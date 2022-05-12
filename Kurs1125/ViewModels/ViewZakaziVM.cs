using Kurs1125.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kurs1125.DTO;
using Kurs1125.Model;

namespace Kurs1125.ViewModels
{
    public class ViewZakaziVM : BaseVM
    {
        private Zakazi selectedZakazi;
        private List<Zakazi> zakazisBySelectedList;

        public List<Zakazi> Zakazis { get; set; }
        public Zakazi SelectedZakazi
        {
            get => selectedZakazi;
            set
            {
                selectedZakazi = value;
                ZakazisBySelectedList = SqlModel.GetInstance().SelectZakazisByList();
                Signal();
            }
        }
        public List<Zakazi> ZakazisBySelectedList
        {
            get => zakazisBySelectedList;
            set
            {
                zakazisBySelectedList = value;
                Signal();
            }
        }

    }

}
