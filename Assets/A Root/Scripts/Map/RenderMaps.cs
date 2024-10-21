using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderMaps : MonoBehaviour
{
    public GameObject portaEntradaSubterraneo;
    public GameObject portaEntradaTerreo;

    public GameObject subterraneo;
    public GameObject terreo;

    private void Start()
    {
        //terreo.SetActive(false);
    }

    void CloseDoorSubterran()
    {
        // Obtém todos os scripts Door dentro deste GameObject (ou filhos)
        Door door = portaEntradaSubterraneo.GetComponentInChildren<Door>();
        door.CloseDoor();
    }

    void CloseDoorTerreo()
    {
        // Obtém todos os scripts Door dentro deste GameObject (ou filhos)
        Door door = portaEntradaTerreo.GetComponentInChildren<Door>();
        door.CloseDoor();
    }


    private void OnTriggerExit(Collider other)
    {
        // Verifica se o player saiu do Box Collider
        if (other.CompareTag("Player"))
        {
            CloseDoorSubterran();

            //Desativa o mapa atual
            subterraneo.SetActive(false);

            // Ativa o novo mapa
            terreo.SetActive(true);
        }

    }

    // Quando o player voltar à área do mapa
    private void OnTriggerEnter(Collider other)
    {
        
        // Verifica se o player entrou novamente no Box Collider
        if (other.CompareTag("Player"))
        {
            CloseDoorTerreo();

            // Ativa o mapa atual
            subterraneo.SetActive(true);

            // Desativa o novo mapa
            terreo.SetActive(false);
        }
    }
}
