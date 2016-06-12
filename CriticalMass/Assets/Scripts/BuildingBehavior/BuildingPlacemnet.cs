using UnityEngine;
using System.Collections;
using ModelLayer.Buildings;

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
                foreach (GameObject prefab in localMap.prefabs)
                {
                    if (building.GetType().Name.Equals(prefab.name))
                    {
                        GameObject obj = Instantiate(prefab);
                        obj.GetComponent<BuildingBehavior>().source = building;
                        obj.GetComponent<BuildingBehavior>().init();
                        obj.transform.localScale = new Vector3(10, 10);
                        obj.transform.parent = localMap.Buildings.transform;
                        obj.name = building.GetType().Name;
                        break;
                    }
                }
            }
            //foreach (Building building in userMap.Buildinds)
            //{
            //    localMap.createBuilding(building.GetType().Name);
            //}
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
