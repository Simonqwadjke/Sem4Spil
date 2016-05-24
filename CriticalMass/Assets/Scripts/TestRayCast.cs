using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestRayCast : MonoBehaviour {

	bool select = false;
	bool move = false;
	public int milliSecSelect;
	Vector3 firstHit;
	public Text text;

	void Update() {

		if (Input.GetMouseButtonDown(0)) {
			firstHit = Input.mousePosition;
		}
		if (Input.GetMouseButtonUp(0)) {
			select = false;
			move = false;
		}

		if (Input.GetMouseButtonDown(0)) {

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D[] hits;
			hits = Physics2D.RaycastAll(ray.origin, ray.direction);
			if (hits.Length > 0) {
				text.text = hits.Length + " Objects was.";
				foreach (RaycastHit2D hit in hits) {
					text.text += "\nName: " + hit.collider.name + " Tag: " + hit.collider.tag;
					if (hit.collider.tag == "Building") {
						GameObject go = hit.collider.gameObject;
						//go.transform.position = new Vector3(go.transform.position.x + 1f, go.transform.position.y);
						go.GetComponent<BuildingBehavior>().selected = true;
					}
				}
			}
			else {
				text.text = "Nothing was hit";
			}
		}
	}
}
