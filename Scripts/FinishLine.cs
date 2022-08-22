using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] AudioClip finishFX;
    [SerializeField] float restartTime = 0.5f;

    [SerializeField] ParticleSystem finishEffect; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GetComponent<AudioSource>().PlayOneShot(finishFX);
            finishEffect.Play();
            Invoke("Restart", restartTime);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
