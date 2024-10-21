using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpScareTrigger : MonoBehaviour
{
    public float time;
    public GameObject jumpScareObject;

    public AudioClip[] monsterClips;  // Array para armazenar diferentes sons de passos
    public AudioClip[] zombieClips;  // Array para armazenar diferentes sons de passos

    public AudioSource audioSource;

    private void Start()
    {
        jumpScareObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (jumpScareObject.name == "CrawlerJumpScare (1)")
            {
                // Seleciona um som de passo aleatório
                int randomIndex = UnityEngine.Random.Range(0, monsterClips.Length);
                audioSource.clip = monsterClips[randomIndex];
                audioSource.Play();

            } else
            {
                int randomIndex = UnityEngine.Random.Range(0, zombieClips.Length);
                audioSource.clip = zombieClips[randomIndex];
                audioSource.Play();

            }

            jumpScareObject.SetActive(true);
            StartCoroutine(DestroyObject());
        }
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(time);
        Destroy(jumpScareObject);
        Destroy(gameObject);
    }
}
