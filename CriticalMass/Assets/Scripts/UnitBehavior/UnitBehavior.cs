using UnityEngine;
using System.Collections;
using ModelLayer.Units;

public class UnitBehavior : MonoBehaviour {

    public Unit source;
    int health;
    int armor;
    bool alive;

	// Use this for initialization
	void Start () {
        source = new Rifleman();
        health = 1000;
        armor = 5;
        alive = true;
	}
	
	// Update is called once per frame
	void Update () {
	    if(health <= 0)
        {
            alive = false;
        }
	}

    public void TakeDamage(int damage)
    {
        int damageEffective = damage - armor;
        if (damageEffective > 0)
        {
            health -= damageEffective;
        }
        else
        {
            health--;
        }

    }

    public bool IsDead()
    {
        return !alive;
    }

    public override string ToString()
    {
        return source.GetType().Name + " " + health + " " + alive;
    }
}
