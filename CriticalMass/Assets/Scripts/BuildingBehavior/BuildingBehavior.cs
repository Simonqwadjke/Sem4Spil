using UnityEngine;
using System.Collections;
using ModelLayer.Buildings;


public class BuildingBehavior : MonoBehaviour {

    public Building source;
	Vector3 originScale;
	Vector3 originPos;
	float animMax = 20;
	float animSize;
	bool selected;
    bool status;
    bool alive;
	MapUtil map = new MapUtil();
    void Start() {
        
    }

	// Use this for initialization
	public void init() {
		originScale = transform.localScale;
		originPos = transform.localPosition;
		selected = false;
        status = true;
        alive = true;
		animSize = 0;
		transform.position = map.posV3(source.Location);
	}

	// Update is called once per frame
	void Update() {
        float x = source.Location.X;
		if (selected) {
			cycleSelect();
		}
	}

	public void Select() {
		originScale = transform.localScale;
		originPos = transform.localPosition;
		selected = true;
	}

	public void Deselect() {
		transform.localScale = originScale;
		transform.localPosition = originPos;
		selected = false;
	}
	public bool isSelected() {
		return selected;
	}

	public void move(Vector3 v3) {
		selected = false;
		transform.localScale = originScale;
		transform.localPosition = originPos;

		source.Location = map.posLoc(v3);
		transform.localPosition = map.posV3(source.Location) / 10;

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

		if (animSize >= animMax || animSize <= 0) {
			status = !status;
		}

		float scaleDifX = originScale.x + animSize / 100f;
		float scaleDifY = originScale.y + animSize / 100f;
		transform.localScale = new Vector3(scaleDifX, scaleDifY);

        //float posDifX = originPos.x - ((animSize / 100f) / 6.6f);
        //float posDifY = originPos.y - ((animSize / 100f) / 6.6f);
        float posDifX = originPos.x - ((animSize / 1000f) / 2 * source.Size.Width);
        float posDifY = originPos.y - ((animSize / 1000f) / 2 * source.Size.Height);
        transform.localPosition = new Vector3(posDifX, posDifY);
	}


}
