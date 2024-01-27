using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject smiley;
    public string scene;
    public Animator animator;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        smiley = GameObject.Find("Smiley");
    }

    public void Play()
    {
        animator.SetBool("transition", true);
        Debug.Log("animation played");
        
        audioSource.Play();
        Debug.Log("Audio played");

        scene = "Arena1";
        Debug.Log("Scene set to arena");

        Invoke("SceneLoader", 2f );
    }

    public void SceneLoader()
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
