using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponsZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;
    [SerializeField] float zoomedOutFOV;
    [SerializeField] float zoomedInFOV;
    [SerializeField] float mouseSensitivityZoomIn = 2f; //para cambiar el inputManager
    [SerializeField] float mouseSensitivityZoomOut = 0.5f; //para cambiar el inputManager

    bool zoomedInToggle = false;

    private void OnDisable()
    {
        ZoomOut();
    }


    /*
    private void Start()
    {
        //fpsController = GetComponent<RigidbodyFirstPersonController>(); busca en hijos y en si mismio
        fpsController = GetComponentInParent<RigidbodyFirstPersonController>();
    }
    */
    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) //boton derecho
        {
            if (zoomedInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }

        }
    }

   

    private void ZoomIn()
    {
        fpsController.mouseLook.XSensitivity = mouseSensitivityZoomIn;
        fpsController.mouseLook.YSensitivity = mouseSensitivityZoomIn;
        zoomedInToggle = true;
        fpsCamera.fieldOfView = zoomedInFOV;
    }

    private void ZoomOut()
    {
        fpsController.mouseLook.XSensitivity = mouseSensitivityZoomOut;
        fpsController.mouseLook.YSensitivity = mouseSensitivityZoomOut;
        zoomedInToggle = false;
        fpsCamera.fieldOfView = zoomedOutFOV;
    }
}
