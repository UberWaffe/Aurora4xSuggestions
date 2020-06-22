using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuroraUIMockup.FlexibleComponentDesign
{
    public abstract class DropdownListBaseUiElement
    {
        private ComboBox _linkedElement;
        public List<ListViewItem> displayList { get; set; }


        public DropdownListBaseUiElement(ComboBox linkedElement)
        {
            this._linkedElement = linkedElement;
            this.displayList = new List<ListViewItem>();
        }

        public virtual void UpdateDisplayList(List<ListViewItem> newList)
        {
            this.displayList = newList;
            this._linkedElement.Refresh();
        }

        public abstract void OnSelect(ListViewItem selectedItem);
    }
}
