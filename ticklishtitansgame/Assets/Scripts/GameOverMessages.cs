using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverMessages : MonoBehaviour
{

    public TMP_Text text;

    public bool winner = true;

    public string[] WinnerMessages;
    public string[] LoserMessages;

    // Start is called before the first frame update
    void Start()
    {
        LoserMessages = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath, "loserMessages.txt"));
        WinnerMessages = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath,"WinnerMessages.txt"));

        bool winner = PlayerPrefs.GetInt("Winner") == 1;

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
