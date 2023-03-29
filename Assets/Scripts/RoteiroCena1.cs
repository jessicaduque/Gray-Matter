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
            if (tempo > 1.5f)
            {
                tempo = 0.0f;
                speechAudio.Stop();
                numeroFala++;
            }
        }

        if (numeroFala == 0)
        {
            falaTexto.text = "There we go, this is a better space for us!";
            FalaPorTempo();
        }
        
        if (numeroFala == 2)
        {
            falaTexto.text = "There, there! There's a very important target right there, so try to hit it.";
        }
        
        if (numeroFala == 4)
        {
            falaTexto.text = "Easy right? But...";
            
        }
        
        if (numeroFala == 5)
        {
            falaTexto.text = "It'll get worse.";
        }
        if (numeroFala == 6)
        {
            falaTexto.text = "So many! Take them all out...";
        }
        if (numeroFala == 7)
        {
            falaTexto.text = "Good job! Keep on eliminating everything...";
        }
        if (numeroFala == 8)
        {
            falaTexto.text = "Don't stop!";
        }
        if (numeroFala == 9)
        {
            falaTexto.text = "Seems you really got into this.";
        }
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
        else if (numeroFala == 2 || numeroFala == 4 || numeroFala == 5 || numeroFala == 6 || numeroFala == 8 || numeroFala == 9)
        {
            FalaPorTempo();
            if(numeroFala == 8 || numeroFala == 9)
            {
                if (tempo > 2.5f)
                {
                    falasRodando = false;
                }
            }
            else{
                if (Input.GetMouseButtonDown(0))
                {
                    if (numeroFala == 4)
                    {
                        ScriptFalas();
                    }
                    else if (numeroFala == 6)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            falasRodando = false;
                            GameObject.FindGameObjectWithTag("Player").GetComponent<Corpo>().DesprenderPersonagem();
                        }
                    }
                    else
                    {
                        falaTexto.text = "";
                        GameObject.FindGameObjectWithTag("Player").GetComponent<Corpo>().DesprenderPersonagem();
                    }

                }
            }
        }
        else if (numeroFala == 3)
        {
            if (tempo >= 0.5f)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Corpo>().PrenderMexer();
                GameObject.FindGameObjectWithTag("Arma").GetComponent<AtiraArma>().PrenderArma();
                numeroFala++;
                ScriptFalas();
                tempo = 0.0f;
            }
        }
        else if(numeroFala == 7)
        {
            FalaPorTempo();
            if (tempo > 2.5f)
            {
                tempo = 0.0f;
                numeroFala++;
                ScriptFalas();
            }
        }
        else if(numeroFala != 1)
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
        if (numeroProgresso == 12)
        {
            RodarFalas();
        }
        if(numeroProgresso == 24)
        {
            RodarFalas();
        }
    }

}
