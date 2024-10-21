using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public new Camera camera; // Referência à câmera
    public float fixedZoom = 40f; // Zoom fixo ao pressionar Ctrl
    private float defaultZoom; // Zoom padrão (FOV inicial)

    void Start()
    {
        // Armazenar o zoom padrão (FOV inicial da câmera)
        defaultZoom = camera.fieldOfView;
    }

    void Update()
    {
        // Verificar se a tecla Ctrl está pressionada
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            // Aplicar o zoom fixo
            camera.fieldOfView = fixedZoom;
        }

        // Se Ctrl não estiver pressionado, retorne ao zoom padrão ao soltar a tecla
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
        {
            camera.fieldOfView = defaultZoom;
        }
    }
}
