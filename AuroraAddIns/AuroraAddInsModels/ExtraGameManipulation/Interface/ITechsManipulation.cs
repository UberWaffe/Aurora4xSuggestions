using Aurora.AddInsInterfacing.ExtraGameManipulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.AddInsInterfacing.ExtraGameManipulation.Interface
{
    public interface ITechsManipulation
    {
        int GetStandardTechCostForLevel(int techLevel);

        TechObject NewGlobalTech(string name, string description, TechType techType, int techLevel, string componentName = "",
            double info1 = 0.0, double info2 = 0.0, double info3 = 0.0, double info4 = 0.0,
            string prerequisite1 = null, string prerequisite2 = null);

        TechObject NewGlobalTech(TechObject theNewTech);

        List<TechObject> GetAllTechs();

        bool CheckIfTechExists(string techName);

        TechObject GetTechByName(string techName);

    }
}
