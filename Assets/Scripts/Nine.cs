using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nine : MonoBehaviour
{
    [SerializeField] GameObject piña;

    bool wallJumping = false;
    public bool mapache = true;
    Rigidbody2D rb;

    bool enSuelo;
    public Transform GroundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    bool tocandoFrente;
    public Transform frontCheck;
    bool wallSlide;
    [SerializeField] float velocidadSlide;

    bool wallJump;
    [SerializeField] GameObject colliderLiana;
    [SerializeField] float xWallForce;
    [SerializeField] float yWallForce;
    [SerializeField] float wallJumpTime;

    [SerializeField] float saltoTelaraña;

    [SerializeField] float wallJumpForce;

    [SerializeField] float Speed;
    [SerializeField] float Salto;
    [SerializeField] float SaltoCuerda;
    float EscalaDefault = 0.07731534f;

    Animator myAnimator;

    public Rigidbody2D _rigidbody;
    Transform tramoAgarrado;
    bool agarrado = false;

    [SerializeField] Vector3 offset;
    BoxCollider2D myCollider;
    [SerializeField] float multiplicadorChoque;
    [SerializeField] float velBalanceo;

    [SerializeField] int numBellotas=0;
    private int numPiñas = 0;

    private bool puedeLanzarPiñas = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
        myAnimator.SetBool("IsRunning", false);
        _rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        
        float movH = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");

        LanzarPiñas();
        MirandoPared();

        if (agarrado)
        {
            colliderLiana.SetActive(true);
            transform.position = tramoAgarrado.transform.position + offset;
            //transform.rotation = tramoAgarrado.transform.rotation;
            if (Input.GetButton("Jump"))
            {
                if(movY < 0)
                {
                    seSuelta();
                }
                else
                {
                    seSuelta();
                    _rigidbody.AddForce(new Vector2(0, SaltoCuerda), ForceMode2D.Impulse);

                }
                colliderLiana.SetActive(false);
            }

            

            tramoAgarrado.transform.GetComponent<Rigidbody2D>().velocity = (new Vector2(movH  * velBalanceo, 0));
        }
        


        if (MirandoPared()&& Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.Space))
        {

            _rigidbody.AddForce(new Vector2((transform.localScale.x*-1), wallJumpForce), ForceMode2D.Impulse);
           

        }

       else if (MirandoPared() && Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.Space))
        {

            _rigidbody.AddForce(new Vector2((transform.localScale.x * -1), wallJumpForce), ForceMode2D.Impulse);
            

        }

        else
        {
            if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
            {
                _rigidbody.AddForce(new Vector2(0, Salto), ForceMode2D.Impulse);
            }

            transform.Translate(new Vector2(movH * Time.deltaTime * Speed, 0));
        }

        if (movH != 0)
        {
            if (movH < 0)
            {
                transform.localScale = new Vector2(-EscalaDefault, EscalaDefault);

            }

            else
            {
                transform.localScale = new Vector2(EscalaDefault, EscalaDefault);
            }

            myAnimator.SetBool("IsRunning", true);
            transform.Translate(new Vector2(movH * Time.deltaTime * Speed, 0));
        }

        else
        {
            myAnimator.SetBool("IsRunning", false);
        }


        enSuelo = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, whatIsGround);

        tocandoFrente = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsGround);

        if (tocandoFrente==true&& enSuelo == false && movH !=0 )
        {
            wallSlide = true;
        }
        else
        {
            wallSlide = false;
        }

        if (wallSlide)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -velocidadSlide, float.MaxValue));
        }

        if (movY!=0 &&wallSlide==true)
        {
            wallJump = true;
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }

        if (wallJump == true)
        {
            rb.velocity = new Vector2(xWallForce * -movH, yWallForce);
        }
       
    }


    void SetWallJumpingToFalse()
    {
        wallJump = false;
    }

    void seSuelta()
    {
        agarrado = false;
        rb.isKinematic = false;
        
    }

    public void MirandoTronco()
    {

        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.Space))
        {
            wallJumping = true;
           

        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.Space))
        {
            wallJumping = true;
            
        }

        else
        {
            wallJumping = false;
        }
        
    }


    bool MirandoPared()
    {


        RaycastHit2D hitdeRaycast = Physics2D.Raycast(myCollider.bounds.center, new Vector2(transform.localScale.x, 0), myCollider.bounds.extents.x + 1f, LayerMask.GetMask("Tronco"));
        Debug.DrawRay(myCollider.bounds.center, new Vector2(transform.localScale.x, 0) * (myCollider.bounds.extents.x + 1f), Color.red);

        return hitdeRaycast.collider != null;
    }


    void LanzarPiñas()
    {
        if (numPiñas >= 1)
        {
            puedeLanzarPiñas = true;
        }

        else
        {
            puedeLanzarPiñas = false;
        }

        if (puedeLanzarPiñas && Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(piña, transform.position - new Vector3((2f*transform.localScale.x), 0, 0), transform.rotation);

            if (numPiñas > 0)
            {
                numPiñas = numPiñas - 1;
            }
            
        }

        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            agarrado = true;
            tramoAgarrado = collision.transform;

            collision.GetComponent<Rigidbody2D>().AddForce(rb.velocity * multiplicadorChoque, ForceMode2D.Impulse);

            rb.isKinematic = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        GameObject colisionando = collision.gameObject;

        if (colisionando.tag == "Bellota")
        {
            numBellotas = numBellotas + 1;

        }

       



        if (colisionando.tag == "Telaraña")
        {
            rb.velocity = new Vector2(0, saltoTelaraña);

        }

        if (colisionando.tag == "Telaraña" && Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(0, (saltoTelaraña*1.5f));
            

        }



        if (colisionando.tag == "Piña")
        {
            
            numPiñas++;
            

        }

        if (colisionando.tag == "Mapache" && mapache==true)
        {

            Debug.Log("Se nos murió");


        }
    }
}
