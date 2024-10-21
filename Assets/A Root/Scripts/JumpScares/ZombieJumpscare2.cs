using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieJumpscare2 : ZombieJumpscare1
{
    // Start is called before the first frame update
    void Start()
    {
        jumpScareZombie.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        jumpScareZombie.SetActive(true);
        StartCoroutine(RotateZombie(0, 0, 30));
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(RotateAndExecute(0, 0, -30));
    }

}
