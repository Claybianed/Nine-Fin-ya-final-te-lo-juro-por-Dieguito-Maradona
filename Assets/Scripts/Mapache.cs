using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapache : MonoBehaviour
{
    public float maxspeed = 1f;
    public float speed = 1f;
    public Rigidbody2D rb;
    BoxCollider2D myCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rb.velocity = new Vector2((speed*transform.localScale.x), rb.velocity.y);


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Barrera")))
        {
            transform.localScale = new Vector3((transform.localScale.x * -1), transform.localScale.y, transform.localScale.z);

        }

    }
}