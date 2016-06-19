using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ModelLayer.Units;

public class TargetList : MonoBehaviour
{

    public static List<GameObject> targets;

    // Use this for initialization
    void Start()
    {
        targets = new List<GameObject>(GameObject.FindGameObjectsWithTag("Unit"));
    }

    // Update is called once per frame
    void Update()
    {
        if (targets.Count > 0)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                if (targets[i].GetComponent<UnitBehavior>().IsDead())
                {
                    targets.RemoveAt(i);
                }
            }
        }
    }

    void OnGUI()
    {
        for(int i = 0; i < targets.Count; i++)
        {
            GUI.Label(new Rect(10, 120 + i * 10, 150, 20), "" + targets[i].GetComponent<UnitBehavior>().health);
        }
    }
}
