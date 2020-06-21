using Aurora.AddInsInterfacing.AuroraCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.AddInsInterfacing.AuroraCore.Models
{
    public class TechObject
    {
        public int? TechSystemID { get; set; }
        public string Name { get; set; }
        public string ComponentName { get; set; }
        public int CategoryID { get; set; }
        public int RaceID { get; set; }
        public AuroraTechTypes TechType { get; set; }
        public bool NoTechScan { get; set; }
        public bool RuinOnly { get; set; }
        public int Prerequisite1 { get; set; }
        public int Prerequisite2 { get; set; }
        public bool StartingSystem { get; set; }
        public bool ConventionalSystem { get; set; }
        public int DevelopCost { get; set; }
        public double AdditionalInfo { get; set; }
        public double AdditionalInfo2 { get; set; }
        public double AdditionalInfo3 { get; set; }
        public double AdditionalInfo4 { get; set; }
        public string TechDescription { get; set; }
        public int GameID { get; set; }    
        
        public TechObject()
        {
            GameID = 0;
            AdditionalInfo = 0.0;
            AdditionalInfo2 = 0.0;
            AdditionalInfo3 = 0.0;
            AdditionalInfo4 = 0.0;
            TechSystemID = null;
        }

        public TechObject Duplicate(string newName)
        {
            return new TechObject()
            {
                TechSystemID = null,
                Name = newName,
                ComponentName = this.ComponentName,
                CategoryID = this.CategoryID,
                RaceID = this.RaceID,
                TechType = this.TechType,
                NoTechScan = this.NoTechScan,
                RuinOnly = this.RuinOnly,
                Prerequisite1 = this.Prerequisite1,
                Prerequisite2 = this.Prerequisite2,
                StartingSystem = this.StartingSystem,
                ConventionalSystem = this.ConventionalSystem,
                DevelopCost = this.DevelopCost,
                AdditionalInfo = this.AdditionalInfo,
                AdditionalInfo2 = this.AdditionalInfo2,
                AdditionalInfo3 = this.AdditionalInfo3,
                AdditionalInfo4 = this.AdditionalInfo4,
                TechDescription = this.TechDescription,
                GameID = this.GameID
        };
        }
    }
}