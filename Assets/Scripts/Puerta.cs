using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    [SerializeField] GameObject puerta;
    [SerializeField] GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject colisionando = collision.gameObject;
        if (colisionando.tag == "Nine")
        {
            AbrirPuerta();
        }
    }

    void AbrirPuerta()
    {
        if (gm.abrir == true)
        {
            Destroy(puerta.gameObject);
        }
    }
}
