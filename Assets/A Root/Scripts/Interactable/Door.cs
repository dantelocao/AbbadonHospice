using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{

    public AudioSource sourceAudio;

    public bool isLocked = false;  // Se a porta est� trancada
    public float openAngle = 90f;  // O �ngulo de abertura da porta
    public float openSpeed = 4f;   // A velocidade de abertura da porta
    private bool isOpen = false;   // Indica se a porta est� aberta
    private bool isMoving = false; // Indica se a porta est� em movimento
    private Quaternion closedRotation; // A rota��o original (fechada)
    private Quaternion openRotation;   // A rota��o de quando a porta est� aberta

    private void Awake()
    {
        // Guardar a rota��o inicial (porta fechada)
        closedRotation = transform.rotation;
        // Calcular a rota��o final quando a porta estiver aberta
        openRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + openAngle, transform.eulerAngles.z);
    }

    public void ToggleDoor()
    {
        // Verifica se a porta est� trancada ou em movimento
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
        // Marca que a porta est� em movimento
        isMoving = true;

        // Enquanto a rota��o atual n�o for igual � rota��o alvo
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        {
            // Interpolar a rota��o da porta em dire��o ao �ngulo alvo
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * openSpeed);
            yield return null; // Espera at� o pr�ximo frame
        }

        // Garantir que a rota��o final seja exatamente a rota��o alvo
        transform.rotation = targetRotation;

        // Marca que a porta terminou o movimento
        isMoving = false;
    }

}
