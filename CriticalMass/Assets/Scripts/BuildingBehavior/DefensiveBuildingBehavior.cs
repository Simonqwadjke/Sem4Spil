using UnityEngine;
using System.Collections;
using ModelLayer.Buildings.Defense;
using ModelLayer.Units;

public class DefensiveBuildingBehavior : BuildingBehavior {
    public Sprite[] sprites;
    GameObject target;
    int currentSprite = 0;
    int id = -1;
    float lastAttack;
    static int nextid = 0;

    // Use this for initialization
    public override void init() {
        base.init();
        id = nextid;
        nextid++;
        lastAttack = Time.time;
        updateTurretSprite();
    }

    void updateTurretSprite() {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        sp.sprite = sprites[currentSprite];
    }
    
    void Update() {
        bool noneFound = true;
        int range = 125;
        float attackDelay = 0.5f;
        int damage = 1;
        
        foreach(GameObject unit in TargetList.targets)
        {
            float sqrDistance = SqrDistanceTo(unit);
            if (sqrDistance < range)
            {
                noneFound = false;
                if (target == null)
                {
                    target = unit;
                }
                else if(sqrDistance < SqrDistanceTo(target))
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
        if(target != null && Time.time - lastAttack > attackDelay)
        {
            target.GetComponent<UnitBehavior>().health -= damage;
            lastAttack = Time.time;
        }
    }

    float SqrDistanceTo(GameObject obj)
    {
        return (obj.transform.position - (transform.position + MapUtil.Convert(source.Size) / 2)).sqrMagnitude;
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
