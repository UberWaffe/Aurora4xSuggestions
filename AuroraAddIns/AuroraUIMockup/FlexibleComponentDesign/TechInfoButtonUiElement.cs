using Aurora.AddInsInterfacing.AuroraCore.Models;
using AuroraUIMockup.FlexibleComponentDesign;
using AuroraUIMockup.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuroraUIMockup.FlexibleComponentDesign
{
    public class TechInfoButtonUiElement : InfoButtonBaseElement
    {
        private TechObject _linkedTech;
        private TextInfoPopup _infoPopup;

        public TechInfoButtonUiElement(Button linkedElement) : base(linkedElement)
        {
            
        }

        public void LinkTech(TechObject techToLink)
        {
            this._linkedTech = techToLink;
        }

        public override void OnClick(object sender, EventArgs e)
        {
            this._infoPopup = new TextInfoPopup();

            this._infoPopup.SetDisplayTest(this.GetTextToDisplay());

            this._infoPopup.Show();
            this._infoPopup.FormClosed += new FormClosedEventHandler(this.DisposePopup);
        }

        private string GetTextToDisplay()
        {
            var effectsOfTheTechText = String.Empty;
            var effectsList = TechAnalyzerHelper.EffectsOfTheTech(this._linkedTech);
            if (effectsList.Any())
            {
                effectsOfTheTechText = Environment.NewLine;
                foreach (var effectText in effectsList)
                {
                    effectsOfTheTechText += $"{Environment.NewLine}{effectText}";
                }
            }

            var resultText = $"{this._linkedTech.Name}{Environment.NewLine}{this._linkedTech.TechDescription}{effectsOfTheTechText}";
            return resultText;
        }

        private void DisposePopup(object sender, EventArgs e)
        {
            this._infoPopup.Dispose();
        }
    }
}
