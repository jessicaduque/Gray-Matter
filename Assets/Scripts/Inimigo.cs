using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    Animator Anim;
    GameObject Jogador;
    public GameObject MeuAtaque;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Jogador = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        transform.LookAt(Jogador.transform.position);
        if (Vector3.Distance(Jogador.transform.position, transform.position) < 3)
        {
            Anim.SetBool("Atacando", true);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bala")
        {
            Destroy(collision.gameObject);
            Anim.SetTrigger("Morte");
            Destroy(this.gameObject, 2f);
        }
    }

    public void AtivarSoco()
    {
        MeuAtaque.SetActive(true);
    }

    public void DesativarSoco()
    {
        MeuAtaque.SetActive(false);
        Anim.SetBool("Atacando", false);
    }
}
