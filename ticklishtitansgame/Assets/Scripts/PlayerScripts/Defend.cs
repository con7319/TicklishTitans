using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : MonoBehaviour
{
    public bool isCrossingArms = false;
    public bool canCrossArms = true;
    public bool isCoveringEars = false;
    public bool canCoverEars = true;
    private float crossArmsCooldown = 5f;
    private float armsCrossedTime = 3f;
    private float coverEarsCooldown = 5f;

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
        canCoverEars = false;
        Debug.Log("Covering ears");

        isCoveringEars = true;


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

    private IEnumerator CoverEarsCooldown()
    {
        yield return new WaitForSeconds(coverEarsCooldown);
        canCoverEars = true;
    }
}
