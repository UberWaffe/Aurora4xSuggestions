using AuroraUIMockup.FlexibleComponentDesign;
using AuroraUIMockup.TerraformingTargets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AuroraUIMockup
{
    public partial class MainTestMenu : Form
    {
        public MainTestMenu()
        {
            InitializeComponent();
        }

        private void MainTestMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var terraformMockup = new TerraformingTargetsUI();
            terraformMockup.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var componentDesignMockup = new FlexibleComponentDesignUI();
            componentDesignMockup.Show();
        }
    }
}
