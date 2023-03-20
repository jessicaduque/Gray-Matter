using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoteiroCena1 : MonoBehaviour
{
    public TMP_Text falaTexto;

    int numeroFala = 0;
    bool falasRodando;
    int tamanhoFala;

    float tempo = 0.0f;

    public AudioSource speechAudio;

    int numeroProgresso = 0;

    // Start is called before the first frame update
    void Start()
    {
        ComecarRoteiro();
    }

    // Update is called once per frame
    void Update()
    {
        ControleFalas();

        if (!falasRodando)
        {
            falaTexto.text = "";
        }
    }

    void ComecarRoteiro()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MoveArma>().DesprenderArma();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Corpo>().DesprenderGiro();
        falasRodando = true;
    }

    void ScriptFalas()
    {
        // Falas
        if (Input.GetMouseButtonDown(0))
        {
            tempo = 0.0f;
            speechAudio.Stop();
            numeroFala++;
        }

        if (numeroFala == 0)
        {
            falaTexto.text = "There we go, this is a better space for us!";
            FalaPorTempo();
        }
        /*
        if (numeroFala == 1)
        {
            falaTexto.text = "Hey, you.";
            FalaPorTempo();
        }
        if (numeroFala == 2)
        {
            falaTexto.text = "Let me help you out.";
            FalaPorTempo();
        }
        if (numeroFala == 3)
        {
            falaTexto.text = "See that tv over there?";
            FalaPorTempo();
        }
        if (numeroFala == 4)
        {
            falaTexto.text = "Try shooting it.";
        }
        if (numeroFala == 5)
        {
            falaTexto.text = "Like that! Try shooting a few more things...";
            GameObject.FindGameObjectWithTag("Arma").GetComponent<AtiraArma>().PrenderArma();
        }
        if (numeroFala == 6)
        {
            falaTexto.text = "Well, why don't we go somewhere else now?";
            GameObject.FindGameObjectWithTag("Arma").GetComponent<AtiraArma>().PrenderArma();
            FalaPorTempo();
        }
        if (numeroFala == 7)
        {
            falaTexto.text = "Go on.";
        }
        */
    }

    void ControleFalas()
    {
        if (falasRodando)
        {
            tempo += Time.deltaTime;
        }

        if (numeroFala == 0)
        {
            if (tempo >= 3f)
            {
                ScriptFalas();
                if (Input.GetMouseButtonDown(0))
                {
                    falasRodando = false;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Corpo>().DesprenderPersonagem();
                }
            }
        }
        /*
        else if (numeroFala == 4 || numeroFala == 5 || numeroFala == 7)
        {
            FalaPorTempo();

            if (numeroFala == 5)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    falaTexto.text = "";
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Corpo>().DesprenderPersonagem();
                }
                if (tempo > 30f)
                {
                    numeroProgresso = 7;
                    RodarFalas();
                }
            }
            else if (Input.GetMouseButtonDown(0))
            {
                falasRodando = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Corpo>().DesprenderPersonagem();
                if (numeroFala == 7)
                {
                    numeroProgresso = 50;
                }
            }
        }*/
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

    public void RodarFalas()
    {
        numeroFala++;
        tempo = 0.0f;
        falasRodando = true;
        ScriptFalas();
    }
    public int ReturnControleObjetos()
    {
        return numeroProgresso;
    }

    public void IterarControleObjetos()
    {
        numeroProgresso++;
        if (numeroProgresso == 7 || tempo > 30f)
        {
            RodarFalas();
        }
    }
}
