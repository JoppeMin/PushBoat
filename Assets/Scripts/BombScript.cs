using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    Animation anim;
    Quaternion startRotation;
    AudioSource clip;

    void Start()
    {
        clip = this.gameObject.GetComponent<AudioSource>();
        clip.pitch = Random.Range(0.9f, 1.2f);
        anim = this.gameObject.GetComponent<Animation>();
        StartCoroutine(CameraScaling.SP.ScreenShake(.2f, 0.4f));
    }

    void Update()
    {
        
        if (!anim.isPlaying)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Boat")
        {
            coll.gameObject.GetComponent<BoatScript>().force = new Vector3(
                (coll.gameObject.transform.position.x - this.gameObject.transform.position.x), 
                0f ,
                (coll.gameObject.transform.position.z - this.gameObject.transform.position.z));
            
            print("HIT");
        }
    }
}
