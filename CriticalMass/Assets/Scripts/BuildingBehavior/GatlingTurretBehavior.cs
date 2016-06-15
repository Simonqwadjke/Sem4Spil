using UnityEngine;
using System.Collections;
using ModelLayer.Buildings.Defense;
using System;


public class GatlingTurretBehavior : MonoBehaviour {
    public GatlingTurret source;

    // Use this for initialization
    public void Init() {

        GetComponent<DefensiveBuildingBehavior>().source = source;
        GetComponent<DefensiveBuildingBehavior>().init();
    }

    // Update is called once per frame
    void Update() {

    }
}
