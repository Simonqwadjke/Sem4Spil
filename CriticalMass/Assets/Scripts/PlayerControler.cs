using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour {
    private Rigidbody2D rb2d;
    public float speed;
    private int count;

    void Start() {
        rb2d = GetComponent< Rigidbody2D > ();
        count = 0;
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }


    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("PickUp")) {
            //Destroy(other.gameObject);
            //gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
        count++;
    }
}
