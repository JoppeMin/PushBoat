using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LogoIdle : MonoBehaviour
{
    Vector3 origPos;
    Quaternion origRot;
    Vector3 pos;
    Quaternion rot;

    private void Start()
    {
        origPos = this.transform.position;
        origRot = this.transform.rotation;

        pos = this.transform.position;
        rot = this.transform.rotation;
    }

    private void Update()
    {
        pos.y = origPos.y + Mathf.Sin(Time.time) * 6;
        rot.z = origRot.z + Mathf.Sin(Time.time*2) * 0.02f;
        this.transform.rotation = rot;
        this.transform.position = pos;
    }
}
