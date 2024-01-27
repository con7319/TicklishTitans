using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TickleArea : MonoBehaviour
{
    public int Mfull = 100;
    public int MEmpt = 0;
    public int currentFill;
    public EMeterScript meterFill;
    public bool inCollider = false;


    void Start()
    {
        currentFill = MEmpt;
        meterFill.SetHumour(currentFill);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider != null && collider.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Trigger entered by an enemy.");
            inCollider = true;
            MeterScript fillMeter = collider.GetComponentInChildren<MeterScript>();
            if (fillMeter != null)
            {
                Debug.Log("you are the tickle");
            }
            else
            {
                Debug.LogError("MeterScript component not found as a child of the collider.");
            }
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider != null && collider.gameObject.CompareTag("Enemy"))
        {
            inCollider = false;
            Debug.Log("Trigger exited by an enemy.");

            MeterScript fillMeter = collider.GetComponentInChildren<MeterScript>();
            if (fillMeter != null)
            {
                Debug.Log("you are the tickle");
            }
            else
            {
                Debug.LogError("MeterScript component not found as a child of the collider.");
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            HahaTime(20);
        }
    }

    public void HahaTime(int haha)
    {
        currentFill += haha;
        meterFill.MeterF(currentFill);
    }
}
