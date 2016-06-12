using UnityEngine;
using UnityEngine.SceneManagement;
using ModelLayer;
using System.Collections;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    public User user;

    void Awake()
    {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
    }

    void OnGUI()
    {
        if (user != null)
        {
            GUI.Label(new Rect(10, 10, 100, 30), user.Username);
            if(GUI.Button(new Rect(10, 50, 100, 30), "Log out"))
            {
                user = null;
                SceneManager.LoadScene("LogIn");
            }
        }
        else
        {
            GUI.Label(new Rect(100, 100, 100, 30), "none is logged in");
        }
    }
}
