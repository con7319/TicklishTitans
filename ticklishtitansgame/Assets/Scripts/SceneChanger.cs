using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public GameObject smiley;

    // Start is called before the first frame update
    void Start()
    {
        smiley = GameObject.Find("Smiley");
        smiley.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        smiley.SetActive(true);
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
        
    }
}
