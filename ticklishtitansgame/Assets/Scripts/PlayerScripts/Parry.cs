using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl)) //KeyCode can be changed
        {
            CringeParry();
        }

        if(Input.GetKeyDown(KeyCode.LeftShift)) //KeyCode can be changed
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
