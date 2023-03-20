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
        
    }

    void ComecarRoteiro()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MoveArma>().DesprenderArma();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Corpo>().DesprenderGiro();
        falasRodando = true;
    }
}
