using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject backPhase1;

    public Dialogue actualDialogue;
    public Inventory playerInventory;

    public Dialogue missao1;
    public Dialogue missao2;
    public Dialogue missao3;


    public void VerificaChave()
    {
        Item chave = playerInventory.itemInventory;

        if (chave != null && chave.itemName == "Key")
        {
            actualDialogue = missao2;
            backPhase1.SetActive(true);
        }
    }

    public void VerificaBoneco()
    {
        Item doll = playerInventory.itemInventory;

        if (doll != null && doll.itemName == "Doll")
        {
            actualDialogue = missao3;
            //backPhase2.SetActive(true);
        }
    }

    void Start()
    {
        actualDialogue = missao1;
    }

    public void TriggerDialogue()
    {
        VerificaChave();
        VerificaBoneco();
        FindObjectOfType<DialogueManager>().StartDialogue(actualDialogue);
        Cursor.lockState = CursorLockMode.None;
    }
}
