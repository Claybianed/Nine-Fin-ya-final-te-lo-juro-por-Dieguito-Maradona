using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool abrir = false;
    public float numBellotas;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AumentarBellotas();
    }

   public void AumentarBellotas()
    {
        numBellotas = numBellotas + 1;
        if (numBellotas == 5)
        {
            abrir = true;
        }
    }
}
