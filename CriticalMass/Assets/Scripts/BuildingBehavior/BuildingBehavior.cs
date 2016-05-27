using UnityEngine;
using System.Collections;

public class BuildingBehavior : MonoBehaviour {

	public ModelLayer.Buildings.Defense.Defensive source;
	Vector3 originScale;
	Vector3 originPos;
	float animMax = 20;
	float animSize;
	public bool selected;
	bool status = true;
	Map map = new Map();

	// Use this for initialization
	public void init() {
		originScale = transform.localScale;
		originPos = transform.localPosition;
		selected = false;
		animSize = 0;
		transform.position = map.pos(source.Location);
	}

	// Update is called once per frame
	void Update() {
		if (selected) {
			cycleSelect();
		}
	}

	public void move(Vector3 v3) {
		selected = false;
		transform.localScale = originScale;
		transform.localPosition = originPos;

		source.Location.X = v3.x;
		source.Location.Y = v3.y;
		transform.position = map.pos(source.Location);

		originScale = transform.localScale;
		originPos = transform.localPosition;
		selected = true;
	}

	void cycleSelect() {
		if (status) {
			animSize++;
		}
		else {
			animSize--;
		}

		if (animSize == animMax || animSize == 0) {
			status = !status;
		}

		float scaleDifX = originScale.x + animSize / 100f;
		float scaleDifY = originScale.y + animSize / 100f;
		transform.localScale = new Vector3(scaleDifX, scaleDifY);

		float posDifX = originPos.x - ((animSize / 100f) / 6.6f);
		float posDifY = originPos.y - ((animSize / 100f) / 6.6f);
		transform.localPosition = new Vector3(posDifX, posDifY);
	}


}
