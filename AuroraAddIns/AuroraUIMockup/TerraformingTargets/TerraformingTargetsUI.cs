using Aurora.AddIns.TerraformingTargets;
using Aurora.AddIns.TerraformingTargets.Models;
using AuroraUIMockup.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AuroraUIMockup.TerraformingTargets
{
    public partial class TerraformingTargetsUI : Form
    {
        private PopulationTerraformingCapacityGetter _capGetter;
        private OrbitBodyTerraformDataHandler _systemBodyData;
        private TerraformGameState _terraformGameState;
        private TerraformingManager _terraformManager;

        private const long _systemBodyId = 1000;
        private const long _populationId = 100;

        private bool _fullSentencesDisplayActive = false;

        public TerraformingTargetsUI()
        {
            InitializeComponent();
            _capGetter = new PopulationTerraformingCapacityGetter();
            _systemBodyData = new OrbitBodyTerraformDataHandler();
            _terraformManager = new TerraformingManager(_capGetter);
            _terraformGameState = new TerraformGameState(_systemBodyData, _terraformManager);
        }

        private void button_SetTarget_Click(object sender, EventArgs e)
        {
            
        }

        private void button_DeleteTarget_Click(object sender, EventArgs e)
        {

        }

        private void ToggleFullSentences()
        {
            _fullSentencesDisplayActive = !_fullSentencesDisplayActive;
            this.listView_TerraformTargets.Refresh();
        }




        /* =====================================================================================================================================================
         *  SIMULATION UI CODE FOLLOWS
         */
        private void button_SimulateGameTick_Click(object sender, EventArgs e)
        {
            _terraformGameState.DoGameUpdate();
        }

        private void button_ToggleSentences_Click(object sender, EventArgs e)
        {
            ToggleFullSentences();
        }

        private void textBox_SimulateSeconds_TextChanged(object sender, EventArgs e)
        {
            _systemBodyData.SecondsSinceLastProcessToSimulate = TextConversionsHelper.ConvertTextToLong(textBox_SimulateSeconds.Text);
        }
    }
}
