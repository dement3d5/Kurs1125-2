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
    class EditVoditelVM : BaseVM
    {
        public Voditel EditVoditel { get; set; }
        public CommandVM SaveVoditel { get; set; }
        private CurrentPageControl currentPageControl;


        public EditVoditelVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditVoditel = new Voditel();
            InitCommand();
        }
        public EditVoditelVM(Voditel editVoditel, CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditVoditel = editVoditel;
            InitCommand();
        }

        private void InitCommand()
        {
            SaveVoditel = new CommandVM(() => {
                var model = SqlModel.GetInstance();
                if (EditVoditel.ID == 0)
                    model.Insert(EditVoditel);
                else
                    model.Update(EditVoditel);
            });
        }
    }
}
