using UnityEngine;
using System.Collections;
using System;

public class Map : MonoBehaviour {

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
