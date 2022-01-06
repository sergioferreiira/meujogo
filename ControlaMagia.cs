using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaMagia : MonoBehaviour
{
    public GameObject magia;
    public GameObject magiaposition;


    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(magia, magiaposition.transform.position, magiaposition.transform.rotation);
        }
    }
}
