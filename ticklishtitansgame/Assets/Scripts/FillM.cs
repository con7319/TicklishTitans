using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillM : MonoBehaviour
{

    public int Mfull = 100;
    public int MEmpt = 0;
    public int currentFill;
    public MeterScript meterFill;
    // Start is called before the first frame update
    void Start()
    {
        currentFill = MEmpt;
        meterFill.SetHumour(currentFill);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            HahaTime(20);
        }
    }

    void HahaTime(int haha)
    {
        currentFill += haha;
        meterFill.MeterF(currentFill);
    }
}
