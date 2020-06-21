using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuroraUIMockup.TerraformingTargets
{
    public abstract class InfoButtonBaseElement
    {
        private Button _linkedElement;


        public InfoButtonBaseElement(Button linkedElement)
        {
            this._linkedElement = linkedElement;
            this._linkedElement.Click += new System.EventHandler(this.OnClick);
        }

        public virtual void OnClick(object sender, EventArgs e)
        {

        }
    }
}
