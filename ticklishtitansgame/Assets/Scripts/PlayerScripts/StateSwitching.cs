using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StateSwitching : MonoBehaviour
{
    public TextMeshProUGUI tickleNJoke;
    public TextMeshProUGUI Defending;
    public TextMeshProUGUI lAtk;
    public TextMeshProUGUI lDef;
    public TextMeshProUGUI rAtk;
    public TextMeshProUGUI rDef;
    private int state;

    private void Start()
    {
        tickleNJoke.gameObject.SetActive(true);
        lAtk.gameObject.SetActive(true);
        rAtk.gameObject.SetActive(true);
        rDef.gameObject.SetActive(false);
        lDef.gameObject.SetActive(false);
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
                lAtk.gameObject.SetActive(false);
                rAtk.gameObject.SetActive(false);
                rDef.gameObject.SetActive(true);
                lDef.gameObject.SetActive(true);
                break;
            case 1:
                state = 0;
                Debug.Log("Attack");
                GameManager.Instance.isDefending = false;
                GameManager.Instance.isAttacking = true;
                tickleNJoke.gameObject.SetActive(true);
                Defending.gameObject.SetActive(false);
                lAtk.gameObject.SetActive(true);
                rAtk.gameObject.SetActive(true);
                rDef.gameObject.SetActive(false);
                lDef.gameObject.SetActive(false);
                break;
        }
    }
}
