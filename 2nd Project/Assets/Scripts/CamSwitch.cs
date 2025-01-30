using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public Camera MainCamera;  //Camera 1
    public Camera ThirdPerson;  //Camera 2

    void Start()
    {

        MainCamera.gameObject.SetActive(true);
        ThirdPerson.gameObject.SetActive(false);

    }
    // Switching Camera's and stuff :D
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.V))
        {
            SwitchCameras();
        }

    }

    void SwitchCameras()
    {
        if (MainCamera.gameObject.activeSelf) {

            MainCamera.gameObject.SetActive(false);
            ThirdPerson.gameObject.SetActive(true);
        }
        else
        {
            MainCamera.gameObject.SetActive(true);
            ThirdPerson.gameObject.SetActive(false);
        }

    }
}
