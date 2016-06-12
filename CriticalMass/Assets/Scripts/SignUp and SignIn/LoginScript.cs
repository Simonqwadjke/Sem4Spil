using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.ServiceModel;
using System.Security.Cryptography;
using ModelLayer;

public class LoginScript : MonoBehaviour
{

    IServerService client;
    MD5 md5;

    public InputField usernameField;
    public InputField passwordField;
    public Text outputText;

    void Start()
    {
        client = new ServerServiceClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:8081/ServiceLibrary"));
        md5 = MD5.Create();
        outputText.text = "Please Enter Username and Password";
        usernameField.Select();
    }

    public void LoginStart()
    {
        try
        {
            outputText.text = "Attempting Login";
            if (Authenticate(usernameField.text, passwordField.text))
            {
                //change scene
                outputText.text = "Success, now loading";
                SceneManager.LoadScene("Map");
            }
            else
            {
                outputText.text = "Wrong Username or Password";
            }
        }
        catch (System.Exception soe)
        {
            //skriv Exception info til log-fil
            outputText.text = "Failed to connect";
            System.Console.WriteLine(soe.StackTrace);
        }
    }

    bool Authenticate(string username, string password)
    {
        bool success = false;
        User user = new User();
        user.Username = username;
        user.Password = HashPassword(password);
        user = client.Login(user);
        if (user != null)
        {
            GameControl.control.user = user;
            success = true;
        }
        return success;
    }

    string HashPassword(string password)
    {
        string hashedPassword = "";
        byte[] input = System.Text.Encoding.ASCII.GetBytes(password);
        byte[] hash = md5.ComputeHash(input);
        for (int i = 0; i < hash.Length; i++)
        {
            hashedPassword += hash[i].ToString("X2");
        }
        return hashedPassword;
    }

    void Update()
    {
        //if(passwordField.isFocused)
        //{
        //    if (Input.GetKeyDown(KeyCode.Tab))
        //    {
        //        usernameField.Select();
        //    }
        //}
        if (usernameField.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                passwordField.Select();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                usernameField.Select();
            }
        }

        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            LoginStart();
        }
    }
}
