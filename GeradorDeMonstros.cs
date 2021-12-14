using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeMonstros : MonoBehaviour
{
    public GameObject Monstro;
    float contadorTempo = 0;
    public float TempoGerarMonstro = 10;
    void update()
    {
        contadorTempo += Time.deltaTime;
        if (contadorTempo >= TempoGerarMonstro)
        {
            Instantiate(Monstro, transform.position, transform.rotation);
            contadorTempo = 0;
        }
    }
}
