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
        private List<Zakazi> zakazisBySelectedList;
        public List<Zakazi> ZakazisBySelectedList
        {
            get => zakazisBySelectedList;
            set
            {
                zakazisBySelectedList = value;
                Signal();
            }
        }
        public ViewZakaziVM()
        {
            zakazisBySelectedList = SqlModel.GetInstance().SelectZakazisByList();
        }

    }

}
