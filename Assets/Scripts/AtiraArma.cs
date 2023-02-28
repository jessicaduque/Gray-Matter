using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtiraArma : MonoBehaviour
{
    public GameObject PontoDeSaida;
    public GameObject Bala;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Bala, PontoDeSaida.transform.position, Quaternion.identity);
        }
    }
}
