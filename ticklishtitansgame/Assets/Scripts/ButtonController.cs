using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [Header("Objects")]
    public Button button;
    public TMP_Text text;

    /*[Header("Colors")]
    public string[] colours = { 
        "#FF0000",
        "#FFF000",
        "#E71EBE",
        "#FFAC2A",
        "#67EC13",
        "#0FC0f0"
    };
    public int originalColorIndex;
    public int newColorIndex;*/

    void Start()
    {
        button = GetComponent<Button>();
        text = GetComponentInChildren<TMP_Text>();

        //SetColor(colours[originalColorIndex]);
        //SetRandomTextColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //SetColor(colours[newColorIndex]);
        SetRandomTextColor();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //SetColor(colours[originalColorIndex]);
        SetRandomTextColor();
    }

    /*public void SetColor(string hexColor)
    {
        Color color;
        if (ColorUtility.TryParseHtmlString(hexColor, out color))
        {
            text.color = color;
        }
    }*/

    public void SetRandomTextColor()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        text.color = randomColor;


    }
}
