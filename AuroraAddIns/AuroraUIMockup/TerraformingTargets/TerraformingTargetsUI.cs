﻿using Aurora.AddIns.TerraformingTargets;
using Aurora.AddInsInterfacing.TerraformingTargets.Models;
using AuroraUIMockup.Helpers;
using AuroraUIMockup.Models;
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

        private const int _systemBodyId = 1000;
        private const int _populationId = 100;

        private bool _fullSentencesDisplayActive = false;

        private const int _defaultSecondsForUpdate = 3600 * 24 * 5;
        private const double _defaultPerAnnumAtm = 0.02;

        public TerraformingTargetsUI()
        {
            InitializeComponent();
            _capGetter = new PopulationTerraformingCapacityGetter();
            _systemBodyData = new OrbitBodyTerraformDataHandler();
            _terraformManager = new TerraformingManager(_capGetter);
            _terraformGameState = new TerraformGameState(_systemBodyData, _terraformManager);

            this.textBox_SimulateSeconds.Text = _defaultSecondsForUpdate.ToString();
            _systemBodyData.SecondsSinceLastProcessToSimulate = _defaultSecondsForUpdate;

            this.textBox_SimulateAtmPerAnnum.Text = _defaultPerAnnumAtm.ToString();
            _capGetter.ValueToReturnForPerAnnumTerraformCapacity = _defaultPerAnnumAtm;

            Update_listView_SimulateCurrentElements();
            this.comboBox_ChooseTargetElement.DisplayMember = "name";
            this.comboBox_ChooseTargetElement.ValueMember = "id";
            this.comboBox_ChooseTargetElement.DataSource = new BindingSource(UiModelMapper.GetAllGassesNames(), null);

            this.listView_TerraformTargets.Columns.Clear();
            this.listView_TerraformTargets.Columns.Add("Gas");
            this.listView_TerraformTargets.Columns.Add("Target Atm");

            this.listView_SimulateCurrentElements.Columns.Clear();
            this.listView_SimulateCurrentElements.Columns.Add("Gas");
            this.listView_SimulateCurrentElements.Columns.Add("Current Atm");

            textBox_TargetAmount.Text = "0.0";
        }

        private void button_SetTarget_Click(object sender, EventArgs e)
        {
            try
            {
                var targetAmount = TextConversionsHelper.ConvertTextToDouble(textBox_TargetAmount.Text);
                var targetId = GetSelectedTargetElementFromComboBox();
                if (targetId.HasValue == false)
                {
                    return;
                }

                _terraformGameState.SetTargetFor(_systemBodyId, _populationId, targetId.Value, targetAmount);
                _systemBodyData.CurrentPopulationTerraformTargets = _terraformGameState.GetTargetsForAll();
                UpdateTargetList();
            }
            catch (FormatException)
            {
                textBox_TargetAmount.Text = "0.0";
            }
        }

        private void button_DeleteTarget_Click(object sender, EventArgs e)
        {
            var targetId = GetSelectedTargetElementFromComboBox();
            if (targetId.HasValue == false)
            {
                return;
            }

            _terraformGameState.DeleteTargetFor(_systemBodyId, _populationId, targetId.Value);
            UpdateTargetList();
        }

        private void ToggleFullSentences()
        {
            _fullSentencesDisplayActive = !_fullSentencesDisplayActive;
            this.listView_TerraformTargets.Refresh();
        }

        private int? GetSelectedTargetElement()
        {
            var selectedElement = (ListViewItem)comboBox_ChooseTargetElement.SelectedItem;
            if (selectedElement == null)
            {
                return null;
            }

            var selectedObject = (TotallyTheRealAuroraGasModel)selectedElement.Tag;

            return selectedObject.id;
        }

        private int? GetSelectedTargetElementFromComboBox()
        {
            var selectedText = (string)comboBox_ChooseTargetElement.SelectedItem;
            if (selectedText == null)
            {
                return null;
            }

            var gasId = UiModelMapper.GetGasId(selectedText);

            return gasId;
        }

        private void UpdateTargetList()
        {
            var targetOrbitBodyInfo = _terraformGameState.GetTargetsFor(_systemBodyId, _populationId);
            this.listView_TerraformTargets.Items.Clear();
            this.listView_TerraformTargets.Items.AddRange(UiModelMapper.GenerateTargetsList(targetOrbitBodyInfo).ToArray());

            this.listView_TerraformTargets.Refresh();
        }

        /* =====================================================================================================================================================
         *  SIMULATION UI CODE FOLLOWS
         */
        private void button_SimulateGameTick_Click(object sender, EventArgs e)
        {
            _terraformGameState.DoGameUpdate();
            UpdateTargetList();
            Update_listView_SimulateCurrentElements();
        }

        private void button_ToggleSentences_Click(object sender, EventArgs e)
        {
            ToggleFullSentences();
        }

        private void textBox_SimulateSeconds_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _systemBodyData.SecondsSinceLastProcessToSimulate = TextConversionsHelper.ConvertTextToLong(textBox_SimulateSeconds.Text);
            }
            catch(FormatException)
            {
                textBox_SimulateSeconds.Text = _defaultSecondsForUpdate.ToString();
            }
        }

        private void textBox_SimulateAtmPerAnnum_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _capGetter.ValueToReturnForPerAnnumTerraformCapacity = TextConversionsHelper.ConvertTextToDouble(textBox_SimulateAtmPerAnnum.Text);
            }
            catch (FormatException)
            {
                textBox_SimulateAtmPerAnnum.Text = _defaultPerAnnumAtm.ToString();
            }
        }

        private void Update_listView_SimulateCurrentElements()
        {
            listView_SimulateCurrentElements.Items.Clear();
            listView_SimulateCurrentElements.Items.AddRange(UiModelMapper.GenerateCurrentElementsList(_terraformGameState.GetCurrentElementsFor(_systemBodyId)).ToArray());

        }
    }
}
