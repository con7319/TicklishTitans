using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Button button;
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        text = GetComponentInChildren<TMP_Text>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = SetRandomColor();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = Color.white;
    }

    public Color SetRandomColor()
    {
        Color color = new Color(Random.value, Random.value, Random.value, 1.0f);
        return color;
    }
}
