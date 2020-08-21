using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

[ExecuteInEditMode]
public class CameraScaling : MonoBehaviour
{
    public static CameraScaling SP;
    private float defaultWidth;

    private float shakeTimeLeft, shakePower;

    private Vector3 originalposition;
    private Quaternion originalRotation;

    void Awake()
    {
        SP = this;
        defaultWidth = 7 * Screen.height / Screen.width * 0.5f;
        Camera.main.orthographicSize = defaultWidth;
        originalposition = this.transform.position;
        originalRotation = this.transform.rotation;
    }


    public IEnumerator ScreenShake(float length, float power)
    {
 
        shakeTimeLeft = length;
        
        while (shakeTimeLeft > 0)
        {
            shakePower = (Mathf.Lerp(0f,length, shakeTimeLeft) * power);
            Vector3 shakeCoord = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f),Random.Range(-1f, 1f))  * shakePower;

            transform.position = originalposition + (Vector3) shakeCoord;
            transform.localRotation = Quaternion.Euler(originalRotation.eulerAngles.x, originalRotation.eulerAngles.y, originalRotation.eulerAngles.z + (Random.Range(-50f, 50f) * shakePower));
            
            shakeTimeLeft -= Time.deltaTime;
            yield return null;
        }

        this.transform.rotation = originalRotation;
        this.transform.position = originalposition;

    }
}
