using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject smiley;

    // Start is called before the first frame update
    void Start()
    {
        smiley = GameObject.Find("Smiley");
        smiley.SetActive(false);
    }

    public void Play()
    {
        smiley.SetActive(true);
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
