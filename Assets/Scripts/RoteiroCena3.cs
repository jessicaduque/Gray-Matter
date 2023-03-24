using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RoteiroCena3 : MonoBehaviour
{
    public TMP_Text falaTexto;

    int numeroFala = 0;
    bool falasRodando;
    int tamanhoFala;

    float tempo = 0.0f;

    public AudioSource speechAudio;

    int numeroProgresso = 0;

    public Image black;

    public AudioSource passos;

    // Start is called before the first frame update
    void Start()
    {
        ComecarRoteiro();
    }

    void Update()
    {
        ControleFalas();

        if (!falasRodando)
        {
            falaTexto.text = "";
        }
    }

    void ScriptFalas()
    {
        // Falas
        if (Input.GetMouseButtonDown(0))
        {
            if (tempo > 1f)
            {
                tempo = 0.0f;
                speechAudio.Stop();
                numeroFala++;
            }

        }
        
        if (numeroFala == 1)
        {
            falaTexto.text = "Look.";
        }

        /*
        if (numeroFala == 1)
        {
            falaTexto.text = "Nostalgic, right? Haha";
            FalaPorTempo();
        }
        if (numeroFala == 2)
        {
            falaTexto.text = "Take a good look at everything.";
            FalaPorTempo();
        }
        if (numeroFala == 3)
        {
            falaTexto.text = "No need to rush...";
        }
        if (numeroFala == 4)
        {
            falaTexto.text = "What's with that face?";
            FalaPorTempo();
        }
        if (numeroFala == 5)
        {
            falaTexto.text = "Sadness, regret?";
            FalaPorTempo();
        }
        if (numeroFala == 6)
        {
            falaTexto.text = "...Hatred?";
        }
        if (numeroFala == 7)
        {
            falaTexto.text = "Hahaha...";
            FalaPorTempo();
        }
        if (numeroFala == 8)
        {
            falaTexto.text = "AHAHAAHAHAHAHAHAHAHAHAHAHAHAHHAHA";
            FalaPorTempo();
        }
        if (numeroFala == 9)
        {
            falaTexto.text = "Fool.";
            FalaPorTempo();
        }
        */
    }

    void ControleFalas()
    {
        if (falasRodando)
        {
            tempo += Time.deltaTime;
        }

        if(numeroFala >= 1)
        {
            ScriptFalas();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MoveArma>().OlharEspelho();
        }
        

        /*
        if (numeroFala == 0)
        {
            if (tempo >= 3f)
            {
                FalaPorTempo();
                ScriptFalas();
            }
        }
        else if (numeroFala == 3)
        {
            FalaPorTempo();
            if ((tempo > 2f && tempo < 10f) || Input.GetMouseButtonDown(0))
            {
                speechAudio.Stop();
                falaTexto.text = "";
            }
            if (tempo > 10f)
            {
                RodarFalas();
            }
        }
        else if (numeroFala == 6)
        {
            FalaPorTempo();
            if ((tempo > 5f && tempo < 9f))
            {
                falaTexto.text = "";
            }
            if (tempo > 9f)
            {
                RodarFalas();
            }
        }
        else if (numeroFala == 10)
        {
            falaTexto.text = "";
            if (tempo > 1f)
            {
                black.gameObject.SetActive(true);
            }
            if (tempo > 3f)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<CanvasManager>().ChamarPreto();
            }
        }
        else
        {
            ScriptFalas();
        }
        */
    }
    void FalaPorTempo()
    {
        tamanhoFala = falaTexto.text.Length;
        speechAudio.Play();
        if (numeroFala == 0)
        {
            if (tempo > 3 + tamanhoFala * 0.05)
            {
                speechAudio.Stop();
            }
        }
        else if (tempo > tamanhoFala * 0.05)
        {
            speechAudio.Stop();
        }
    }

    public void ComecarRoteiro()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Corpo>().DesprenderPersonagem();
        GameObject.FindGameObjectWithTag("Arma").GetComponent<AtiraArma>().PrenderArma();
        falasRodando = false;
    }

    public void RodarFalas()
    {
        numeroFala++;
        tempo = 0.0f;
        falasRodando = true;
        ScriptFalas();
        passos.enabled = false;
    }

    public int ReturnControleObjetos()
    {
        return numeroProgresso;
    }

    public void IterarControleObjetos()
    {
        numeroProgresso++;
        /*
        if (numeroProgresso == 7 || tempo > 30f)
        {
            RodarFalas();
        }
        */
    }

}
