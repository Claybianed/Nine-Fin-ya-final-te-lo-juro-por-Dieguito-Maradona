using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarAlgo : MonoBehaviour
{
    [SerializeField] GameObject objetoADestruir;
    [SerializeField] GameObject objetoADestruir2;

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
            objetoADestruir.SetActive(false);
            
            objetoADestruir2.SetActive(false);
            this.gameObject.SetActive(false);

        }

        if (colisionando.tag == "Piedra")
        {
            Destroy(this.gameObject);

        }

    }
}
