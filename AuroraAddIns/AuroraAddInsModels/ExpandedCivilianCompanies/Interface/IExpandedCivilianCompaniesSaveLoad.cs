using Aurora.AddInsInterfacing.ExpandedCivilianCompanies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.AddInsInterfacing.ExpandedCivilianCompanies.Interface
{
    public interface IExpandedCivilianCompaniesSaveLoad
    {
        void SaveCivilianCompanyFinances(CivilianCompanyFinances companyFinances);
        CivilianCompanyFinances LoadCivilianCompanyFinances();
    }
}
