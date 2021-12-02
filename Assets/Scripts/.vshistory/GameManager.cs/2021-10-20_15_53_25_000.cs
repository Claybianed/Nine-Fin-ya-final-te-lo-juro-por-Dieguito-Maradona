using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(8);
    }

    public void Settings()
    {
        SceneManager.LoadScene(1);
    }

    public void Video()
    {
        SceneManager.LoadScene(4);
    }

    public void Audio()
    {
        SceneManager.LoadScene(5);
    }

    public void Control()
    {
        SceneManager.LoadScene(2);
    }
    public void Mando()
    {
        SceneManager.LoadScene(6);
    }
    public void Teclado()
    {
        SceneManager.LoadScene(7);
    }
    public void Extras()
    {
        SceneManager.LoadScene(3);
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
