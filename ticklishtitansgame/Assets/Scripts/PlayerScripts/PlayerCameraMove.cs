using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMove : MonoBehaviour
{
    public Transform cameraPos;
    public Transform player;

    [SerializeField]private float turnSpeed = 40f;
    private float distance = 5f;
    private Vector3 offset;

    private void Start()
    {
        offset = player.position - cameraPos.position;
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
        transform.position = player.position - offset.normalized * distance;
        transform.LookAt(player.position, Vector3.up);

        player.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
