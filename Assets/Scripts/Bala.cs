using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        if(collision.gameObject.tag != "Ataque_Inimigo"){
            Destroy(this.gameObject);
        }
        

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            numeroControleObjetos = GameObject.FindGameObjectWithTag("GameController").GetComponent<RoteiroCena0>().ReturnControleObjetos();

            if (collision.gameObject.tag == "tv")
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<CanvasManager>().QuebrarVidroSom();
                GameObject.FindGameObjectWithTag("GameController").GetComponent<RoteiroCena0>().IterarControleObjetos();
                GameObject.FindGameObjectWithTag("GameController").GetComponent<RoteiroCena0>().RodarFalas();
                Destroy(collision.gameObject);
            }
            if (numeroControleObjetos > 0)
            {
                if (collision.gameObject.layer == LayerMask.NameToLayer("breakable"))
                {
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<CanvasManager>().QuebrarVidroSom();
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<RoteiroCena0>().IterarControleObjetos();
                    Destroy(collision.gameObject);
                }
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            numeroControleObjetos = GameObject.FindGameObjectWithTag("GameController").GetComponent<RoteiroCena1>().ReturnControleObjetos();
            
            if (collision.gameObject.layer == LayerMask.NameToLayer("breakable"))
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<CanvasManager>().QuebrarVidroSom();
                GameObject.FindGameObjectWithTag("GameController").GetComponent<RoteiroCena1>().IterarControleObjetos();
                Destroy(collision.gameObject);
            }
            
        }



    }
}
