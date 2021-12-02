using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarDesactivar : MonoBehaviour
{

    [SerializeField] GameObject texto;
    private SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        texto.SetActive(false);
        sp.sortingOrder = -10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        texto.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        texto.SetActive(false);
    }
}
