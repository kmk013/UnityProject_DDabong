using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewModel : MonoBehaviour {

    private float rotLeftRight = 0f;
    private float rotUpDown = 0f;

    private void Update()
    {
        ViewModelRotate();
    }

    private void ViewModelRotate() {
        if (Mathf.Abs(OVRInput.Get(OVRInput.Axis2D.Any).y) > 0.2f)
            transform.Rotate(OVRInput.Get(OVRInput.Axis2D.Any).y * Vector3.right);

        if (Mathf.Abs(OVRInput.Get(OVRInput.Axis2D.Any).x) > 0.2f)
            transform.Rotate(OVRInput.Get(OVRInput.Axis2D.Any).x * Vector3.up);
    }
}
