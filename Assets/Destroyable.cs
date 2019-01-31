using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    Animation anim;
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        if (!anim.isPlaying)
        {
            Destroy(this.gameObject);
        }
    }
}
