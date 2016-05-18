using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class testMouse : MonoBehaviour {
    public Text text;
	// Use this for initialization
	void Start () {
        text.text = "No click";
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0)) {
            text.text = "CLICK! 0";
        }
        if(Input.GetMouseButtonDown(1)) {
            text.text = "CLICK! 1";
        }
    }
}
