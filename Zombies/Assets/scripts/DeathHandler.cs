using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{

    [SerializeField] Canvas gameOverCanvas;

    private void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0; //detiene el tiempo del juego.
        FindObjectOfType<WeaponsSwitcher>().enabled = false; //que no pueda cambiar de arma si ha muerto
        Cursor.lockState = CursorLockMode.None; // libera el raton para poder usar el boton
        Cursor.visible = true;
    }
}
