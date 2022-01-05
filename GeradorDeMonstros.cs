using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeMonstros : MonoBehaviour
{

    public GameObject Monstro;
    private float contadorTempo = 0;
    public float TempoGerarMonstro = 15;
    public LayerMask LayerDosMonstros;
    private float distanciaDeGeracao = 3;
    private float DistanciaDoJogadorParaGeracao = 10;
    private GameObject jogador;

    public void start()
    {
        jogador = GameObject.FindWithTag("Jogador");
    }
    void Update()
    {

        // if (Vector3.Distance(transform.position, jogador.transform.position) > DistanciaDoJogadorParaGeracao)
        // {
        // }
        contadorTempo += Time.deltaTime;

        if (contadorTempo >= TempoGerarMonstro)
        {
            StartCoroutine(GerarNovoMonstro());
            contadorTempo = 0;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaDeGeracao);
    }
    IEnumerator GerarNovoMonstro()
    {
        Vector3 posicaoDeCriacao = AleatorizarPosicao();
        Collider[] colisores = Physics.OverlapSphere(posicaoDeCriacao, 1, LayerDosMonstros);

        while (colisores.Length > 0)
        {
            posicaoDeCriacao = AleatorizarPosicao();
            colisores = Physics.OverlapSphere(posicaoDeCriacao, 1, LayerDosMonstros);
            yield return null;
        }

        Instantiate(Monstro, posicaoDeCriacao, transform.rotation);
    }

    Vector3 AleatorizarPosicao()
    {
        Vector3 posicao = Random.insideUnitSphere * distanciaDeGeracao;
        posicao += transform.position;
        posicao.y = 0;

        return posicao;
    }

}