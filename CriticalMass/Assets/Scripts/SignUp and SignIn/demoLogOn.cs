using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class demoLogOn : MonoBehaviour {

    void Start() {
        //Button btnThis = gameObject.GetComponent<Button>();
        //btnThis.onClick.AddListener(onClick);
    }

    public void onClick() {
        SceneManager.LoadScene("Map");
    }
}
