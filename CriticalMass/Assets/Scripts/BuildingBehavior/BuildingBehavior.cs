using UnityEngine;
using System.Collections;

public class BuildingBehavior : MonoBehaviour {

	
	Vector3 originScale;
	Vector3 originPos;
	float animMax = 20;
	float animSize;
	public bool selected;
	public bool moved;
	bool status = true;

	// Use this for initialization
	void Start() {
		originScale = transform.localScale;
		originPos = transform.localPosition;
		selected = false;
		moved = false;
		animSize = 0;
	}

	// Update is called once per frame
	void Update() {
		if (moved) {
		}
		if (selected) {
			cycleSelect();
		}
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
