using UnityEngine;
using System.Collections;
using System.ServiceModel;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ModelLayer;

public class LoginScript : MonoBehaviour {
    
    IServerService client;

    public InputField usernameField;
    public InputField passwordField;
    public Text outputText;

    void Start()
    {
        client = new ServerServiceClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:8081/ServiceLibrary"));
        outputText.text = "Please Enter Username and Password";
    }

    public void LoginStart()
    {
        if (Authenticate(usernameField.text, passwordField.text))
        {
            //change scene
            outputText.text = "Success, now loading";
            SceneManager.LoadScene(0);
        }
        else
        {
            outputText.text = "Wrong Username or Password";
        }
    }

    bool Authenticate(string username, string password)
    {
        bool success = false;
        User user = new User();
        user.Username = username;
        user.Password = password;
        user = client.Login(user);
        if (user != null)
        {
            success = true;
        }
        return success;
    }

}
