using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPersonagem : MonoBehaviour
{
    private Rigidbody rigidbodyPersonagens;
    void Awake()
    {
        rigidbodyPersonagens = GetComponent<Rigidbody>();
    }
    public void Movimentar(Vector3 direcao, float Velocidade)
    {
        rigidbodyPersonagens.MovePosition
        (rigidbodyPersonagens.position +
        direcao * Velocidade * Time.deltaTime);
    }
    public void Rotacionar( Vector3 direcao)
    {
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        rigidbodyPersonagens.MoveRotation(novaRotacao);
    }
}
