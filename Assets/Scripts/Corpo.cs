using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Corpo : MonoBehaviour
{
    private Rigidbody Rb;
    //private Animator Anim;
    public float sensibilidade;
    private float velocidadeP;
    public float jumpForce = 5f;
    public Image sangue;

    public int hp = 100;

    public GameObject TelaMorte;

    bool isGrounded = true;
    bool podeMover;
    bool podeGirar;

    int numeroControleObjetos = 0;

    float tempo = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        //Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (podeMover)
        {
            Mover();
        }
        if (podeGirar)
        {
            // Movimento girar do player
            float mouseX = Input.GetAxis("Mouse X") * sensibilidade * Time.deltaTime;
            transform.Rotate(Vector3.up * mouseX);
        }
    }

    void Mover()
    {
        // Mover
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidadeP = 10;
        }
        else
        {
            velocidadeP = 5;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Rb.AddForce(Vector3.up * jumpForce);
        }

        float velZ = Input.GetAxis("Vertical") * velocidadeP;
        float velX = Input.GetAxis("Horizontal") * velocidadeP;
        // PosCorrigida
        Vector3 velCorrigida = velX * transform.right + velZ * transform.forward;
        Rb.velocity = new Vector3(velCorrigida.x, Rb.velocity.y, velCorrigida.z);

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "collider2")
        {
            GameObject.FindGameObjectWithTag("Arma").GetComponent<AtiraArma>().PrenderArma();
            GameObject.FindGameObjectWithTag("GameController").GetComponent<RoteiroCena1>().RodarFalas();
            Destroy(collision.gameObject, 0.1f);
        }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            numeroControleObjetos = GameObject.FindGameObjectWithTag("GameController").GetComponent<RoteiroCena0>().ReturnControleObjetos();
            if (numeroControleObjetos >= 50)
            {
                if (collision.gameObject.tag == "saida")
                {
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<CanvasManager>().ChamarCidade();
                }
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "collider1")
        {
            tempo += Time.deltaTime;
            podeMover = false;
            GameObject.FindGameObjectWithTag("Arma").GetComponent<AtiraArma>().PrenderArma();
            Rb.velocity = new Vector3(0, 0, 0);
            if (tempo > 1f)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<RoteiroCena1>().RodarFalas();
                Destroy(collision.gameObject, 0.1f);
                tempo = 0.0f;
            }

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("chao"))
        {
            isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("chao"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == "Ataque_Inimigo")
        {
            hp = hp - 10;
            float alphaSangue = (float)hp / 100;
            alphaSangue = 1 - alphaSangue;

            sangue.color = new Vector4(1, 1, 1, alphaSangue);

            if (hp <= 0)
            {
                PrenderPersonagem();
                TelaMorte.SetActive(true);
            }
        }
    }

    public void PrenderPersonagem()
    {
        PrenderGiro();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MoveArma>().PrenderArma();
        GameObject.FindGameObjectWithTag("Arma").GetComponent<AtiraArma>().PrenderArma();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        podeMover = false;
    }

    public void DesprenderPersonagem()
    {
        DesprenderGiro();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MoveArma>().DesprenderArma();
        GameObject.FindGameObjectWithTag("Arma").GetComponent<AtiraArma>().DesprenderArma();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        podeMover = true;
    }

    public void PrenderGiro()
    {
        podeGirar = false;
    }
    public void DesprenderGiro()
    {
        podeGirar = true;
    }
}
