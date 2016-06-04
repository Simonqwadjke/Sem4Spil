using UnityEngine;
using System.Collections;
using ModelLayer.Buildings.Defense;
using System;

public class GattlingTurretBehavior : MonoBehaviour {
    public GatlingTurret source;

    // Use this for initialization
    void Init() {
        Debug.Log("Creating demo object");
        demo();
        Debug.Log("Demo:" + "\n" + "Location: x=" + source.Location.X + " y=" + source.Location.Y + "\n" + "Size: height=" + source.Size.Height + " width=" + source.Size.Width);

        try {
            Debug.Log("Initialize defence building behavior script");
            GetComponent<DefensiveBuildingBehavior>().source = source;
            GetComponent<DefensiveBuildingBehavior>().init();
            Debug.Log("Initialization completed correctly");
        }
        catch (Exception e) {
            Debug.Log("Something went wrong initializing defencive building behavior");
            Debug.LogException(e);
        }
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
