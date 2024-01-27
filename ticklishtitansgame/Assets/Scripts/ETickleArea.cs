using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ETickleArea : MonoBehaviour
{
    public int Mfull = 100;
    public int MEmpt = 0;
    public int currentFill;
    public MeterScript meterFill;
    public bool inCollider = false;


    void Start()
    {
        currentFill = MEmpt;
        meterFill.SetHumour(currentFill);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider != null && collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Trigger entered by an Player.");
            inCollider = true;           
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider != null && collider.gameObject.CompareTag("Player"))
        {
            inCollider = false;
            Debug.Log("Trigger exited by Player.");

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
