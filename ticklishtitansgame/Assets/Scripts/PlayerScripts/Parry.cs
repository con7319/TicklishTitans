using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            CringeParry();
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            TickleParry();
        }
    }

    private void CringeParry()
    {
        Debug.Log("Cringe");
    }

    private void TickleParry()
    {
        Debug.Log("Parried");
    }
}
