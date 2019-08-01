using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterIpServer : MonoBehaviour
{
    public static EnterIpServer Instance;

    public InputField ip;
    public string DireccionIp;

    private void Awake()
    {
        // Instance = this;

        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

    public void GiveMeTheIp()
    {
        DireccionIp = ip.text;
        SceneManager.LoadScene("SceneServer");
    }
}
