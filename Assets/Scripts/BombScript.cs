using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    Animation anim;
    Quaternion startRotation;

    void Start()
    {
        anim = this.gameObject.GetComponent<Animation>();
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
            coll.gameObject.GetComponent<BoatScript>().force = new Vector3((coll.gameObject.transform.position.x - this.gameObject.transform.position.x), 0f ,(coll.gameObject.transform.position.z - this.gameObject.transform.position.z));
            
            print("HIT");
        }
    }
}
