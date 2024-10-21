using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject cursorUI;
    public GameObject endUI;
    public GameObject Player;
    public GameObject fakeCamera;

    void OnDestroy()
    {
        End();
    }

    void End()
    {
        endUI.SetActive(true);
        cursorUI.SetActive(false);
        Player.SetActive(false);
        fakeCamera.SetActive(true);
    }
}
