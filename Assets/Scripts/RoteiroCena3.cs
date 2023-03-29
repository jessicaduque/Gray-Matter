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
    public AudioSource espelho;
    public AudioSource bala;

    bool acabou = false;

    // Start is called before the first frame update
    void Start()
    {
        ComecarRoteiro();
    }

    void Update()
    {
        if (!acabou)
        {
            ControleFalas();

            if (!falasRodando)
            {
                falaTexto.text = "";
            }
        }
    }

    void ScriptFalas()
    {
        // Falas
        if (Input.GetMouseButtonDown(0))
        {
            if (tempo > 1.5f)
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

        
        if (numeroFala == 2)
        {
            falaTexto.text = "Have you come to a conclusion?";
            FalaPorTempo();
        }

        if (numeroFala == 3)
        {
            falaTexto.text = "...";
            FalaPorTempo();
        }

        if (numeroFala == 4)
        {
            falaTexto.text = "That's what I thought.";
            FalaPorTempo();
        }
        if (numeroFala == 5)
        {
            falaTexto.text = "Shoot it.";
        }
        if (numeroFala == 6)
        {
            falaTexto.text = "SHOOT!";
        }
    }

    void ControleFalas()
    {
        if (falasRodando)
        {
            tempo += Time.deltaTime;
        }

        if(numeroFala >= 1)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MoveArma>().OlharEspelho();
        }
        

        if (numeroFala == 1)
        {
            FalaPorTempo();
            
            if ((tempo > 3f && tempo < 6f) || Input.GetMouseButtonDown(0))
            {
                speechAudio.Stop();
                falaTexto.text = "";
            }
            if (tempo > 6f)
            {
                RodarFalas();
            }
        }
        else if(numeroFala == 5)
        {
            FalaPorTempo();
            if (tempo > 4f)
            {
                RodarFalas();
            }
        }
        else if (numeroFala == 6)
        {
            FalaPorTempo();
            if (tempo > 2f)
            {
                bala.Play();
                AcabouJogo();
            }
        }
        else
        {
            ScriptFalas();
        }
        
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
    public void AcabouJogo()
    {
        speechAudio.Stop();
        GameObject.FindGameObjectWithTag("Arma").GetComponent<AtiraArma>().PrenderArma();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MoveArma>().PrenderArma();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Corpo>().PrenderGiro();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Corpo>().PrenderMexer();
        espelho.enabled = true;
        acabou = true;
        black.gameObject.SetActive(true);
    }

    public bool ReturnAcabouJogo()
    {
        return acabou;
    }

}
