using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kurs1125.Tools
{
    public class CurrentPageControl
    {
        Stack<Page> pages = new Stack<Page>();

        public Page Page { get; internal set; }
        public event EventHandler PageChanged;

        internal void SetPage(Page optionPage)
        {
            if (Page != null)
                pages.Push(Page);
            Page = optionPage;
            PageChanged?.Invoke(this, new EventArgs());
        }

        internal void Back()
        {
            if (pages.Count > 0)
                Page = pages.Pop();
            else
                Page = null;
            PageChanged?.Invoke(this, new EventArgs());
        }
    }
}
