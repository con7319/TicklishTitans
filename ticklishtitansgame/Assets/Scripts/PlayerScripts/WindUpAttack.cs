using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindUpAttack : MonoBehaviour
{
    private float windTime = 0f;

    public Image windUpBar;

    private void Update()
    {
        if(GameManager.Instance.isAttacking && Input.GetKey(KeyCode.Space)) //KeyCode can be changed
        {
            WindUp();
        }

        if(GameManager.Instance.isAttacking && Input.GetKeyUp(KeyCode.Space)) //KeyCode can be changed
        {
            SetWindTimeToZero();
        }

        FillBar(windTime);
    }

    private void WindUp()
    {
        windTime += Time.deltaTime;
        
        if(windTime == 0)
        {
            Debug.Log("This shouldnt be seen");
        }
        else if(windTime > 1 && windTime < 2)
        {
            Debug.Log("Level 1");
        }
        else if(windTime > 2 && windTime < 3)
        {
            Debug.Log("Level 2");
        }
        else if(windTime > 3 && windTime < 4)
        {
            Debug.Log("Level 3");
        }
    }

    private void SetWindTimeToZero()
    {
        windTime = 0;
    }

    public void FillBar(float fillValue)
    {
        float amount = (fillValue / 2f) * 180f/360;
        windUpBar.fillAmount = amount;
        
    }
}
