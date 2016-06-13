using UnityEngine;
using System.Collections;
using ModelLayer.Buildings.Defense;
using ModelLayer.Units;

public class DefensiveBuildingBehavior : MonoBehaviour {
    public Defensive source;
    public Sprite[] sprites;
    GameObject target;
    int currentSprite = 0;

    // Use this for initialization
    public void init() {
        
        GetComponent<BuildingBehavior>().source = source;
        GetComponent<BuildingBehavior>().init();

        updateTurretSprite();
    }

    void updateTurretSprite() {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        sp.sprite = sprites[currentSprite];
    }

    // Update is called once per frame
    void Update() {
        foreach(GameObject unit in TargetList.targets)
        {
            if((unit.transform.position - transform.position).sqrMagnitude < 25)
            {
                if (target == null)
                {
                    target = unit;
                }
            }
            else
            {
                target = null;
            }
        }
    }

    void OnGUI()
    {
        if(target != null)
        {
            GUI.Label(new Rect(100, 100, 100, 30), "DU DØ!");
        }
        else
        {
            GUI.Label(new Rect(100, 100, 100, 30), "You missed!");
        }
    }


    int a = 200;
    int b = 0;
    void demoTurretSprites() {
        b++;
        if (b == a) {
            b = 0;
            currentSprite++;
            if (currentSprite == sprites.Length)
                currentSprite = 0;
            updateTurretSprite();
        }
    }
}
