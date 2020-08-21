using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    private ParticleSystem ps;
    void Start()
    {
        ps = this.gameObject.GetComponentInChildren<ParticleSystem>();
        Destroy(this.gameObject, ps.main.duration);
    }
}
