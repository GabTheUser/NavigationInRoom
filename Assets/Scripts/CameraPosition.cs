using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform cameraTarget;
    private void Update()
    {
        transform.position = new Vector3(cameraTarget.position.x, cameraTarget.position.y, -10); 
    }
}
