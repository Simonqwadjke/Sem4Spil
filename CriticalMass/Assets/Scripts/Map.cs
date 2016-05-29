using UnityEngine;
using System.Collections;
using System;
using ModelLayer;

public class Map {

	/// <summary>
	/// Used to convert ModelLayer.Location into map space.
	/// </summary>
	/// <param name="location"></param>
	/// <returns>>Returns a vector3 with the position indicated by Location</returns>
	public Vector3 posV3(ModelLayer.Location location) {
		return new Vector3(location.X + 2, location.Y);
	}

	/// <summary>
	/// Used for mouse possition to exact tile position
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <returns>Returns a vector3 with the exact position</returns>
	public Vector3 posV3(float x, float y) {
		x = (float)Math.Round(x - 0.5f, 0);
		y = (float)Math.Round(y - 0.5f, 0);
		return new Vector3(x, y);
	}

	/// <summary>
	/// Used to convert map space into ModelLayer.Location
	/// </summary>
	/// <param name="v3"></param>
	/// <returns>Returns the Location converted from a Vector3</returns>
	public Location posLoc(Vector3 v3) {
		return new Location() {
			X = v3.x -2,
			Y = v3.y
		};
	}

	/// <summary>
	/// Used to skip posV3 and convert by using posLoc
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <returns>Returns a Location with exact position</returns>
	public Location posLoc(float x, float y) {
		Vector3 v3 = posV3(x, y);
		return new Location() {
			X = v3.x,
			Y = v3.y
		};
	}

	public Location Convert(Vector3 v3) {
		return new Location() {
			X = v3.x,
			Y = v3.y
		};
	}

	public Vector3 Convert(Location location) {
		return new Vector3(location.X, location.Y);
	}

	/// <summary>
	/// Creates a new GameObject
	/// </summary>
	/// <param name="sp">The sprite being assigned to the GameObject</param>
	/// <param name="v3">The location of the GameObject</param>
	/// <param name="objectName">The name of the GameObject</param>
	/// <param name="parrent">The parrent of the GameObject</param>
	/// <param name="layer">The layer of the GameObject</param>
	/// <returns>Returns a new GameObject</returns>
	public GameObject CreateComponent(Sprite sp, Vector3 v3, String objectName, Transform parrent = null, string layer = "Default", string tag = "Untagged") {
		GameObject gObj = new GameObject(objectName);

		SpriteRenderer render = gObj.AddComponent<SpriteRenderer>();
		render.sprite = sp;
		render.sortingLayerName = layer;

		gObj.tag = tag;
		gObj.transform.position = v3;
		gObj.transform.localScale = new Vector3(10, 10);
		gObj.transform.parent = parrent;

		return gObj;
	}
}
