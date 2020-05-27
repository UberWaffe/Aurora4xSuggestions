using Aurora.AddInsInterfacing.ExtraGameManipulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.AddInsInterfacing.ExtraGameManipulation.Interface
{
    public interface IExtraGameManipulation
    {
        int GetStandardTechCostForLevel(int techLevel);

        TechObject NewTech(string name, string description, TechType techType, int techLevel);

        List<TechType> GetAllTechTypes();
    }
}
