using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class GameOverMessages : MonoBehaviour
{

    public TMP_Text text;

    public bool winner = true;

    public string[] WinnerMessages = File.ReadAllLines("Assets/CSV/WinnerMessages");
    public string[] LoserMessages = File.ReadAllLines("Assets/CSV/LoserMessages");

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();

        if (winner)
        {
            text.text = WinnerMessages[Random.Range(0, WinnerMessages.Length-1)];
        }
        else
        {
            text.text = LoserMessages[Random.Range(0, LoserMessages.Length - 1)];
        }
    }
}
