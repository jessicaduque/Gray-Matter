using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    Animator Anim;
    GameObject Jogador;
    public GameObject MeuAtaque;
    public GameObject PontoDeSaida;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Jogador = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        transform.LookAt(Jogador.transform.position);
        if (Vector3.Distance(Jogador.transform.position, transform.position) < 16)
        {
            Anim.SetBool("Atacando", true);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bala")
        {
            Anim.SetTrigger("Dano");
            Destroy(this.gameObject, 2f);
        }
    }

    public void EstaAtacando()
    {
        GameObject Ataque = Instantiate(MeuAtaque, PontoDeSaida.transform.position, Quaternion.identity);
        Ataque.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
        Destroy(Ataque, 5f);
    }

    public void AcabouAtaque()
    {
        Anim.SetBool("Atacando", false);
    }
}
