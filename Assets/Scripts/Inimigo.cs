using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    Rigidbody Rb;
    Animator Anim;
    GameObject Jogador;
    public GameObject MeuAtaque;
    public GameObject PontoDeSaida;

    int hp = 3;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody>();
        Jogador = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        transform.LookAt(Jogador.transform.position);

        if (Vector3.Distance(Jogador.transform.position, transform.position) < 30 && Vector3.Distance(Jogador.transform.position, transform.position) >= 10)
        {
            Anim.SetBool("Andando", true);
            Anim.SetBool("Atacando", false);
            transform.position = Vector3.MoveTowards(transform.position, Jogador.transform.position + new Vector3(0f, 1.5f, 0f), 0.1f);
        }
        else if (Vector3.Distance(Jogador.transform.position, transform.position) < 10) 
        {
            Rb.constraints = RigidbodyConstraints.FreezePosition;
            Anim.SetBool("Andando", false);
            Anim.SetBool("Atacando", true);
        }
        else
        {
            Anim.SetBool("Andando", false);
            Anim.SetBool("Atacando", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bala")
        {
            Anim.SetBool("Andando", false);
            Anim.SetBool("Atacando", false);
            Anim.SetTrigger("Dano");
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

    public void DiminuirHP()
    {
        hp--;
        if(hp == 0)
        {
            Anim.SetBool("Morto", true);
            if(gameObject.tag == "inimigo1")
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<RoteiroCena1>().IterarControleObjetos();
                GameObject.FindGameObjectWithTag("GameController").GetComponent<RoteiroCena1>().RodarFalas();
                GameObject.FindGameObjectWithTag("Arma").GetComponent<AtiraArma>().PrenderArma();
            }
            Destroy(this.gameObject);
        }
    }
}
