using System.Collections.Generic;
using UnityEngine;
public class ControlaJogador : MonoBehaviour

{
    // variaveis
    float Velocidade = 4;
    Vector3 direcao;
    public GameObject TextoGameOver;
    public GameObject InterfaceGameOver;
    public int Vida = 100;
    public ControlaInterface scriptControlaInterface;
    public LayerMask MascaraChao;
    private Animator animatorJogador;
    private MovimentoPersonagem movimentaJogador;
    private Animacoes animacoesJogador;

    // fimvariaveis

    void Start()
    {
        animatorJogador = GetComponent<Animator>();
        movimentaJogador = GetComponent<MovimentoPersonagem>();
        animacoesJogador = GetComponent<Animacoes>();
    }
    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);


        if (direcao != Vector3.zero)
        {
            animacoesJogador.Correr(true);
        }
        else
        {
            animacoesJogador.Correr(false);
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
            animacoesJogador.Atacar(true);
        }
        else
        {
            animacoesJogador.Atacar(false);
        }
    }
    void FixedUpdate()
    {
        movimentaJogador.Movimentar(direcao, Velocidade);

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction, Color.red);

        RaycastHit impacto;

        if (Physics.Raycast(raio, out impacto, 100))
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

        scriptControlaInterface.GameOver();

    }
}
