using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeMonstros : MonoBehaviour
{

    public GameObject Monstro;
    float contadorTempo = 0;
    private float TempoGerarZumbi = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        contadorTempo += Time.deltaTime;

        if (contadorTempo >= TempoGerarZumbi)
        {
            Instantiate(Monstro, transform.position, transform.rotation);
            contadorTempo = 0;
        }

    }

}