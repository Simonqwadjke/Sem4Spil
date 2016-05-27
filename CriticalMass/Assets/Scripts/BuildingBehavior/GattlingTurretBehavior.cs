using UnityEngine;
using System.Collections;
using ModelLayer.Buildings.Defense;

public class GattlingTurretBehavior : MonoBehaviour {
	public Sprite[] sprites;
	public GatlingTurret source;
	Map map = new Map();
	int currentSprite = 0;

	// Use this for initialization
	void Start() {
		demo();

		GetComponent<BuildingBehavior>().source = source;
		GetComponent<BuildingBehavior>().init();

		//transform.position = map.pos(source.Location);

		updateTurretSprite();
	}

	void updateTurretSprite() {
		SpriteRenderer sp = GetComponent<SpriteRenderer>();
		sp.sprite = sprites[currentSprite];
	}

	// Update is called once per frame
	void Update() {

	}



	void demo() {
		if (source == null) {
			source = new ModelLayer.Buildings.Defense.GatlingTurret();
		}
		source.Range = 5;
		source.Location = new ModelLayer.Location() { X = 3, Y = 3 };

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
