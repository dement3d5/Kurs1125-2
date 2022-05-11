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
        private List<ViewZakaziVM> ZakazirBySelectedlZakazi;
        private List<Zakazi> zakazis;

        public List<Zakazi> Zakazis { get => zakazis; set { zakazis = value; Signal(); } }
        public Zakazi SelectedZakazis
        {
            get => SelectedZakazis;
            set
            {
                SelectedZakazis = value;
                SqlModel ZakaziBySelectedlZakazi = SqlModel.GetInstance();
                Signal();
            }
        }

        public ViewZakaziVM()
        {
            Zakazis = SqlModel.GetInstance().Zakazi(0);
        }

    }

}
