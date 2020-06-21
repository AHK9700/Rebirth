using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{

    Transform player;
    public Vector3 offset;

    public float pitch = 3f;

    public float Yawspeed = 100f;
    private float YawInput = 0f;
    

    private float currentzoom = 10f;
    public float zoomspeed = 4f;
    public float minizoom = 5f;
    public float maxzoom = 15f;


    void Update()
    {
        currentzoom -= Input.GetAxis("Mouse ScrollWheel") * zoomspeed;
        currentzoom = Mathf.Clamp(currentzoom, minizoom, maxzoom);
        YawInput -= Input.GetAxis("Horizontal") * Yawspeed * Time.deltaTime;
    }


    void LateUpdate()
    {
        transform.position = transform.position - offset * currentzoom;
        transform.LookAt(player.position + Vector3.up * pitch);
        transform.RotateAround(player.position, Vector3.up, YawInput);
    }


}
