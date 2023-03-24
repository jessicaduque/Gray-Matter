using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArma : MonoBehaviour
{
    public float velocidadeRotacao;
    private float rotacaoVertical;

    bool podeUsarArma = false;

    public GameObject espelho;

    // Update is called once per frame
    void Update()
    {
        if (podeUsarArma)
        {
            rotacaoVertical += Input.GetAxis("Mouse Y") * velocidadeRotacao;
            float rotacaoX = Mathf.Clamp(-rotacaoVertical, -45, 45);
            transform.localEulerAngles = new Vector3(rotacaoX, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
    }

    public void PrenderArma()
    {
        podeUsarArma = false;
    }

    public void DesprenderArma()
    {
        podeUsarArma = true;
    }

    public void OlharEspelho()
    {
        transform.LookAt(espelho.transform.position);
    }
}
