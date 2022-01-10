using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magiaScript : MonoBehaviour
{
    float Velocidade = 25;
    void FixedUpdate ()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.forward * Velocidade * Time.deltaTime);
    }
    void OnTriggerEnter(Collider objetoDeColisao)
    {
        if(objetoDeColisao.tag == "Inimigo")
        {
            Destroy(objetoDeColisao.gameObject);
        }
        Destroy(gameObject);
    }
}
