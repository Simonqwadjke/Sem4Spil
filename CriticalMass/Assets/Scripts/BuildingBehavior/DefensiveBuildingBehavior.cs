using UnityEngine;
using System.Collections;
using ModelLayer.Buildings.Defense;
using ModelLayer.Units;
using System;

public class DefensiveBuildingBehavior : BuildingBehavior {
    public Sprite[] sprites;
    int currentSprite = 0;

    int id = -1;
    static int nextid = 0;
    Defensive def;

    int damage;
    double sqrRange;
    float attackDelay;  
    GameObject target;
    float lastAttack;

    // Use this for initialization
    public override void Init() {
        base.Init();
        id = nextid;
        nextid++;
        lastAttack = 0;

        def = (Defensive)source;
        damage = def.Damage;
        sqrRange = Math.Pow(def.Range, 2);
        attackDelay = (float)def.AttackSpeed/1000;

        updateTurretSprite();
    }

    void updateTurretSprite() {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        sp.sprite = sprites[currentSprite];
    }

    float SqrDistanceTo(GameObject obj)
    {
        return (obj.transform.position - (transform.position + MapUtil.Convert(source.Size) / 2)).sqrMagnitude;
    }

    protected void CheckForTarget()
    {
        bool noneFound = true;

        foreach (GameObject unit in TargetList.targets)
        {
            float sqrDistance = SqrDistanceTo(unit);
            if (sqrDistance < sqrRange)
            {
                noneFound = false;
                if (target == null)
                {
                    target = unit;
                }
                else if (sqrDistance < SqrDistanceTo(target))
                {
                    target = unit;
                }
            }
            else
            {
                if (noneFound)
                {
                    target = null;
                }
            }
        }
    }

    protected void AttemptAttack(double chance)
    {
        if (target != null && Time.time - lastAttack > attackDelay)
        {
            if (UnityEngine.Random.Range(0, 100) < chance)
            {
                target.GetComponent<UnitBehavior>().health -= damage;
            }
            lastAttack = Time.time;
        }
    }

    void OnGUI()
    {
        if(target != null)
        {
            GUI.Label(new Rect(100, 10 + 30 * id, 100, 30), "DU' DØ! " + id);
        }
        else
        {
            GUI.Label(new Rect(100, 100, 100, 30), "You missed!");
        }
    }
}
