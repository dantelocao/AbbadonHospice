using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Paper : Interactable
{
    public FirstPersonMovement player;
    private float MouseSensitivity;
    private float playerSpeed;
    public GameObject textoUi;
    public TMP_Text texto;
    public string text;

    public void ReadPaper()
    {
        MouseSensitivity = player.mouseSensitivity;
        playerSpeed = player.speed;

        player.mouseSensitivity = 0;
        player.speed = 0;

        Cursor.lockState = CursorLockMode.None;
        texto.text = text;
        textoUi.SetActive(true);
    }

    public void ClosePaper()
    {
        player.mouseSensitivity = MouseSensitivity;
        player.speed = playerSpeed;

        Cursor.lockState = CursorLockMode.Locked;
        textoUi.SetActive(false);
    }

}
