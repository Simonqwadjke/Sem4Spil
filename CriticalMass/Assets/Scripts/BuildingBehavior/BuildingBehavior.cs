using UnityEngine;
using System.Collections;

public class BuildingBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(Input.GetTouch(0).position, Vector2.zero);
 
    }
}
