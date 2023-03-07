using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recarga : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Arma").GetComponent<AtiraArma>().Carregar();
            Destroy(this.gameObject);
        }
    }
}
