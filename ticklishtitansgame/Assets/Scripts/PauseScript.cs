using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [Header("Objects")]
    public GameObject[] bullets;
    public GameObject enemy, hero;

    public GameObject Menu;

    [Header("Variables")]
    public bool paused = false;


    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
        Menu = GameObject.Find("PauseMenu");
        hero = GameObject.FindWithTag("Player");


        Menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bullets = GameObject.FindGameObjectsWithTag("Bullet");

        if(!paused && Input.GetKeyUp(KeyCode.Q))
        {
            pause();
        }
        else if(paused && Input.GetKeyUp(KeyCode.Q))
        {
            play();
        }
    }

    public void pause()
    {
        enemy.GetComponent<EnemyMovement>().enabled = false;
        Debug.Log(enemy.GetComponent<EnemyMovement>().isActiveAndEnabled);

        hero.GetComponent<PlayerMovement>().enabled = false;
        hero.GetComponent<Attack>().enabled = false;
        Debug.Log(hero.GetComponent<Attack>().isActiveAndEnabled);
        Debug.Log(hero.GetComponent<PlayerMovement>().isActiveAndEnabled);

        GameObject.FindWithTag("MainCamera").GetComponent<PlayerCameraMove>().enabled = false;

        Menu.SetActive(true);

        Cursor.lockState = CursorLockMode.None;

        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }

        paused = true;
    }

    public void play()
    {
        enemy.GetComponent<EnemyMovement>().enabled = true;
        Debug.Log(enemy.GetComponent<EnemyMovement>().isActiveAndEnabled);

        hero.GetComponent<PlayerMovement>().enabled = true;
        hero.GetComponent<Attack>().enabled = true;
        Debug.Log(hero.GetComponent<Attack>().isActiveAndEnabled);
        Debug.Log(hero.GetComponent<PlayerMovement>().isActiveAndEnabled);

        GameObject.FindWithTag("MainCamera").GetComponent<PlayerCameraMove>().enabled = true;

        Menu.SetActive(false);

        paused = false;
    }
}
