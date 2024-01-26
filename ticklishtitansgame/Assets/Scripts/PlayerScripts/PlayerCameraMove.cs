using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMove : MonoBehaviour
{
    public Transform player;

    //private float xRotation = 0f;
    private float turnSpeed = 100f;
    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(player.position.x, player.position.y + 0.8f, player.position.z + -4.5f);
    }

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        RotateCamera();
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");

        offset = Quaternion.AngleAxis(mouseX * turnSpeed, Vector3.up) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position);

        player.rotation = transform.rotation;
    }
}
