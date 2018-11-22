using System.Collections;
using UnityEngine;
using Vuforia;

public class buttomScript : MonoBehaviour, IVirtualButtonEventHandler {

    public   GameObject VitualButton;

    void Start()
    {
        VitualButton = GameObject.Find("ZButton");
        Debug.Log("HELLO  " + VitualButton);
        VitualButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("PRESSED!");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("RELEASED!");
    }

}
