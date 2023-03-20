using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    int numeroControleObjetos = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        numeroControleObjetos = GameObject.FindGameObjectWithTag("GameController").GetComponent<RoteiroCena0>().ReturnControleObjetos();

        Destroy(this.gameObject);

        if(collision.gameObject.tag == "tv")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<CanvasManager>().QuebrarVidroSom();
            GameObject.FindGameObjectWithTag("GameController").GetComponent<RoteiroCena0>().IterarControleObjetos();
            GameObject.FindGameObjectWithTag("GameController").GetComponent<RoteiroCena0>().RodarFalas();
            Destroy(collision.gameObject);
        }
        if(numeroControleObjetos > 0)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("breakable"))
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<CanvasManager>().QuebrarVidroSom();
                GameObject.FindGameObjectWithTag("GameController").GetComponent<RoteiroCena0>().IterarControleObjetos();
                Destroy(collision.gameObject);
            }
        }


    }
}
