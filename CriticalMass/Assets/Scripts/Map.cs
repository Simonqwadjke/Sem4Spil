using UnityEngine;
using System.Collections;
using System;

public class Map{

	public Vector3 pos(int x, int y) {
		return new Vector3(x + 2, y);
	}

	public Vector3 pos(ModelLayer.Location location) {
		return new Vector3(location.X + 2, location.Y);
	}

	public GameObject CreateComponent(Sprite sp, Vector3 v3, String objectName, Transform parrent, string layer = "Default") {

        GameObject gObj = new GameObject(objectName);

        SpriteRenderer render = gObj.AddComponent<SpriteRenderer>();
        render.sprite = sp;
        render.sortingLayerName = layer;

        gObj.transform.position = v3;
        gObj.transform.localScale = new Vector3(10, 10);
        gObj.transform.parent = parrent;

        return gObj;
    }
}
