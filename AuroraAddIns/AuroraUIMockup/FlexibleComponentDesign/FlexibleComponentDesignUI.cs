using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Aurora.AddInsInterfacing.AuroraCore.Models;
using Aurora.AddInsInterfacing.AuroraCore.Enums;

namespace AuroraUIMockup.FlexibleComponentDesign
{
    public partial class FlexibleComponentDesignUI : Form
    {
        private List<TechInfoButtonUiElement> _techInfoButtons;

        // First input location: 12, 91

        public FlexibleComponentDesignUI()
        {
            InitializeComponent();
            InitializeTechInfoButtons();
            LinkTechInfoButtonElements();
        }

        public void InitializeTechInfoButtons()
        {
            this._techInfoButtons = new List<TechInfoButtonUiElement>();
        }

        public void LinkTechInfoButtonElements()
        {
            TechInfoButtonUiElement newTechInfoButton;

            newTechInfoButton = new TechInfoButtonUiElement(this.infoButton_MilitaryOrCommercial);
            newTechInfoButton.LinkTech(new TechObject() { TechType = AuroraTechTypes.EnginePower });
            this._techInfoButtons.Add(newTechInfoButton);
            

        }
    }
}
