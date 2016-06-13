using UnityEngine;
using System.Collections;

public class UnitBehavior : MonoBehaviour {

    public int health;
    bool alive;

	// Use this for initialization
	void Start () {
        health = 10;
        alive = true;
	}
	
	// Update is called once per frame
	void Update () {
	    if(health <= 0)
        {
            alive = false;
        }
	}

    public bool IsDead()
    {
        return !alive;
    }
}
