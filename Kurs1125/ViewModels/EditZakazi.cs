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
    class EditZakaziVM : BaseVM
    {
        public List<Zakazi> Zakazis { get; set; }

        public Zakazi EditZakazi { get; set; }
        public CommandVM SaveZakazi { get; set; }
        private CurrentPageControl currentPageControl;


        public EditZakaziVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditZakazi = new Zakazi();
            InitCommand();
        }
        public EditZakaziVM(Zakazi editZakazi, CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditZakazi = editZakazi;
            InitCommand();
        }

        private void InitCommand()
        {
            SaveZakazi = new CommandVM(() => {
                var model = SqlModel.GetInstance();
                if (EditZakazi.ID == 0)
                    model.Insert(EditZakazi);
                else
                    model.Update(EditZakazi);
            });
        }
    }
}
