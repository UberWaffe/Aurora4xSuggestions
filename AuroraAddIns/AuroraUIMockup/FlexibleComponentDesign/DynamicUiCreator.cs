using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuroraUIMockup.FlexibleComponentDesign
{
    public static class DynamicUiCreator
    {
        public static Size InfoButtonSize = new Size(45, 23);
        public static Size ComboBoxSize = new Size(270, 21);


        public static Button CreateInfoButton(Panel containingPanel, int x, int y, string contextText, int tabIndex)
        {
            var newButton = new Button();
            newButton.Size = InfoButtonSize;
            newButton.Location = new Point(x, y);
            newButton.Text = "Info";

            newButton.AccessibleRole = AccessibleRole.PushButton;
            newButton.AccessibleName = $"Info about {contextText}";
            newButton.AccessibleDescription = "Open a popup with additional information.";
            newButton.TabIndex = tabIndex;

            containingPanel.Controls.Add(newButton);
            newButton.Parent = containingPanel;

            return newButton;
        }

        public static ComboBox CreateComboBox(Panel containingPanel, int x, int y, string contextText, int tabIndex)
        {
            var newDropdownList = new ComboBox();
            newDropdownList.Size = ComboBoxSize;
            newDropdownList.Location = new Point(x, y);
            
            newDropdownList.AccessibleRole = AccessibleRole.ComboBox;
            newDropdownList.AccessibleName = $"Choice for {contextText}";
            newDropdownList.AccessibleDescription = "Choose what to use in the component design.";
            newDropdownList.TabIndex = tabIndex;

            containingPanel.Controls.Add(newDropdownList);
            newDropdownList.Parent = containingPanel;

            return newDropdownList;
        }
    }
}
