using Aurora.AddInsInterfacing.AuroraCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.AddInsInterfacing.ExtraGameManipulation.Interface
{
    public interface IExtraGameManipulation
    {
        List<TechType> GetAllTechTypes();
    }
}
