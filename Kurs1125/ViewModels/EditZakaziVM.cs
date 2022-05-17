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
    public class EditZakaziVM 
    {
        public Zakazi EditZakazi { get; set; }
        public CommandVM SaveZakazi { get; set; }
        private CurrentPageControl currentPageControl;
        public DateTime Dtincome { get; set; }
        public DateTime Dtdestination { get; set; }

        public EditZakaziVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditZakazi = new Zakazi();
            Dtincome = DateTime.Now;
            Dtdestination = DateTime.Now;
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
                currentPageControl.Back();
            });
        }


    }
}
