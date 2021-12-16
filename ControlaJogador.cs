using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControlaJogador : MonoBehaviour

{
    // variaveis
    float Velocidade = 7;
    Vector3 direcao;
    public GameObject TextoGameOver;
    public int Vida = 100;
    public ControlaInterface scriptControlaInterface;
    public LayerMask MascaraChao;
    private Animator animatorJogador;
    private MovimentoPersonagem movimentaJogador;

    // fimvariaveis

    void Start ()
    {
        animatorJogador = GetComponent<Animator>();
        movimentaJogador = GetComponent<MovimentoPersonagem>();
    }
    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);
        
         
        if (direcao != Vector3.zero)
        {
            animatorJogador.SetBool("Run", true);
        }
        else
        {
            animatorJogador.SetBool("Run", false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            animatorJogador.SetBool("DrawArrow", true);
        }
        else
        {
            animatorJogador.SetBool("DrawArrow", false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animatorJogador.SetBool("Attack", true);
        }
        else
        {
            animatorJogador.SetBool("Attack", false);
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
    void FixedUpdate()
    {
        movimentaJogador.Movimentar(direcao, Velocidade);

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction, Color.red);

        RaycastHit impacto;

        if(Physics.Raycast(raio, out impacto, 100))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;

            posicaoMiraJogador.y = 0;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);

            GetComponent<Rigidbody>().MoveRotation(novaRotacao);

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
