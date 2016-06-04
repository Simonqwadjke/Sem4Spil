using UnityEngine;
using System.Collections;
using System;
using ModelLayer;
using ModelLayer.Buildings;

public class PlayerInput : MonoBehaviour {

	public int milliSecSelect;
	GameObject selectedObject;
	Vector3 firstTouch;
	DateTime time;
	MapUtil map;
	bool select;
	bool drag;

	#region Zoom
	public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
	public float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.
	int scale = 0;
	#endregion

	#region Drag
	public GameObject world;
	Vector3 hit_position = Vector3.zero;
	Vector3 current_position = Vector3.zero;
	Vector3 World_position = Vector3.zero;
	#endregion




	void Start() {
		time = new DateTime();
		map = new MapUtil();
		select = false;
		drag = false;
	}

	void Update() {
		Zoom();

		// If there are one touche on the device...
		if (Input.touchCount == 1 || Input.GetMouseButton(0)) {
			SingleInput();
		}
	}

	void SingleInput() {
		if (Input.GetMouseButtonDown(0)) {
			firstTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			time = DateTime.Now; //Get the exact time the player presses the screen
			drag = false;
			hit_position = Input.mousePosition;
			World_position = world.transform.position;
		}

		if (!select && Vector3.Distance(firstTouch, Camera.main.ScreenToWorldPoint(Input.mousePosition)) > 1f) {
			drag = true;
		}

		if (Input.GetMouseButton(0) && !drag && !select) {
			TimeSpan t = DateTime.Now - time;
			if (t.TotalMilliseconds > milliSecSelect) { //Compare first press untill now and check if it should try to rayCast
				RayCast();
			}
		}

		if (Input.GetMouseButtonUp(0)) {
			Deselect();
		}

		if (drag) {
			Drag();
		}

		if (select) {
			if (Input.GetMouseButtonDown(0)) {
				RayCast();
			}
			else if (Input.GetMouseButton(0)) {
				Building source = selectedObject.GetComponent<BuildingBehavior>().source;
				Vector3 v3 = Camera.main.ScreenToWorldPoint(Input.mousePosition) - world.transform.position;
				v3 = map.posV3(v3.x, v3.y);
				Vector3 center = new Vector3((float)Math.Truncate((double)source.Size.Width / 2), (float)Math.Truncate((double)source.Size.Height / 2));
				v3 = v3 - center;
								Location loc = map.posLoc(v3);
				if (loc.X >= 0 && loc.X <= world.GetComponentInChildren<Map>().mapWidth - source.Size.Width) {

				}

				if (loc.Y >= 0 && loc.Y <= world.GetComponentInChildren<Map>().mapHeight - source.Size.Height) {

				}

				if (source.Location.X != loc.X || source.Location.Y != loc.Y) {
					selectedObject.GetComponent<BuildingBehavior>().move(v3);
				}
			}
		}
	}

	void Deselect() {
		select = false;
		selectedObject.GetComponent<BuildingBehavior>().Deselect();
		selectedObject = null;
	}

	void RayCast() {
		//Flush before casting a ray
		if (selectedObject != null) {
			Deselect();
		}

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //create the Ray from mouse possition.
		RaycastHit2D[] hits; //store all GameObjects hit by the ray
		hits = Physics2D.RaycastAll(ray.origin, ray.direction); //Cast the Ray and store all hit GameObjects

		//Process all the hits if any is pressent.
		if (hits.Length > 0) {
			foreach (RaycastHit2D hit in hits) {
				if (hit.collider.tag == "Building") {
					selectedObject = hit.collider.gameObject;
					selectedObject.GetComponent<BuildingBehavior>().Select();
					select = true;
				}
			}
		}
	}

	void Zoom() {
		if (Input.GetAxis("Mouse ScrollWheel") > 0 && scale > 0) {
			Camera.main.orthographicSize -= scale;
			scale--;
		}

		if (Input.GetAxis("Mouse ScrollWheel") < 0) {
			scale++;
			Camera.main.orthographicSize += scale;
		}

		// If there are two touches on the device...
		if (Input.touchCount == 2) {
			// Store both touches.
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			// Find the difference in the distances between each frame.
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

			// If the camera is orthographic...

			if (Camera.main.orthographic) {
				// ... change the orthographic size based on the change in distance between the touches.
				Camera.main.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed / Camera.main.orthographicSize;

				// Make sure the orthographic size never drops below zero.
				Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 1f);
			}
			else {
				// Otherwise change the field of view based on the change in distance between the touches.
				Camera.main.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed / Camera.main.fieldOfView;

				// Clamp the field of view to make sure it's between 0 and 180.
				Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 1f, 179.9f);
			}
		}
	}

	void Drag() {
		/*if (Input.GetMouseButtonDown(0)) {
			hit_position = Input.mousePosition;
			World_position = world.transform.position;
		}*/
		if (Input.GetMouseButton(0)) {
			current_position = Input.mousePosition;
			// From the Unity3D docs: "The z position is in world units from the camera."  In my case I'm using the y-axis as height
			// with my camera facing back down the y-axis.  You can ignore this when the camera is orthograhic.
			current_position.z = hit_position.z = World_position.y;

			// Get direction of movement.  (Note: Don't normalize, the magnitude of change is going to be Vector3.Distance(current_position-hit_position)
			// anyways.  
			Vector3 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(hit_position);

			// Invert direction to that terrain appears to move with the mouse.
			direction = direction * 1;

			Vector3 position = World_position + direction;

			world.transform.position = position;
		}
	}


}
