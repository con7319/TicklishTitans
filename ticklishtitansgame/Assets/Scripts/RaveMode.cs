using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RaveMode : MonoBehaviour
{

    Button[] buttons;
    public TMP_Text title;

    public bool raveMode = false;
    public GameObject background;
    private Renderer myRenderer;
    private Material myMaterial;


    // Start is called before the first frame update
    void Start()
    {
        buttons = GameObject.FindObjectsOfType<Button>();

        myRenderer = background.GetComponent<Renderer>();
        myMaterial = myRenderer.material;

        StopRaveMode();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (!raveMode && Input.GetKey(KeyCode.E))
        {
            StartRaveMode();
        }
        else if (raveMode && Input.GetKey(KeyCode.E))
        {
            StopRaveMode();
        }

        if (raveMode)
        {
            UpdateRaveColors();
        }
    }

    public Color randomColor()
    {
        Color random = new Color(Random.value, Random.value, Random.value, 1.0f); ;
        return random;
    }

    void StopRaveMode()
    {
        raveMode = false;

        foreach (Button button in buttons)
        {
            if (ColorUtility.TryParseHtmlString("#414141", out Color desiredColor))
            {
                button.image.color = desiredColor;
            }

            TMP_Text text = button.GetComponentInChildren<TMP_Text>();
            text.color = Color.white;
        }

        myMaterial.color = Color.white;
        title.color = Color.white;
    }

    void StartRaveMode()
    {
        raveMode = true;
    }

    void UpdateRaveColors()
    {
        foreach (Button button in buttons)
        {
            button.image.color = randomColor();
            TMP_Text text = button.GetComponentInChildren<TMP_Text>();
            text.color = randomColor();
        }

        title.color = randomColor();
        myMaterial.color = randomColor();
    }
}
