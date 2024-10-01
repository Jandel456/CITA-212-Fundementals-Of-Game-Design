using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float LoadDelay = 0.9f;
    [SerializeField] ParticleSystem CrashEffect;
    [SerializeField] AudioClip crashSFX;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Ground")
        {
            FindAnyObjectByType<PlayerController>().DisableControls();

            CrashEffect.Play();

            Debug.Log("You Crashed!");

            GetComponent<AudioSource>().PlayOneShot(crashSFX);

            Invoke("ReloadScene", LoadDelay);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
