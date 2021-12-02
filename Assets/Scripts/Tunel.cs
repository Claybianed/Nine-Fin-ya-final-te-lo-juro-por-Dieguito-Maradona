using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunel : MonoBehaviour
{

    [SerializeField] Nine nine;
   
    // Start is called before the first frame update
    void Start()
    {
       
        nine.GetComponent<Nine>();


    }

    // Update is called once per frame
    void Update()
    {

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        nine.mapache = false;



    }


    private void OnTriggerExit2D(Collider2D collision)
    {


        nine.mapache = true;



    }
}