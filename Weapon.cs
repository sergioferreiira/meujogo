
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Monster;

    void OnTriggerEnter(Collider ObjetoDeColisao)
    {
        if (ObjetoDeColisao.tag == "Inimigo")
        {
            // Destroy(ObjetoDeColisao.gameObject);
        }
    }

}