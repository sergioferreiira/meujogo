using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacoes : MonoBehaviour
{
    private Animator animacaoPersonagens;
    void Awake()
    {
        animacaoPersonagens = GetComponent<Animator>();
    }
    public void Atacar(bool estado)
    {
        animacaoPersonagens.SetBool("Attack", estado);
    }
    public void Correr(bool estado)
    {
        animacaoPersonagens.SetBool("Run", estado);
    }
}
