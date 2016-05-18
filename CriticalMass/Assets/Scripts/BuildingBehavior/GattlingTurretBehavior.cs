using UnityEngine;
using System.Collections;

public class GattlingTurretBehavior : MonoBehaviour {
    public Sprite[] sprites;
    int currentSprite = 0;

    // Use this for initialization
    void Start() {
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
            if(currentSprite == sprites.Length) currentSprite = 0;
            updateTurretSprite();
        }
    }
}
