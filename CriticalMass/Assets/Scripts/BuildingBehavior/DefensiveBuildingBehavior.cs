using UnityEngine;
using System.Collections;
using ModelLayer.Buildings.Defense;

public class DefensiveBuildingBehavior : MonoBehaviour {
    public Sprite[] sprites;
    public GatlingTurret source;
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
 
    }


    int a = 200;
    int b = 0;
    void demoTurretSprites() {
        b++;
        if(b == a) {
            b = 0;
            currentSprite++;
            if(currentSprite == sprites.Length)
                currentSprite = 0;
            updateTurretSprite();
        }
    }
}
