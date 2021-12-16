using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour
{
    public GameObject arrow;
    public GameObject arrowposition;


    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(arrow, arrowposition.transform.position, arrowposition.transform.rotation);
        }
    }
}
