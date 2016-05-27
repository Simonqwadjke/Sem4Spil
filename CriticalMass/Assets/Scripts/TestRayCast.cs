using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestRayCast : MonoBehaviour {

	bool select = false;
	
	public Text text;
	Map map = new Map();
	public GameObject gameMap;
	GameObject go;

	void Update() {
		string s;


		if (Input.GetMouseButton(0)) {
			if (select) {
				Vector3 v3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				
				//go.GetComponent<BuildingBehavior>()
				go.GetComponent<BuildingBehavior>().move(map.pos(v3.x, v3.y));
			}
		}

		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D[] hits;
			hits = Physics2D.RaycastAll(ray.origin, ray.direction);
			if (hits.Length > 0) {
				s = hits.Length + " Objects was.";
				foreach (RaycastHit2D hit in hits) {
					s += "\nName: " + hit.collider.name + " Tag: " + hit.collider.tag;
					if (hit.collider.tag == "Building") {
						go = hit.collider.gameObject;
						//go.transform.position = new Vector3(go.transform.position.x + 1f, go.transform.position.y);
						go.GetComponent<BuildingBehavior>().selected = true;
						select = true;
						break;
					}
					else {
						select = false;
						if (go != null) {
							go.GetComponent<BuildingBehavior>().selected = false;
							select = true;
						}
					}
				}
			}
			else {
				s = "Nothing was hit";
			}
			Vector3 v3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			v3 = v3 - gameMap.transform.position;
			s += "\nInput.mouse = " + Input.mousePosition;
			s += "\nScreen to world point" + v3;
			s += "\nMapPos = " + map.pos(v3.x, v3.y);
			s += "\nSelect = " + select.ToString();
			text.text = s;
		}
	}
}
