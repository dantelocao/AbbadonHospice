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
        // Captura a rotação inicial do zumbi
        Quaternion initialRotation = jumpScareZombie.transform.rotation;

        // Calcula a nova rotação com base nos ângulos fornecidos para cada eixo
        Quaternion targetRotation = initialRotation * Quaternion.Euler(rotationX, rotationY, rotationZ);

        float elapsedTime = 0f;

        // Rotaciona o zumbi suavemente até a nova rotação
        while (elapsedTime < rotationDuration)
        {
            jumpScareZombie.transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime; // Incrementa o tempo decorrido
            yield return null; // Espera até o próximo frame
        }
    }

    public IEnumerator RotateAndExecute(float rotationX, float rotationY, float rotationZ)
    {
        // Inicia a rotação e espera ela terminar
        yield return StartCoroutine(RotateZombie(rotationX, rotationY, rotationZ));

        // Coloque aqui as linhas de código que deseja executar após a rotação
        Destroy(jumpScareZombie);
        Destroy(gameObject);
    }


}

