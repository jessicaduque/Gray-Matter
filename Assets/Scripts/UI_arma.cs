using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_arma : MonoBehaviour
{
    TMP_Text meuTexto;
    AtiraArma minhaArma;


    // Start is called before the first frame update
    void Start()
    {
        meuTexto = GetComponent<TMP_Text>();
        minhaArma = GameObject.FindGameObjectWithTag("Arma").GetComponent<AtiraArma>();
    }

    // Update is called once per frame
    void Update()
    {
        meuTexto.text = "Arma: " + minhaArma.municao.ToString() + " / " + minhaArma.limiteMunicao.ToString();
    }
}
