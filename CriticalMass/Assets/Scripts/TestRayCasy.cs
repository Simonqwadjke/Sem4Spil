using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestRayCasy : MonoBehaviour {

    public Text text;

    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            text.text = "CLICK 0";
        }
        else if(Input.GetMouseButtonDown(1)) {
            text.text = "CLICK 1";
        }
    }
}
