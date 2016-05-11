using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogOn : MonoBehaviour {

    public Text text;


    void Start() {
        Button btnThis = gameObject.GetComponent<Button>();
        btnThis.onClick.AddListener(onClick);
    }

    void onClick() {
        text.text = "I've been clicked!";
        SceneManager.LoadScene("Map");
    }
}
