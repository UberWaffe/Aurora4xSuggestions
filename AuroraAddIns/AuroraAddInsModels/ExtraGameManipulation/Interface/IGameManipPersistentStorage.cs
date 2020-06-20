using Aurora.AddInsInterfacing.AuroraCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AddInsInterfacing.ExtraGameManipulation.Interface
{
    public interface IGameManipPersistentStorage
    {
        List<TechType> GetAllTechTypesFromStorage();

        List<TechObject> GetAllTechsFromStorage();

        TechObject AddNewTech(TechObject newTech);
    }
}
