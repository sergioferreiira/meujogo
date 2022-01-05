using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaInterface : MonoBehaviour
{
    private ControlaJogador scriptControlaJogador;
    public Slider SliderVidaJogador;
    public GameObject PainelDeGameOver;
    public Text TextoTempoSobrevivencia;
    public float TempoPontuacaoSalvo;
    public Text TempoMaximoDeSobrevivencia;
    void Start()
    {
        scriptControlaJogador = GameObject.FindWithTag("Jogador").GetComponent<ControlaJogador>();
        SliderVidaJogador.maxValue = scriptControlaJogador.Vida;
        Time.timeScale = 1;
        TempoPontuacaoSalvo = PlayerPrefs.GetFloat("PontuacaoMaxima");
    }


    void Update()
    {
    }
    public void AtualizarSliderVidaJogador()
    {
        SliderVidaJogador.value = scriptControlaJogador.Vida;
    }
    public void GameOver()
    {
        PainelDeGameOver.SetActive(true);
        Time.timeScale = 0;

        int minutos = (int)(Time.timeSinceLevelLoad / 60);
        int segundos = (int)(Time.timeSinceLevelLoad % 60);
        TextoTempoSobrevivencia.text = "Você sobreviveu por " + minutos + "min e " + segundos + "s";
        PontuacaoMaxima(minutos, segundos);
    }

    void PontuacaoMaxima(int min, int seg)
    {
        if (Time.timeSinceLevelLoad > TempoPontuacaoSalvo)
        {
            TempoPontuacaoSalvo = Time.timeSinceLevelLoad;
            TempoMaximoDeSobrevivencia.text = string.Format("Seu melhor tempo é {0}min e {1}s", min, seg);
            //salvar status
            PlayerPrefs.SetFloat("PontuacaoMaxima", TempoPontuacaoSalvo);
        }
        if (TempoMaximoDeSobrevivencia.text == "")
        {
            min = (int)TempoPontuacaoSalvo / 60;
            seg = (int)TempoPontuacaoSalvo % 60;
            TempoMaximoDeSobrevivencia.text = string.Format("Seu melhor tempo é {0}min e {1}s", min, seg);

        }
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene("MyGame");
    }
}
