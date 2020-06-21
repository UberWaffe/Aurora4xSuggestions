using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuroraUIMockup.FlexibleComponentDesign
{
    public partial class TextInfoPopup : Form
    {
        public TextInfoPopup()
        {
            InitializeComponent();
        }

        public void SetDisplayTest(string textToDisplay)
        {
            this.text_TechDescription.Text = textToDisplay;
        }
    }
}
