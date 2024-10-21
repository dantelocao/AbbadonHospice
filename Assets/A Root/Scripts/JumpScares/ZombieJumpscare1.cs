using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieJumpscare1 : MonoBehaviour
{
    public GameObject jumpScareZombie;

    // Start is called before the first frame update
    void Start()
    {
        jumpScareZombie.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        jumpScareZombie.SetActive(true);
        StartCoroutine(RotateZombie(0,0,-25));
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(RotateAndExecute(0, 0, 30));
    }

    public IEnumerator RotateZombie(float rotationX, float rotationY, float rotationZ, float rotationDuration = 0.3f)
    {
        // Captura a rota��o inicial do zumbi
        Quaternion initialRotation = jumpScareZombie.transform.rotation;

        // Calcula a nova rota��o com base nos �ngulos fornecidos para cada eixo
        Quaternion targetRotation = initialRotation * Quaternion.Euler(rotationX, rotationY, rotationZ);

        float elapsedTime = 0f;

        // Rotaciona o zumbi suavemente at� a nova rota��o
        while (elapsedTime < rotationDuration)
        {
            jumpScareZombie.transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime; // Incrementa o tempo decorrido
            yield return null; // Espera at� o pr�ximo frame
        }
    }

    public IEnumerator RotateAndExecute(float rotationX, float rotationY, float rotationZ)
    {
        // Inicia a rota��o e espera ela terminar
        yield return StartCoroutine(RotateZombie(rotationX, rotationY, rotationZ));

        // Coloque aqui as linhas de c�digo que deseja executar ap�s a rota��o
        Destroy(jumpScareZombie);
        Destroy(gameObject);
    }


}

