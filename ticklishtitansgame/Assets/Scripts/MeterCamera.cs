using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterCamera : MonoBehaviour
{
    public Camera lookAtCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - lookAtCamera.transform.position);
        
    }
}
