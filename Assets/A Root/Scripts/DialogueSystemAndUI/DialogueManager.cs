using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public FirstPersonMovement player;
    private float MouseSensitivity;
    private float PlayerSpeed;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI textText;

    private Queue<string> sentences;
    [SerializeField] private GameObject dialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        MouseSensitivity = player.mouseSensitivity;
        PlayerSpeed = player.speed;
        player.speed = 0;
        player.mouseSensitivity = 0;
        nameText.text = dialogue.name;

        dialogueBox.SetActive(true);
        sentences.Clear();
        
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        //Debug.Log(sentence);
        textText.text = sentence;
    }

    public void EndDialogue()
    {
        player.mouseSensitivity = MouseSensitivity;
        player.speed = PlayerSpeed;
        Cursor.lockState = CursorLockMode.Locked;
        dialogueBox.SetActive(false);
        //Debug.Log("End of conversation");
    }

}
