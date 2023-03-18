using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Corpo : MonoBehaviour
{
    private Rigidbody Rb;
    private Animator Anim;
    public float sensibilidade;
    private float velocidadeP;
    public Image sangue;

    public int hp = 100;

    public GameObject TelaMorte;

    bool podeMover;

    // Start is called before the first frame update
    void Start()
    {
        PrenderPersonagem();
        Rb = GetComponent<Rigidbody>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (podeMover)
        {
            Mover();
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


        float velZ = Input.GetAxis("Vertical") * velocidadeP;
        float velX = Input.GetAxis("Horizontal") * velocidadeP;
        // PosCorrigida
        Vector3 velCorrigida = velX * transform.right + velZ * transform.forward;
        Rb.velocity = new Vector3(velCorrigida.x, Rb.velocity.y, velCorrigida.z);

        // Animação de andar do personagem
        if (velX != 0 || velZ != 0)
        {
            Anim.SetBool("Andar", true);
        }
        else if(velX == 0 && velZ == 0){
            Anim.SetBool("Andar", false);
        }

        // Movimento girar do player
        float mouseX = Input.GetAxis("Mouse X") * sensibilidade * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ataque_Inimigo")
        {
            hp = hp - 10;
            float alphaSangue = (float)hp / 100;
            alphaSangue = 1 - alphaSangue;

            sangue.color = new Vector4(1, 1, 1, alphaSangue);

            if (hp <= 0)
            {
                TelaMorte.SetActive(true);
            }
        }
    }

    public void PrenderPersonagem()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MoveArma>().PrenderArma();
        GameObject.FindGameObjectWithTag("Arma").GetComponent<AtiraArma>().PrenderArma();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        podeMover = false;
    }

    public void DesprenderPersonagem()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MoveArma>().DesprenderArma();
        GameObject.FindGameObjectWithTag("Arma").GetComponent<AtiraArma>().DesprenderArma();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        podeMover = true;
    }
}
