
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControlaJogador : MonoBehaviour

{
    // variaveis
    float Velocidade = 15;
    public GameObject TextoGameOver;
    public int Vida = 100;
    public ControlaInterface scriptControlaInterface;
    // fimvariaveis

    // Update is called once per frame
    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");
        Vector3 direcao = new Vector3(eixoX, 0, eixoZ);
        transform.Translate(direcao * Velocidade * Time.deltaTime);
        if (direcao != Vector3.zero)
        {
            GetComponent<Animator>().SetBool("Run", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Run", false);
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


