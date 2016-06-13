using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ModelLayer.Units;

public class TargetList : MonoBehaviour {

    public static List<GameObject> targets;

	// Use this for initialization
	void Start () {
	    if(targets == null)
        {
            targets = new List<GameObject>(GameObject.FindGameObjectsWithTag("Unit"));
        }
	}
	
	// Update is called once per frame
	void Update () {
	    foreach(GameObject obj in targets)
        {
            if (obj.GetComponent<UnitBehavior>().IsDead())
            {
                targets.Remove(obj);
            }
        }
	}
}
