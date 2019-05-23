﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SepararMateriais : MonoBehaviour
{
    private GameObject gc;

    public Text separarPlastico;
    public Text separarPapel;
    public Text separarVidro;
    public Text separarMetal;

    public enum Material
    {
        plastico,
        papel,
        vidro,
        metal
    };

    public Material mat = new Material();

    private void Awake()
    {
        separarPlastico.enabled = false;
        separarPapel.enabled = false;
        separarVidro.enabled = false;
        separarMetal.enabled = false;
    }

    IEnumerator AvisoMaterial()
    {
        if(mat == Material.plastico)
        {
            separarPlastico.enabled = true;
            yield return new WaitForSeconds(2.5f);
            separarPlastico.enabled = false;
        }
        if (mat == Material.papel)
        {
            separarPapel.enabled = true;
            yield return new WaitForSeconds(2.5f);
            separarPapel.enabled = false;
        }
        if (mat == Material.vidro)
        {
            separarVidro.enabled = true;
            yield return new WaitForSeconds(2.5f);
            separarVidro.enabled = false;
        }
        if (mat == Material.metal)
        {
            separarMetal.enabled = true;
            yield return new WaitForSeconds(2.5f);
            separarMetal.enabled = false;
        }
    }

    private void Start()
    {
        gc = GameObject.Find("GameController");
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(mat == Material.plastico && gc.GetComponent<GameController>().plastico > 0)
                {
                    gc.GetComponent<GameController>().SepararPlastico();
                    gc.GetComponent<GameController>().ZerarPlastico();
                    StartCoroutine(AvisoMaterial());
                }

                if (mat == Material.papel && gc.GetComponent<GameController>().papel > 0)
                {
                    gc.GetComponent<GameController>().SepararPapel();
                    gc.GetComponent<GameController>().ZerarPapel();
                    StartCoroutine(AvisoMaterial());
                }

                if (mat == Material.vidro && gc.GetComponent<GameController>().vidro > 0)
                {
                    gc.GetComponent<GameController>().SepararVidro();
                    gc.GetComponent<GameController>().ZerarVidro();
                    StartCoroutine(AvisoMaterial());
                }
                if (mat == Material.metal && gc.GetComponent<GameController>().metal > 0)
                {
                    gc.GetComponent<GameController>().SepararMetal();
                    gc.GetComponent<GameController>().ZerarMetal();
                    StartCoroutine(AvisoMaterial());
                }
            }
        }
    }
}
