using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class GameOverMessages : MonoBehaviour
{

    public TMP_Text text;

    public bool winner = true;

    public string[] WinnerMessages = File.ReadAllLines("Assets/CSV/WinnerMessages.txt");
    public string[] LoserMessages = File.ReadAllLines("Assets/CSV/loserMessages.txt");

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();

        if (winner)
        {
            if (WinnerMessages.Length > 0)
            {
                text.text = WinnerMessages[Random.Range(0, WinnerMessages.Length - 1)];
            }
            else
            {
                Debug.LogError("Winner Messages empty");
            }
        }
        else
        {
            text.text = LoserMessages[Random.Range(0, LoserMessages.Length- 1)];
        }
    }
}