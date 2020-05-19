using Aurora.AddIns.TerraformingTargets.Models;
using AuroraUIMockup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.ComboBox;

namespace AuroraUIMockup.Helpers
{
    public static class UiModelMapper
    {
        public static List<ListViewItem> GenerateCurrentElementsList(OrbitBodyWithCurrentElementInfo dataToShow)
        {
            var result = new List<ListViewItem>();

            if (dataToShow != null && dataToShow.CurrentElements != null)
            {
                foreach (var element in dataToShow.CurrentElements.theElements)
                {
                    var textToDisplay = $"{GetGasName(element.elementId)} with a total of {element.amount} Atm";

                    result.Add(new ListViewItem(textToDisplay)
                    {
                        Tag = element
                    });
                }
            }

            result = result.OrderBy(item => item.Text).ToList();

            return result;
        }

        public static List<ListViewItem> GenerateTargetsList(OrbitBodyWithTerraformInfo dataToShow)
        {
            var result = new List<ListViewItem>();

            if (dataToShow != null && dataToShow.DesiredTargets != null)
            {
                foreach (var element in dataToShow.DesiredTargets.theElements)
                {
                    var textToDisplay = $"{GetGasName(element.elementId)} with a target of {element.amount} Atm";

                    result.Add(new ListViewItem(textToDisplay)
                    {
                        Tag = element
                    });
                }
            }

            result = result.OrderBy(item => item.Text).ToList();

            return result;
        }

        public static string GetGasName(int elementId)
        {
            var allGasses = GetAllGasses();
            return allGasses.First(gas => gas.id == elementId).name;
        }

        public static List<TotallyTheRealAuroraGasModel> GetAllGasses()
        {
            var result = new List<TotallyTheRealAuroraGasModel>();
            result.Add(new TotallyTheRealAuroraGasModel(1, "Oxygen"));
            result.Add(new TotallyTheRealAuroraGasModel(2, "Nitrogen"));
            result.Add(new TotallyTheRealAuroraGasModel(3, "Smoke"));
            result.Add(new TotallyTheRealAuroraGasModel(4, "Hellfire"));
            result.Add(new TotallyTheRealAuroraGasModel(5, "Rainbow Vaporware"));

            return result;
        }
    }
}
