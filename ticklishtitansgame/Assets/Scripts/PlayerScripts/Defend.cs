using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : MonoBehaviour
{
    private void Update()
    {
        if(GameManager.Instance.isDefending && Input.GetMouseButtonDown(0))
        {
            CoverEars();
        }

        if(GameManager.Instance.isDefending && Input.GetMouseButtonDown(1))
        {
            CrossArms();
        }
    }

    private void CoverEars()
    {
        Debug.Log("Covering ears");

        //Add animation code
        //Make this do something
    }

    private void CrossArms()
    {
        Debug.Log("Crossing arms");

        //Add animation code
        //Make this do something
    }
}
