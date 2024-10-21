using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{

    public AudioSource sourceAudio;

    public bool isLocked = false;  // Se a porta está trancada
    public float openAngle = 90f;  // O ângulo de abertura da porta
    public float openSpeed = 4f;   // A velocidade de abertura da porta
    private bool isOpen = false;   // Indica se a porta está aberta
    private bool isMoving = false; // Indica se a porta está em movimento
    private Quaternion closedRotation; // A rotação original (fechada)
    private Quaternion openRotation;   // A rotação de quando a porta está aberta

    private void Awake()
    {
        // Guardar a rotação inicial (porta fechada)
        closedRotation = transform.rotation;
        // Calcular a rotação final quando a porta estiver aberta
        openRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + openAngle, transform.eulerAngles.z);
    }

    public void ToggleDoor()
    {
        // Verifica se a porta está trancada ou em movimento
        if (!isLocked && !isMoving)
        {
            sourceAudio.Play();
            if (isOpen)
            {
                StartCoroutine(RotateDoor(closedRotation)); // Fechar a porta suavemente
                isOpen = false;
            }
            else
            {
                StartCoroutine(RotateDoor(openRotation));  // Abrir a porta suavemente
                isOpen = true;
            }
        }
    }

    public void CloseDoor()
    {
        if (isOpen)
        {
            StartCoroutine(RotateDoor(closedRotation)); // Fechar a porta suavemente
            isOpen = false;
        }
    }

    // Coroutine para abrir/fechar a porta suavemente
    private IEnumerator RotateDoor(Quaternion targetRotation)
    {
        // Marca que a porta está em movimento
        isMoving = true;

        // Enquanto a rotação atual não for igual à rotação alvo
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        {
            // Interpolar a rotação da porta em direção ao ângulo alvo
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * openSpeed);
            yield return null; // Espera até o próximo frame
        }

        // Garantir que a rotação final seja exatamente a rotação alvo
        transform.rotation = targetRotation;

        // Marca que a porta terminou o movimento
        isMoving = false;
    }

}
