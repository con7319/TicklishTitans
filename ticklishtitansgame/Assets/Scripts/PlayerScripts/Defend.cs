using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : MonoBehaviour
{
    public bool isCrossingArms = false;
    public bool canCrossArms = true;
    private float crossArmsCooldown = 5f;
    private float armsCrossedTime = 3f;

    private void Update()
    {
        if(GameManager.Instance.isDefending && Input.GetMouseButtonDown(0))
        {
            CoverEars();
        }

        if(canCrossArms && GameManager.Instance.isDefending && Input.GetMouseButtonDown(1))
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
        canCrossArms = false;
        Debug.Log("Crossing arms");

        isCrossingArms = true;

        StartCoroutine(CrossingArmTime());
        StartCoroutine(CoverArmssCooldown());
    }

    private IEnumerator CrossingArmTime()
    {
        yield return new WaitForSeconds(armsCrossedTime);

        isCrossingArms = false;
    }

    private IEnumerator CoverArmssCooldown()
    {
        yield return new WaitForSeconds(crossArmsCooldown);
        canCrossArms = true;
    }
}
