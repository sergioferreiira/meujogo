using System.Collections.Generic;
using UnityEngine;

public class Monstro : MonoBehaviour
{
    // variaveis
    public GameObject Jogador;
    float Velocidade = 1f;
    public int Vida = 100;

    private Animator animatorInimigo;
    private MovimentoPersonagem movimentaInimigo;
    
    // end variaveis

    void Start()
    {
        Jogador = GameObject.FindWithTag("Jogador");
        animatorInimigo = GetComponent<Animator>();
        movimentaInimigo = GetComponent<MovimentoPersonagem>();
    }
    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

        Vector3 direcao = Jogador.transform.position - transform.position;
       
        movimentaInimigo.Rotacionar(direcao);

        if (distancia <= 25)
        {
            animatorInimigo.SetBool("FlyFloat", true);

        }
        if (distancia <= 20)
        {
            animatorInimigo.SetBool("land", true);
        }
        if (distancia <= 15)
        {
            animatorInimigo.SetBool("Run", true);
            // correr ate o personagem
            movimentaInimigo.Movimentar(direcao, Velocidade);
            // fim correr ate o personagem
        }
        if (distancia <= 9)
        {
            animatorInimigo.SetBool("Run", false);
            animatorInimigo.SetBool("Attack", true);
        }
        if (distancia >= 9)
        {
            animatorInimigo.SetBool("Attack", false);
        }
    }
    void AtacaJogador()
    {
        int dano = Random.Range(15, 30);
        Jogador.GetComponent<ControlaJogador>().TomarDano(dano);

    }

    public void TomarDano(int dano)
    {
        Vida -= dano;
        if (Vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Morrer()
    {

    }
}