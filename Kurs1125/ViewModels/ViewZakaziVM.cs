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

        public List<Zakazi> Zakazi { get; set; }
        public Zakazi SelectedlZakazi
        {
            get => SelectedlZakazi;
            set
            {
                SelectedlZakazi = value;
                SqlModel ZakaziBySelectedlZakazi = SqlModel.GetInstance();
                Signal();
            }
        }


    }

}
