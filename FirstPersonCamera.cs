using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public GameObject Jogador;
    Vector3 distCompensar;
    void Start ()
    {
        distCompensar = transform.position - Jogador.transform.position;
    }
    void Update () 
    {
        transform.position = Jogador.transform.position + distCompensar;
    }
}