using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float LoadDelay = 0.5f;
    [SerializeField] ParticleSystem CrashEffect;


    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Ground")
        {
            CrashEffect.Play();

            Debug.Log("You Crashed!");

            Invoke("ReloadScene", LoadDelay);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
