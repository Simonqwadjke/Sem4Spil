using UnityEngine;
using System.ServiceModel;
using System.Security.Cryptography;
using ModelLayer;

public class Service : MonoBehaviour {

    public static Service service;
    public IServerService serviceRef;
    MD5 md5;

    void Awake() {
        if (service == null) {
            DontDestroyOnLoad(gameObject);
            service = this;
            Init();
        }
        else if (service != this) {
            Destroy(gameObject);
        }
    }

    void Init() {
        serviceRef = new ServerServiceClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:8081/ServiceLibrary"));
        md5 = MD5.Create();
    }

    public string HashPassword(string password) {
        string hashedPassword = "";
        byte[] input = System.Text.Encoding.ASCII.GetBytes(password);
        byte[] hash = md5.ComputeHash(input);
        for (int i = 0; i < hash.Length; i++) {
            hashedPassword += hash[i].ToString("X2");
        }
        return hashedPassword;
    }
}
