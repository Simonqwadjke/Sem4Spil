using UnityEngine;
using System.Collections;
using ModelLayer.Buildings;
using ModelLayer.Buildings.Defense;
using ModelLayer.Buildings.Passive;
using System;

public class BuildingPlacemnet : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        if (GameControl.control != null)
        {
            Map localMap = FindObjectOfType<Map>();
            ModelLayer.Map userMap = GameControl.control.user.Map;
            foreach (Building building in userMap.Buildinds)
            {
                try
                {
                    GameObject obj = localMap.createBuilding(building.GetType().Name);
                    if (building.GetType().Name.Equals("GatlingTurret"))
                    {
                        obj.GetComponent<GatlingTurretBehavior>().source = (GatlingTurret)building;
                        obj.GetComponent<GatlingTurretBehavior>().Init();
                    }
                    else
                    {
                        obj.GetComponent<BuildingBehavior>().source = building;
                        obj.GetComponent<BuildingBehavior>().init();
                    }
                }
                catch (ArgumentException e)
                {
                    Debug.Log("Found unknown building type: " + building.GetType().Name);
                }
            }
            //foreach (Building building in userMap.Buildinds)
            //{
            //    foreach (GameObject prefab in localMap.prefabs)
            //    {
            //        if (building.GetType().Name.Equals(prefab.name))
            //        {
            //            GameObject obj = Instantiate(prefab);
            //            obj.GetComponent<BuildingBehavior>().source = building;
            //            obj.GetComponent<BuildingBehavior>().init();
            //            obj.transform.localScale = new Vector3(10, 10);
            //            obj.transform.parent = localMap.Buildings.transform;
            //            obj.tag = "Building";
            //            obj.name = building.GetType().Name;
            //            break;
            //        }
            //    }
            //}
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
