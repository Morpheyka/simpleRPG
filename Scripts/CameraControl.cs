using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float DistanceToPlayer { get; set; }
    public Transform cameraTarget;

    private Camera _playerCamera;
    private float zoomSpeed = 25f;

    private void Start()
    {
        DistanceToPlayer = 10f;
        _playerCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        if(Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            _playerCamera.fieldOfView -= scroll * zoomSpeed;
        }

        transform.position = new Vector3(cameraTarget.position.x, cameraTarget.position.y + DistanceToPlayer, 
            cameraTarget.position.z - DistanceToPlayer);


    }
}
