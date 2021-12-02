using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muerte : MonoBehaviour
{
    public GameObject objetivoSpawn;
    public GameObject jugador;

    BoxCollider2D col;

    


    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
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
            jugador.transform.position = objetivoSpawn.transform.position;

        }

        if (colisionando.tag == "Piedra")
        {
            Destroy(this.gameObject);

        }

        if(colisionando.tag == "Piña")
        {
            Destroy(this.col);
        }

    }
}
