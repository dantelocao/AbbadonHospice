using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class HUDcontroller : MonoBehaviour
{
    public GameObject fakeCamera;
    public GameObject Player;

    public GameObject menuUI;
    public GameObject cursorUI;
    public GameObject helpUI;

    public Button backMenuButton;

    public Button startButton;
    public Button helpButton;
    public Button exitButton;


    public static HUDcontroller instance;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.None;
        Player.SetActive(false);
    }

    private void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {
        fakeCamera.SetActive(false);
        Player.SetActive(true);
        menuUI.SetActive(false);
        cursorUI.SetActive(true);
    }

    public void HelpButton()
    {
        menuUI.SetActive(false);
        helpUI.SetActive(true);
    }

    public void GoBackMenuButton()
    {
        helpUI.SetActive(false);
        menuUI.SetActive(true);
    }

    public void ExitButton()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                    Application.Quit(); // original code to quit Unity player
        #endif
    }



    [SerializeField] TextMeshProUGUI interactionText;

    public void EnableInteractionText(string text)
    {
        interactionText.text = text + " (F)";
        interactionText.gameObject.SetActive(true);
    }

    public void DisableInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }
    
    
}
