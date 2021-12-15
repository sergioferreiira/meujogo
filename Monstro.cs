<<<<<<< HEAD

using System.Collections.Generic;
using UnityEngine;

public class Monstro : MonoBehaviour 
{
    // variaveis
    public GameObject Jogador;
    float Velocidade = 1f;
    public int Vida = 100;
    // end variaveis

    void Start()
    {
        Jogador = GameObject.FindWithTag("Jogador");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);
        Vector3 direcao = Jogador.transform.position - transform.position;
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        GetComponent<Rigidbody>().MoveRotation(novaRotacao);


        if (distancia <= 20)
        {
            GetComponent<Animator>().SetBool("Land", false);
            GetComponent<Animator>().SetBool("Run", true);
            GetComponent<Animator>().SetBool("Attack", false);
            GetComponent<Rigidbody>().MovePosition
            (GetComponent<Rigidbody>().position +
            direcao * Velocidade * Time.deltaTime);

            if (distancia <= 10)

            {
                GetComponent<Animator>().SetBool("FlyFloat", false);
                GetComponent<Animator>().SetBool("Run", false);
                GetComponent<Animator>().SetBool("Attack", true);
            }
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
        if(Vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Morrer()
    {
       
    }
}

=======

using System.Collections.Generic;
using UnityEngine;

public class Monstro : MonoBehaviour 
{
    // variaveis
    public GameObject Jogador;
    float Velocidade = 1f;
    public int Vida = 100;
    // end variaveis

    void Start()
    {
        Jogador = GameObject.FindWithTag("Jogador");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);
        Vector3 direcao = Jogador.transform.position - transform.position;
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        GetComponent<Rigidbody>().MoveRotation(novaRotacao);


        if (distancia <= 20)
        {
            GetComponent<Animator>().SetBool("Land", false);
            GetComponent<Animator>().SetBool("Run", true);
            GetComponent<Animator>().SetBool("Attack", false);
            GetComponent<Rigidbody>().MovePosition
            (GetComponent<Rigidbody>().position +
            direcao * Velocidade * Time.deltaTime);

            if (distancia <= 10)

            {
                GetComponent<Animator>().SetBool("FlyFloat", false);
                GetComponent<Animator>().SetBool("Run", false);
                GetComponent<Animator>().SetBool("Attack", true);
            }
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
        if(Vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Morrer()
    {
       
    }
}

>>>>>>> 896ecda73e9070615170c20e4ffaa889ecdd16f0
