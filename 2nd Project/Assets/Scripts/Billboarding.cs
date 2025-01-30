using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboarding : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(Camera.main.transform.position);

        // Het stuk hier onder zorgt er voor dat de item altijd recht blijft staan

        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
