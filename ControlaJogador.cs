
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControlaJogador : MonoBehaviour

{
    // variaveis
    Vector3 forward;
    Vector3 strafe;
    Vector3 vertical;
    float Velocidade = 10;
    public GameObject TextoGameOver;
    public int Vida = 100;
    public ControlaInterface scriptControlaInterface;
    // fimvariaveis

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");

        Vector3 direcao = new Vector3(strafeInput, 0, forwardInput);

        transform.Translate(direcao * Velocidade * Time.deltaTime);


        if (direcao != Vector3.zero)
        {
            GetComponent<Animator>().SetBool("Run", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Run", false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GetComponent<Animator>().SetBool("DrawArrow", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("DrawArrow", false);

        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetComponent<Animator>().SetBool("Attack", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Attack", false);
        }
        if (Vida <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("MyGame");
                Time.timeScale = 1;
            }
        }
    }
    public void TomarDano(int dano)
    {
        Vida -= dano;
        scriptControlaInterface.AtualizarSliderVidaJogador();
        if (Vida <= 0)
        {
            Morrer();
        }
    }
    public void Morrer()
    {
        Time.timeScale = 0;
        GetComponent<ControlaJogador>().TextoGameOver.SetActive(true);
    }
}


