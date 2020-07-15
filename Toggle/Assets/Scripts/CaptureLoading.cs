using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureLoading : MonoBehaviour
{
    CapturePoint cp;

    private void Awake()
    {
        cp = GetComponentInParent<CapturePoint>();
        transform.localScale = new Vector3();
    }

    private void Update()
    {
        transform.localScale = Vector3.one * cp.captureProgress;
    }
}
