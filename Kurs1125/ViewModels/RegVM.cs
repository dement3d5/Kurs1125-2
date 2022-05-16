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
    class RegVM : BaseVM
    {
        public Dispet EditDispet { get; set; }
        public CommandVM SaveDispet { get; set; }
        private CurrentPageControl currentPageControl;


        public RegVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditDispet = new Dispet();
            Init();
        }
        public RegVM(Dispet editDispet, CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditDispet = editDispet;
            Init();
        }

        private void Init()
        {
            SaveDispet = new CommandVM(() => {
                var model = SqlModel.GetInstance();
                if (EditDispet.ID == 0)
                    model.Insert(EditDispet);
                else
                    model.Update(EditDispet);
            });
        }
    }
}
