using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBoardingscript : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FindObjectOfType<BoatSpawn>().StartBoatSpawn();
            Destroy(this.gameObject);
        }
    }
    
}
