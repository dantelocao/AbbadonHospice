using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public new Camera camera; // Refer�ncia � c�mera
    public float fixedZoom = 40f; // Zoom fixo ao pressionar Ctrl
    private float defaultZoom; // Zoom padr�o (FOV inicial)

    void Start()
    {
        // Armazenar o zoom padr�o (FOV inicial da c�mera)
        defaultZoom = camera.fieldOfView;
    }

    void Update()
    {
        // Verificar se a tecla Ctrl est� pressionada
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            // Aplicar o zoom fixo
            camera.fieldOfView = fixedZoom;
        }

        // Se Ctrl n�o estiver pressionado, retorne ao zoom padr�o ao soltar a tecla
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
        {
            camera.fieldOfView = defaultZoom;
        }
    }
}
