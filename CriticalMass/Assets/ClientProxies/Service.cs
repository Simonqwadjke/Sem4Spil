﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelLayer
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Map", Namespace="http://schemas.datacontract.org/2004/07/ModelLayer")]
    public partial class Map : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private ModelLayer.Buildings.Building[] BuildindsField;
        
        private ModelLayer.User OwnerField;
        
        private ModelLayer.Units.Group[] UnitsField;
        
        private int ironField;
        
        private int woodField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ModelLayer.Buildings.Building[] Buildinds
        {
            get
            {
                return this.BuildindsField;
            }
            set
            {
                this.BuildindsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ModelLayer.User Owner
        {
            get
            {
                return this.OwnerField;
            }
            set
            {
                this.OwnerField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ModelLayer.Units.Group[] Units
        {
            get
            {
                return this.UnitsField;
            }
            set
            {
                this.UnitsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int iron
        {
            get
            {
                return this.ironField;
            }
            set
            {
                this.ironField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int wood
        {
            get
            {
                return this.woodField;
            }
            set
            {
                this.woodField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/ModelLayer")]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private ModelLayer.Battle[] BattlesField;
        
        private System.DateTime BirthDateField;
        
        private string CountryField;
        
        private string EmailField;
        
        private ModelLayer.Units.Group[] GarisonField;
        
        private ModelLayer.User[] InvadersField;
        
        private System.DateTime LastLoginField;
        
        private int LevelField;
        
        private ModelLayer.Map MapField;
        
        private string NameField;
        
        private string PasswordField;
        
        private int RankingField;
        
        private string SessionField;
        
        private ModelLayer.Upgrades UpgradesField;
        
        private int UserIDField;
        
        private string UsernameField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ModelLayer.Battle[] Battles
        {
            get
            {
                return this.BattlesField;
            }
            set
            {
                this.BattlesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime BirthDate
        {
            get
            {
                return this.BirthDateField;
            }
            set
            {
                this.BirthDateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Country
        {
            get
            {
                return this.CountryField;
            }
            set
            {
                this.CountryField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email
        {
            get
            {
                return this.EmailField;
            }
            set
            {
                this.EmailField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ModelLayer.Units.Group[] Garison
        {
            get
            {
                return this.GarisonField;
            }
            set
            {
                this.GarisonField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ModelLayer.User[] Invaders
        {
            get
            {
                return this.InvadersField;
            }
            set
            {
                this.InvadersField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime LastLogin
        {
            get
            {
                return this.LastLoginField;
            }
            set
            {
                this.LastLoginField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Level
        {
            get
            {
                return this.LevelField;
            }
            set
            {
                this.LevelField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ModelLayer.Map Map
        {
            get
            {
                return this.MapField;
            }
            set
            {
                this.MapField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password
        {
            get
            {
                return this.PasswordField;
            }
            set
            {
                this.PasswordField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Ranking
        {
            get
            {
                return this.RankingField;
            }
            set
            {
                this.RankingField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Session
        {
            get
            {
                return this.SessionField;
            }
            set
            {
                this.SessionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ModelLayer.Upgrades Upgrades
        {
            get
            {
                return this.UpgradesField;
            }
            set
            {
                this.UpgradesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserID
        {
            get
            {
                return this.UserIDField;
            }
            set
            {
                this.UserIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username
        {
            get
            {
                return this.UsernameField;
            }
            set
            {
                this.UsernameField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Location", Namespace="http://schemas.datacontract.org/2004/07/ModelLayer")]
    public partial class Location : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private float XField;
        
        private float YField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float X
        {
            get
            {
                return this.XField;
            }
            set
            {
                this.XField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float Y
        {
            get
            {
                return this.YField;
            }
            set
            {
                this.YField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Size", Namespace="http://schemas.datacontract.org/2004/07/ModelLayer")]
    public partial class Size : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private float HeightField;
        
        private float WidthField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float Height
        {
            get
            {
                return this.HeightField;
            }
            set
            {
                this.HeightField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float Width
        {
            get
            {
                return this.WidthField;
            }
            set
            {
                this.WidthField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Upgrades", Namespace="http://schemas.datacontract.org/2004/07/ModelLayer")]
    public partial class Upgrades : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int ArmorLevelField;
        
        private int DamageLevelField;
        
        private int RecourseLevelField;
        
        private int RiflemanLevelField;
        
        private int TankLevelField;
        
        private int armorGrowthField;
        
        private int damageGrowthField;
        
        private int recourseGrowthField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ArmorLevel
        {
            get
            {
                return this.ArmorLevelField;
            }
            set
            {
                this.ArmorLevelField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int DamageLevel
        {
            get
            {
                return this.DamageLevelField;
            }
            set
            {
                this.DamageLevelField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RecourseLevel
        {
            get
            {
                return this.RecourseLevelField;
            }
            set
            {
                this.RecourseLevelField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RiflemanLevel
        {
            get
            {
                return this.RiflemanLevelField;
            }
            set
            {
                this.RiflemanLevelField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TankLevel
        {
            get
            {
                return this.TankLevelField;
            }
            set
            {
                this.TankLevelField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int armorGrowth
        {
            get
            {
                return this.armorGrowthField;
            }
            set
            {
                this.armorGrowthField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int damageGrowth
        {
            get
            {
                return this.damageGrowthField;
            }
            set
            {
                this.damageGrowthField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int recourseGrowth
        {
            get
            {
                return this.recourseGrowthField;
            }
            set
            {
                this.recourseGrowthField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Battle", Namespace="http://schemas.datacontract.org/2004/07/ModelLayer")]
    public partial class Battle : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int AttackerIDField;
        
        private int DefenderIDField;
        
        private string OutcomeField;
        
        private int PlunderedIronField;
        
        private int PlunderedWoodField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AttackerID
        {
            get
            {
                return this.AttackerIDField;
            }
            set
            {
                this.AttackerIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int DefenderID
        {
            get
            {
                return this.DefenderIDField;
            }
            set
            {
                this.DefenderIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Outcome
        {
            get
            {
                return this.OutcomeField;
            }
            set
            {
                this.OutcomeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PlunderedIron
        {
            get
            {
                return this.PlunderedIronField;
            }
            set
            {
                this.PlunderedIronField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PlunderedWood
        {
            get
            {
                return this.PlunderedWoodField;
            }
            set
            {
                this.PlunderedWoodField = value;
            }
        }
    }
}
namespace ModelLayer.Buildings
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Building", Namespace="http://schemas.datacontract.org/2004/07/ModelLayer.Buildings")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ModelLayer.Buildings.Passive.HeadQuarters))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ModelLayer.Buildings.Passive.Labratory))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ModelLayer.Buildings.Passive.Resouce))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ModelLayer.Buildings.Passive.IronMine))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ModelLayer.Buildings.Passive.SawMill))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ModelLayer.Buildings.Defense.Defensive))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ModelLayer.Buildings.Defense.FlameThrower))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ModelLayer.Buildings.Defense.Cannon))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ModelLayer.Buildings.Defense.GatlingTurret))]
    public partial class Building : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int ArmorField;
        
        private int HitPointsField;
        
        private int LevelField;
        
        private ModelLayer.Location LocationField;
        
        private ModelLayer.Size SizeField;
        
        private int UnitSizeField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Armor
        {
            get
            {
                return this.ArmorField;
            }
            set
            {
                this.ArmorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int HitPoints
        {
            get
            {
                return this.HitPointsField;
            }
            set
            {
                this.HitPointsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Level
        {
            get
            {
                return this.LevelField;
            }
            set
            {
                this.LevelField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ModelLayer.Location Location
        {
            get
            {
                return this.LocationField;
            }
            set
            {
                this.LocationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ModelLayer.Size Size
        {
            get
            {
                return this.SizeField;
            }
            set
            {
                this.SizeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UnitSize
        {
            get
            {
                return this.UnitSizeField;
            }
            set
            {
                this.UnitSizeField = value;
            }
        }
    }
}
namespace ModelLayer.Units
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Group", Namespace="http://schemas.datacontract.org/2004/07/ModelLayer.Units")]
    public partial class Group : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int unitCapField;
        
        private ModelLayer.Units.Unit[] unitsField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int unitCap
        {
            get
            {
                return this.unitCapField;
            }
            set
            {
                this.unitCapField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ModelLayer.Units.Unit[] units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Unit", Namespace="http://schemas.datacontract.org/2004/07/ModelLayer.Units")]
    public partial class Unit : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int ArmorField;
        
        private int AttackSpeedField;
        
        private int DamageField;
        
        private int HitPointsField;
        
        private ModelLayer.Location LoactionField;
        
        private double RangeField;
        
        private double SpeedField;
        
        private int UnitSizeField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Armor
        {
            get
            {
                return this.ArmorField;
            }
            set
            {
                this.ArmorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AttackSpeed
        {
            get
            {
                return this.AttackSpeedField;
            }
            set
            {
                this.AttackSpeedField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Damage
        {
            get
            {
                return this.DamageField;
            }
            set
            {
                this.DamageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int HitPoints
        {
            get
            {
                return this.HitPointsField;
            }
            set
            {
                this.HitPointsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ModelLayer.Location Loaction
        {
            get
            {
                return this.LoactionField;
            }
            set
            {
                this.LoactionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Range
        {
            get
            {
                return this.RangeField;
            }
            set
            {
                this.RangeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Speed
        {
            get
            {
                return this.SpeedField;
            }
            set
            {
                this.SpeedField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UnitSize
        {
            get
            {
                return this.UnitSizeField;
            }
            set
            {
                this.UnitSizeField = value;
            }
        }
    }
}
namespace ModelLayer.Buildings.Passive
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="HeadQuarters", Namespace="http://schemas.datacontract.org/2004/07/ModelLayer.Buildings.Passive")]
    public partial class HeadQuarters : ModelLayer.Buildings.Building
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Labratory", Namespace="http://schemas.datacontract.org/2004/07/ModelLayer.Buildings.Passive")]
    public partial class Labratory : ModelLayer.Buildings.Building
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Resouce", Namespace="http://schemas.datacontract.org/2004/07/ModelLayer.Buildings.Passive")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ModelLayer.Buildings.Passive.IronMine))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ModelLayer.Buildings.Passive.SawMill))]
    public partial class Resouce : ModelLayer.Buildings.Building
    {
        
        private int prodductionHourField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int prodductionHour
        {
            get
            {
                return this.prodductionHourField;
            }
            set
            {
                this.prodductionHourField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="IronMine", Namespace="http://schemas.datacontract.org/2004/07/ModelLayer.Buildings.Passive")]
    public partial class IronMine : ModelLayer.Buildings.Passive.Resouce
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SawMill", Namespace="http://schemas.datacontract.org/2004/07/ModelLayer.Buildings.Passive")]
    public partial class SawMill : ModelLayer.Buildings.Passive.Resouce
    {
    }
}
namespace ModelLayer.Buildings.Defense
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Defensive", Namespace="http://schemas.datacontract.org/2004/07/ModelLayer.Buildings.Defense")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ModelLayer.Buildings.Defense.FlameThrower))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ModelLayer.Buildings.Defense.Cannon))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ModelLayer.Buildings.Defense.GatlingTurret))]
    public partial class Defensive : ModelLayer.Buildings.Building
    {
        
        private int AttackSpeedField;
        
        private int DamageField;
        
        private double RangeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AttackSpeed
        {
            get
            {
                return this.AttackSpeedField;
            }
            set
            {
                this.AttackSpeedField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Damage
        {
            get
            {
                return this.DamageField;
            }
            set
            {
                this.DamageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Range
        {
            get
            {
                return this.RangeField;
            }
            set
            {
                this.RangeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FlameThrower", Namespace="http://schemas.datacontract.org/2004/07/ModelLayer.Buildings.Defense")]
    public partial class FlameThrower : ModelLayer.Buildings.Defense.Defensive
    {
        
        private int BurnDamageField;
        
        private int BurnTimeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int BurnDamage
        {
            get
            {
                return this.BurnDamageField;
            }
            set
            {
                this.BurnDamageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int BurnTime
        {
            get
            {
                return this.BurnTimeField;
            }
            set
            {
                this.BurnTimeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Cannon", Namespace="http://schemas.datacontract.org/2004/07/ModelLayer.Buildings.Defense")]
    public partial class Cannon : ModelLayer.Buildings.Defense.Defensive
    {
        
        private int SplashDamageField;
        
        private double SplashRadiusField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SplashDamage
        {
            get
            {
                return this.SplashDamageField;
            }
            set
            {
                this.SplashDamageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double SplashRadius
        {
            get
            {
                return this.SplashRadiusField;
            }
            set
            {
                this.SplashRadiusField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GatlingTurret", Namespace="http://schemas.datacontract.org/2004/07/ModelLayer.Buildings.Defense")]
    public partial class GatlingTurret : ModelLayer.Buildings.Defense.Defensive
    {
        
        private double AccuracyField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Accuracy
        {
            get
            {
                return this.AccuracyField;
            }
            set
            {
                this.AccuracyField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IServerService")]
public interface IServerService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerService/Update", ReplyAction="http://tempuri.org/IServerService/UpdateResponse")]
    ModelLayer.Map Update();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerService/Login", ReplyAction="http://tempuri.org/IServerService/LoginResponse")]
    ModelLayer.User Login(ModelLayer.User user);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IServerServiceChannel : IServerService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class ServerServiceClient : System.ServiceModel.ClientBase<IServerService>, IServerService
{
    
    public ServerServiceClient()
    {
    }
    
    public ServerServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public ServerServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ServerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ServerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public ModelLayer.Map Update()
    {
        return base.Channel.Update();
    }
    
    public ModelLayer.User Login(ModelLayer.User user)
    {
        return base.Channel.Login(user);
    }
}
