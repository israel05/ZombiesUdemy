using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneLoader : MonoBehaviour
{
    


    public void reloadGame()
    {
        SceneManager.LoadScene(0); //vuelve a cargar el mismo nivel

        Time.timeScale = 1; //detiene el tiempo del juego.    
    }

    public void salirJuego()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
