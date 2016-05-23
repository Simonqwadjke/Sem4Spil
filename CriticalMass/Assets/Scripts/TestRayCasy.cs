using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestRayCasy : MonoBehaviour {

    public Text text;

    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D[] hits;
                hits = Physics2D.RaycastAll(ray.origin, ray.direction);
                if(hits.Length > 0) {
                    text.text = hits.Length + " Objects was.";
                    foreach(RaycastHit2D hit in hits) {
                        text.text += "\nName: " + hit.collider.name + " Tag: " + hit.collider.tag;
                        if(hit.collider.tag == "Building") {
                            GameObject go = hit.collider.gameObject;
                            go.transform.position = new Vector3(go.transform.position.x + 1f, go.transform.position.y);
                        }
                    }
                }
                else text.text = "Nothing was hit";
            }
            /*
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit;
                hit = Physics2D.Raycast(ray.origin, ray.direction);

                string s = hit.collider.tag;
                if(s == "Building") {
                    text.text = "BUILDING WAS HIT!";
                }
                else if(s == "Map") {
                    text.text = "Map WAS HIT!";
                }
                else {
                    text.text = "no hit;";
                }
            }
            */
        }





        if(Input.GetMouseButtonDown(0)) {
            //text.text = "CLICK 0";
        }
        else if(Input.GetMouseButtonDown(1)) {
            // text.text = "CLICK 1";
        }
    }
}
