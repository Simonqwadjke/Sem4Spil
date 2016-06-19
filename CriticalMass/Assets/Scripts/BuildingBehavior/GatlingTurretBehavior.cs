using UnityEngine;
using System.Collections;
using ModelLayer.Buildings.Defense;
using System;


public class GatlingTurretBehavior : DefensiveBuildingBehavior {
    
    public void Init() {
        base.init();
        GatlingTurret turret = (GatlingTurret)source;
        
    }
}
