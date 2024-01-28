using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
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
        PlayerPrefs.SetInt("winner", 1);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        tickleArea = GameObject.Find("TicklePoint").GetComponent<TickleArea>();
        eTickleArea = GameObject.Find("ETicklePoint").GetComponent<ETickleArea>();

        if (tickleArea != null && tickleArea.currentFill >= tickleArea.Mfull)
        {
            PlayerPrefs.SetInt("Winner", 1);
            PlayerPrefs.Save();
            GameOver();
        }

        if(tickleArea!= null && eTickleArea.currentFill >= eTickleArea.Mfull)
        {
            PlayerPrefs.SetInt("Winner", 0);
            PlayerPrefs.Save();
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

    public void Menu()
    {
        animator.SetBool("transition", true);

        audioSource.Play();

        scene = "Menu";

        Invoke("SceneLoader", 2f);
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
