using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player Attributes")]
    public int playerDefaultState = 0;
    public float playerDefaultMoveSpeed = 20f;
    public bool isAttacking = true;
    public bool isDefending = false;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public static GameManager Instance;
}
