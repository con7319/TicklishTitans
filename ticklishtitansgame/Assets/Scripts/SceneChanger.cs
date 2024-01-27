using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject smiley;
    public string scene;
    public Animator animate;

    // Start is called before the first frame update
    void Awake()
    {
        smiley = GameObject.Find("Smiley");
        
    }

    public void Play()
    {
        animate.SetBool("transition", true);
        scene = "Arena1";
        Invoke("SceneLoader", 3f );
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
