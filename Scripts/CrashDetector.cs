using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] AudioClip crashFX;
    [SerializeField] ParticleSystem crash;
    [SerializeField] float restartTime = 0.5f;
    CircleCollider2D playerHead;
    bool hasCrashed = false;
    
    void Start()
    {
        playerHead = GetComponent<CircleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground" && playerHead.IsTouching(other.collider) && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            GetComponent<AudioSource>().PlayOneShot(crashFX);
            crash.Play();
            Invoke("Restart", restartTime);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
