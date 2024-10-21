using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class LookAndDisappear : MonoBehaviour
{
    public Camera playerCamera;   // Referência para a câmera do jogador
    public GameObject[] quadros;     // O quadro que vai desaparecer
    public float maxDistance; // Distância máxima para detectar o quadro
    public float rayThickness;

    private bool[] quadroDesaparecendo;

    void Start()
    {
        // Inicializa o array de flags com o mesmo tamanho do array de quadros
        quadroDesaparecendo = new bool[quadros.Length];
    }

    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;


        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.red, 0.1f);

        // Verifica se o SphereCast acerta algum objeto dentro da distância máxima
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            
            // Verifica se o objeto atingido tem um collider e está no array de quadros
            for (int i = 0; i < quadros.Length; i++)
            {
                GameObject quadro = quadros[i];

                if (hit.collider.gameObject == quadro && !quadroDesaparecendo[i])
                {
                    quadroDesaparecendo[i] = true;
                    Debug.Log(quadros[i].gameObject.name + " ACERTADO");
                    StartCoroutine(DisappearAfterTime(quadro, 2f, i)); // Espera 2 segundos para desativar o quadro
                }
            }
        }
    }

    // Corrotina que aguarda um tempo antes de desativar o quadro
    IEnumerator DisappearAfterTime(GameObject quadro, float time, int index)
    {
        yield return new WaitForSeconds(time);
        quadro.SetActive(false);  // Desativa o quadro após o tempo
        quadroDesaparecendo[index] = false; // Libera o quadro para futuros usos
    }
}
