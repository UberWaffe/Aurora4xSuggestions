using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuroraUIMockup.TerraformingTargets
{
    public class ComponentTypeElement : DropdownListBaseUiElement
    {
        public ComponentTypeElement(ComboBox linkedElement) : base(linkedElement)
        {

        }

        public override void UpdateDisplayList(List<ListViewItem> newList)
        {
            base.UpdateDisplayList(newList);
            throw new NotImplementedException();
        }

        public override void OnSelect(ListViewItem selectedItem)
        {
            throw new NotImplementedException();
        }
    }
}
