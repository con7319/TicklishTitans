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
    public TickleArea tickleArea;
    public ETickleArea eTickleArea;

    // Start is called before the first frame update
    void Awake()
    {
        smiley = GameObject.Find("Smiley");
        
    }

    private void Update()
    {
        tickleArea = GameObject.Find("TicklePoint").GetComponent<TickleArea>();
        eTickleArea = GameObject.Find("ETicklePoint").GetComponent<ETickleArea>();

        if (tickleArea.currentFill == 100)
        {
            GameOver();
        }

        if(eTickleArea.currentFill == 100)
        {
            GameOver();
        }
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

    public void GameOver()
    {
        animator.SetBool("transition", true);
        Debug.Log("animation played");

        audioSource.Play();
        Debug.Log("Audio played");

        scene = "GameOver";
        Debug.Log("Scene set to gameOver");

        Invoke("SceneLoader", 2f);
    }
}
