using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueInimigo : MonoBehaviour
{
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
        if(collision.gameObject.layer != LayerMask.NameToLayer("inimigo"))
        {
            Destroy(this.gameObject);
        }
    }
}
