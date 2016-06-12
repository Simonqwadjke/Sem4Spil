using UnityEngine;
using System.Collections;
using ModelLayer.Buildings.Defense;
using System;


public class GatlingTurretBehavior : MonoBehaviour {
    public GatlingTurret source;

    // Use this for initialization
    public void Init() {
        //demo();

        GetComponent<DefensiveBuildingBehavior>().source = source;
        GetComponent<DefensiveBuildingBehavior>().init();
    }

    // Update is called once per frame
    void Update() {

    }

    void demo() {
        if (source == null) {
            source = new ModelLayer.Buildings.Defense.GatlingTurret();
        }
        source.Range = 5;
        source.Location = new ModelLayer.Location() {
            X = 3,
            Y = 3
        };
        source.Size = new ModelLayer.Size() {
            Height = 3,
            Width = 3
        };
        String s = "";
    }


}
