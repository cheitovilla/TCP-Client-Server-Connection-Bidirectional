using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckingMessages : MonoBehaviour
{
    public string messaje;
    public Text infoMessaje;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (TCPTestServer.instancia.valor == "1")
        {
            infoMessaje.text = "Tecla: " + "Uno";
        }
        else if (TCPTestServer.instancia.valor == "11")
        {
            infoMessaje.text = "Tecla: " + "Dos";
        }
        else if (TCPTestServer.instancia.valor == "111")
        {
            infoMessaje.text = "Tecla: " + "Tres";
        }
        else if (TCPTestServer.instancia.valor == "1111")
        {
            infoMessaje.text = "Tecla: " + "Cuatro";
        }
    }
}
