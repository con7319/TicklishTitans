using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StateSwitching : MonoBehaviour
{
    public TextMeshProUGUI tickleNJoke;
    public TextMeshProUGUI Defending;
    private int state;

    private void Start()
    {
        tickleNJoke.gameObject.SetActive(true);
        Defending.gameObject.SetActive(false);
        state = GameManager.Instance.playerDefaultState;
    }

    private void Update()
    {
        if(Input.GetKeyDown("f"))
        {
            Switch();
        }
    }

    private void Switch()
    {
        switch(state)
        {
            case 0:
                state = 1;
                Debug.Log("Defend");
                GameManager.Instance.isAttacking = false;
                GameManager.Instance.isDefending = true;
                tickleNJoke.gameObject.SetActive(false);
                Defending.gameObject.SetActive(true);
                break;
            case 1:
                state = 0;
                Debug.Log("Attack");
                GameManager.Instance.isDefending = false;
                GameManager.Instance.isAttacking = true;
                tickleNJoke.gameObject.SetActive(true);
                Defending.gameObject.SetActive(false);
                break;
        }
    }
}
