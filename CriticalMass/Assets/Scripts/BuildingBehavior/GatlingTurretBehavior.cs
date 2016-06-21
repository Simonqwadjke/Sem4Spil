using UnityEngine;
using System.Collections;
using ModelLayer.Buildings.Defense;
using System;


public class GatlingTurretBehavior : DefensiveBuildingBehavior {

    GatlingTurret turret;

    double accuracy;

    public override void Init() {
        base.Init();
        turret = (GatlingTurret)source;
        accuracy = turret.Accuracy;
    }

    void Update()
    {
        CheckForTarget();
        AttemptAttack(accuracy);
    }
}
