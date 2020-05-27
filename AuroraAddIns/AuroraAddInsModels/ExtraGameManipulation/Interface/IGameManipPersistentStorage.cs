﻿using Aurora.AddInsInterfacing.ExtraGameManipulation.Models;
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
    }
}