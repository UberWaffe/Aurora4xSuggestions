using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AddInsInterfacing.AuroraCore.Models
{
    public class ShipComponent
    {
	    public long SDComponentID { get; set; }
        public long GameID { get; set; }
	    public string Name { get; set; }
        public bool? NoScrap { get; set; }
        public bool MilitarySystem { get; set; }
        public bool? ShippingLineSystem { get; set; }
        public bool BeamWeapon { get; set; }
        public long Crew { get; set; }
        public double Size { get; set; }
        public double Cost { get; set; }
        public long? ComponentTypeID { get; set; }
        public double ComponentValue { get; set; }
        public long PowerRequirement { get; set; }
	    public double RechargeRate { get; set; }
        public bool? ElectronicSystem { get; set; }
        public long ElectronicCTD { get; set; }
        public long TrackingSpeed { get; set; }
        public long? SpecialFunction { get; set; }
        public double MaxSensorRange { get; set; }
        public double Resolution { get; set; }
	    public long HTK { get; set; }
        public double FuelUse { get; set; }
        public bool NoMaintFailure { get; set; }
        public bool? HangarReloadOnly { get; set; }
	    public double ExplosionChance { get; set; }
        public long MaxExplosionSize { get; set; }
	    public long DamageOutput { get; set; }
	    public long NumberOfShots { get; set; }
        public double RangeModifier { get; set; }
        public long MaxWeaponRange { get; set; }
	    public bool SpinalWeapon { get; set; }
        public long JumpDistance { get; set; }
	    public long JumpRating { get; set; }
	    public long RateOfFire { get; set; }
	    public long MaxPercentage { get; set; }
	    public double FuelEfficiency { get; set; }
        public bool IgnoreShields { get; set; }
        public bool IgnoreArmour { get; set; }
        public bool? ElectronicOnly { get; set; }
        public double StealthRating { get; set; }
        public double CloakRating { get; set; }
        public bool? Weapon { get; set; }
        public long BGTech1 { get; set; }
        public long BGTech2 { get; set; }
        public long BGTech3 { get; set; }
        public long BGTech4 { get; set; }
        public long BGTech5 { get; set; }
        public long BGTech6 { get; set; }
        public TNMineralsSet TNMineralCost { get; set; }
        public long SingleSystemOnly { get; set; }
	    public bool ShipyardRepairOnly { get; set; }
	    public long ECCM { get; set; }
        public double ArmourRetardation { get; set; }
	    public double WeaponToHitModifier { get; set; }
        public long Prototype { get; set; }
        public long TurretWeaponID { get; set; }

        public ShipComponent()
        {
            this.NoScrap = null;
            this.ShippingLineSystem = null;
            this.ElectronicSystem = null;
            this.HangarReloadOnly = null;
            this.ElectronicOnly = null;
            this.Weapon = null;

            this.ComponentTypeID = null;
            this.SpecialFunction = null;

            this.ComponentValue = 1.0;
            this.WeaponToHitModifier = 1.0;

            this.HTK = 1;
            this.NumberOfShots = 1;

            this.ElectronicCTD = 100;

            this.TNMineralCost = new TNMineralsSet();
        }
    }
}
