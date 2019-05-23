using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Slider sliderVida;
    public float vidaJogador;
    GameObject canvas;
    public bool estaPausado;

    //variaveis itens colocados
    public int plastico;
    public int papel;
    public int metal;
    public int vidro;

    //variaveis de intens já colocados no lixo
    int plasticoColetado;
    int papelColetado;
    int metalColetado;
    int vidroColetado;

    public Text plastico2;
    public Text papel2;
    public Text metal2;
    public Text vidro2;

    public Text plasticoColet;
    public Text papelColet;
    public Text metalColet;
    public Text vidroColet;

    public Button continuar;
    public Button voltarAoMenu;
    public Text Pause;

    public void DesabilitarUIDerrota()
    {
        canvas = GameObject.Find("Canvas");
        canvas.transform.GetChild(1).gameObject.SetActive(false);
        canvas.transform.GetChild(2).gameObject.SetActive(false);
        canvas.transform.GetChild(4).gameObject.SetActive(false);

    }

    public void DesabilitarUIVitoria()
    {
        canvas = GameObject.Find("Canvas");
        canvas.transform.GetChild(2).gameObject.SetActive(false);
        canvas.transform.GetChild(5).gameObject.SetActive(false);
    }

    private void Awake()
    {
        DesabilitarUIDerrota();
        DesabilitarUIVitoria();
        canvas = GameObject.Find("Canvas");

        plasticoColet.enabled = false;
        papelColet.enabled = false;
        metalColet.enabled = false;
        vidroColet.enabled = false;
        estaPausado = false;
        continuar.gameObject.SetActive(false);
        voltarAoMenu.gameObject.SetActive(false);
        Pause.enabled = false;



    }

    IEnumerator HabilitaAvisoColetPlastico()
    {
        plasticoColet.enabled = true;
        yield return new WaitForSeconds(3.0f);
        plasticoColet.enabled = false; ;
    }

    IEnumerator HabilitaAvisoColetPapel()
    {
        papelColet.enabled = true;
        yield return new WaitForSeconds(3.0f);
        papelColet.enabled = false; ;
    }

    IEnumerator HabilitaAvisoColetVidro()
    {
        vidroColet.enabled = true;
        yield return new WaitForSeconds(3.0f);
        vidroColet.enabled = false; ;
    }
    IEnumerator HabilitaAvisoColetMetal()
    {
        metalColet.enabled = true;
        yield return new WaitForSeconds(3.0f);
        metalColet.enabled = false; ;
    }

    private void Start()
    {
        vidaJogador = 100;
        plastico2.text = "0/4";
        papel2.text = "0/3";
        vidro2.text = "0/2";
        metal2.text = "0/???";
    }

    public void ColetarPlastico()
    {
        plastico++;
        StartCoroutine(HabilitaAvisoColetPlastico());
    }
    public void ColetarPapel()
    {
        papel++;
        StartCoroutine(HabilitaAvisoColetPapel());
    }
    public void ColetarVidro()
    {
        vidro++;
        StartCoroutine(HabilitaAvisoColetVidro());
    }
    public void ColetarMetal()
    {
        metal++;
        StartCoroutine(HabilitaAvisoColetMetal());
    }

    public void SepararPlastico()
    {
        plasticoColetado = plasticoColetado + plastico;
        plastico2.text = plasticoColetado.ToString() + "/4";
    }
    public void SepararPapel()
    {
        papelColetado = papelColetado + papel;
        papel2.text = papelColetado.ToString() + "/3";
    }

    public void SepararVidro()
    {
        vidroColetado = vidroColetado + vidro;
        vidro2.text = vidroColetado.ToString() + "/2";
    }

    public void SepararMetal()
    {
        metalColetado = metalColetado + metal;
        metal2.text = metalColetado.ToString() + "/???";
    }

    public void ZerarPlastico()
    {
        plastico = 0;
    }

    public void ZerarPapel()
    {
        papel = 0;

    }

    public void ZerarVidro()
    {
        vidro = 0;
    }

    public void ZerarMetal()
    {
        metal = 0;
    }

    public void HabilitarUIVitoria()
    {
        canvas = GameObject.Find("Canvas");
        canvas.transform.GetChild(2).gameObject.SetActive(true);
        canvas.transform.GetChild(5).gameObject.SetActive(true);
    }

    public void HabilitarUIDerrata()
    {
        canvas = GameObject.Find("Canvas");
        canvas.transform.GetChild(1).gameObject.SetActive(true);
        canvas.transform.GetChild(2).gameObject.SetActive(true);
        canvas.transform.GetChild(4).gameObject.SetActive(true);
    }

    public void GanharJogo()
    {
        if (vidroColetado >= 2 && plasticoColetado  >= 4 && papelColetado >= 3 && papelColetado >= 4)
        {
            HabilitarUIVitoria();
            Time.timeScale = 0;
        }
    }

    public void PerderJogo()
    {
        if (vidaJogador <= 0)
        {
            StartCoroutine(PausarJogoNaDerrota());
        }
    }

    IEnumerator PausarJogoNaDerrota()
    {
        Debug.Log("gameover");
        yield return new WaitForSeconds(1.5f);
        HabilitarUIDerrata();
        Time.timeScale = 0;
    }

    public void PauseDoJogo()
    {
        if (!estaPausado)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                estaPausado = true;
                continuar.gameObject.SetActive(true);
                voltarAoMenu.gameObject.SetActive(true);
                Pause.enabled = true;
                Time.timeScale = 0;
            }
        }
    }

    private void Update()
    {
        PerderJogo();
        GanharJogo();
        sliderVida.value = vidaJogador;
        PauseDoJogo();
    }

    public void BotaoRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("game scene");
    }

    public void BotaoIrMenu()
    {
        SceneManager.LoadScene("menu scene");
    }

    public void DespausarJogo()
    {
        estaPausado = false;
        continuar.gameObject.SetActive(false);
        voltarAoMenu.gameObject.SetActive(false);
        Pause.enabled = false;
        Time.timeScale = 1;
    }



}
