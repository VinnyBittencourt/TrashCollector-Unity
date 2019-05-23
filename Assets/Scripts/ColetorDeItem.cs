using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetorDeItem : MonoBehaviour
{
    private GameObject gc;

    public enum Material
    {
        plastico,
        papel,
        vidro,
        metal
    }

    public Material mat = new Material();

    private void Start()
    {
        gc = GameObject.Find("GameController");
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(mat == Material.plastico && gc.GetComponent<GameController>().plastico > 0)
                {
                    gc.GetComponent<GameController>().SepararPlastico();
                    gc.GetComponent<GameController>().ZerarPlastico();
                    //StartCoroutine(AvisoMaterial());
                }

                if (mat == Material.papel && gc.GetComponent<GameController>().papel > 0)
                {
                    gc.GetComponent<GameController>().SepararPapel();
                    gc.GetComponent<GameController>().ZerarPapel();
                    //StartCoroutine(AvisoMaterial());
                }

                if (mat == Material.vidro && gc.GetComponent<GameController>().vidro > 0)
                {
                    gc.GetComponent<GameController>().SepararVidro();
                    gc.GetComponent<GameController>().ZerarVidro();
                    //StartCoroutine(AvisoMaterial());
                }

                if (mat == Material.metal && gc.GetComponent<GameController>().metal > 0)
                {
                    gc.GetComponent<GameController>().SepararMetal();
                    gc.GetComponent<GameController>().ZerarMetal();
                    //StartCoroutine(AvisoMaterial());
                }
            }
        }
    }

    private void Update()
    {
        if(Time.fixedTime % .5 < .2)
        {
            GetComponent<Renderer>().enabled = false;
        }
        else
        {
            GetComponent<Renderer>().enabled = true;
        }
    }

}
