using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public AudioSource glassAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuebrarVidroSom()
    {
        glassAudio.Play();
    }

    public void ChamarReinicio()
    {
        SceneManager.LoadScene(0);
    }

    public void ChamarCidade()
    {
        SceneManager.LoadScene(1);
    }

    public void ChamarEscola()
    {
        SceneManager.LoadScene(2);
    }

    public void ChamarPreto()
    {
        SceneManager.LoadScene(3);
    }
}
