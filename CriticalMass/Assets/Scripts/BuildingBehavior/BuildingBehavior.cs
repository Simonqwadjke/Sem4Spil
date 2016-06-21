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
    protected int health;
    protected int armor;
    protected int level;

    void Start() {
        
    }

	// Update is called once per frame
	void Update() {
		if (selected) {
			CycleSelect();
		}
        if(health <= 0 && alive)
        {
            alive = false;
        }
	}

    public bool IsDead()
    {
        return !alive;
    }

	// Use this for initialization
	public virtual void Init() {
		originScale = transform.localScale;
		originPos = transform.localPosition;
		animSize = 0;
		selected = false;
        status = true;

        alive = true;
        health = source.HitPoints;
        armor = source.Armor;
        level = source.Level;

		transform.position = MapUtil.posV3(source.Location);
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

	public void Move(Vector3 v3) {
		selected = false;
		transform.localScale = originScale;
		transform.localPosition = originPos;

		source.Location = MapUtil.posLoc(v3);
		transform.localPosition = MapUtil.posV3(source.Location);

		originScale = transform.localScale;
		originPos = transform.localPosition;
		selected = true;
	}

	void CycleSelect() {
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

        float posDifX = originPos.x - (((animSize / 100f) / 20) * source.Size.Width);
        float posDifY = originPos.y - (((animSize / 100f) / 20) * source.Size.Height);
        transform.localPosition = new Vector3(posDifX, posDifY);
	}


}
