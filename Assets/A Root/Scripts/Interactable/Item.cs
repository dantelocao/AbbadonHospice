using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item : Interactable
{
    public AudioSource source;

    public GameObject newPhase;
    public GameObject lastPhase;
    public Inventory playerInventory;
    public string itemName;
    public Sprite icon;
    public string description;
    public int quantity;

    public void AddItemInventory(Item adicionar)
    {
        playerInventory.itemInventory = adicionar;
        StartCoroutine(TocarSomEDesativar());
    }

    private IEnumerator TocarSomEDesativar()
    {
        // Toca o som
        source.Play();

        // Espera até que o áudio termine de tocar
        yield return new WaitForSeconds(source.clip.length);

        // Após o som tocar, desativa o objeto
        gameObject.SetActive(false);
    }
    public void KeyJumpScareScene()
    {
        newPhase.SetActive(true);
    }

    public void DollJumpScareScene()
    {
        lastPhase.SetActive(true);
    }
}
