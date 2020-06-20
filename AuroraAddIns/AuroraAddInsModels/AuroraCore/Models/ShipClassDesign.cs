using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AddInsInterfacing.AuroraCore.Models
{
    public class ShipClassDesign
    {
	    public long ShipClassID { get; set; }
	    public string ClassName { get; set; }
	    public long? GameID { get; set; }
	    public long? RaceID { get; set; }
        public long ActiveSensorStrength { get; set; }
        public long ArmourThickness { get; set; }
        public long ArmourWidth { get; set; }
	    public double BaseFailureChance { get; set; }
        public long CargoCapacity { get; set; }
	    public double? ClassCrossSection { get; set; }
        public double ClassThermal { get; set; }
        public long Collier { get; set; }
        public long ColonistCapacity { get; set; }
        public long CommanderPriority { get; set; }
	    public bool? MilitaryEngines { get; set; }
	    public long ControlRating { get; set; }
        public long ConscriptOnly { get; set; }
	    public double Cost { get; set; }
        public long Crew { get; set; }
	    public double CrewQuartersHS { get; set; }
        public long DCRating { get; set; }
        public long ECM { get; set; }
        public long EMSensorStrength { get; set; }
        public long EnginePower { get; set; }
        public long ESMaxDACRoll { get; set; }
	    public bool? FighterClass { get; set; }
        public bool Commercial { get; set; }
        public long FuelCapacity { get; set; }
	    public double FuelEfficiency { get; set; }
        public long FuelTanker { get; set; }
        public long GeoSurvey { get; set; }
        public long GravSurvey { get; set; }
        public long Harvesters { get; set; }
        public long HullDescriptionID { get; set; }
        public long JGConstructionTime { get; set; }
        public long JumpDistance { get; set; }
        public long JumpRating { get; set; }
	    public bool Locked { get; set; }
	    public double MagazineCapacity { get; set; }
        public long MaxChance { get; set; }
        public long MaxDACRoll { get; set; }
        public long MaxSpeed { get; set; }
        public long MaintModules { get; set; }
        public long MinimumFuel { get; set; }
        public long MiningModules { get; set; }
        public long NameThemeID { get; set; }
        public long NoArmour { get; set; }
        public string Notes { get; set; }
        public long MainFunction { get; set; }
        public long Obsolete { get; set; }
        public long OtherRaceClassID { get; set; }
	    public double ParasiteCapacity { get; set; }
        public long PassiveSensorStrength { get; set; }
	    public double PlannedDeployment { get; set; }
	    public bool PreTNT { get; set; }
	    public double? ProtectionValue { get; set; }
	    public long RankRequired { get; set; }
        public long ReactorPower { get; set; }
	    public bool? RecreationalModule { get; set; }
        public long RefuelPriority { get; set; }
	    public long RefuellingRate { get; set; }
        public long RefuellingHub { get; set; }
        public long RequiredPower { get; set; }
        public long SalvageRate { get; set; }
	    public double SensorReduction { get; set; }
        public long ShieldStrength { get; set; }
	    public double Size { get; set; }
        public long STSTractor { get; set; }
        public long SupplyShip { get; set; }
        public long Terraformers { get; set; }
        public long TotalNumber { get; set; }
        public long CargoShuttleStrength { get; set; }
        public long TroopCapacity { get; set; }
        public long WorkerCapacity { get; set; }
        public long MaintPriority { get; set; }
        public bool CommercialHangar { get; set; }
        public long ClassShippingLineID { get; set; }
	    public bool MoraleCheckRequired { get; set; }
        public long OrdnanceTransferHub { get; set; }
        public long OrdnanceTransferRate { get; set; }
        public long TroopTransportType { get; set; }
        public long AutomatedDesignID { get; set; }
        public long MinimumSupplies { get; set; }
        public long ResupplyPriority { get; set; }
        public long MaintSupplies { get; set; }
        public long ELINTRating { get; set; }
        public long DiplomacyRating { get; set; }
        public long CommercialJumpDrive { get; set; }
        public long BioEnergyCapacity { get; set; }
        public long SeniorCO { get; set; }
        public long RandomShipNameFromTheme { get; set; }
	    public string PrefixName { get; set; }
        public string SuffixName { get; set; }
        public List<ShipClassComponent> ClassComponents { get; set; }


        public ShipClassDesign()
        {
            this.GameID = null;
            this.RaceID = null;
            this.BaseFailureChance = 1.0;
            this.ClassCrossSection = null;
            this.ControlRating = 1;
            this.FighterClass = null;
            this.HullDescriptionID = 25;
            this.MaxSpeed = 1;
            this.MilitaryEngines = null;
            this.PassiveSensorStrength = 1;
            this.PlannedDeployment = 3.0;
            this.ProtectionValue = null;
            this.RecreationalModule = null;
            this.RefuellingRate = 10000;
            this.SensorReduction = 1.0;

            this.ClassComponents = new List<ShipClassComponent>();
        }
    }
}
