using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : SingleTon<CameraManager>
{
    public Vector3 cameraVector;

    [Space(20)]
    public GameObject player;

    private RaycastHit hit;

    private void Start()
    {
        transform.position = player.transform.position + cameraVector;
    }

    private void Update()
    {
        ThreeDRayCast();
    }

    private void ThreeDRayCast() {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        Physics.Raycast(ray, out hit, Mathf.Infinity);
    }

    public RaycastHit GetRaycastHit() {
        return hit;
    }
}
