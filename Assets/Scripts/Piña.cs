using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piña : MonoBehaviour
{
    [SerializeField] float speed;
    private GameObject nine;
    Rigidbody2D rb;

    [SerializeField] GameObject piña;
    private GameObject placeholder;

    // Start is called before the first frame update
    void Start()
    {
        placeholder = GameObject.Find("Placeholder");
        nine = GameObject.Find("Nine");
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nine.transform.localScale.x < 0 && rb.velocity.x < 0.1f)
        {
            //transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
            rb.velocity = new Vector2(-speed, 1);
            
        }

        else if (nine.transform.localScale.x > 0 && rb.velocity.x > -0.1f)
        {
            //transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
            rb.velocity = new Vector2(speed, 1);
            
        }

        


    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject colisionando = collision.gameObject;

        if (colisionando.tag != "Trampa" && colisionando.tag != "Nine")
        {
            Instantiate(piña, placeholder.transform.position, transform.rotation);

        }

        else if (colisionando.tag == "Nine")
        {
            Destroy(this.gameObject);

        }

        Destroy(this.gameObject);

        

       

        
    }
}
